using IPLogger.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPLogger.UI
{
    public class Graph : UserControl
    {
        public enum eLineMode
        {
            ConnectedLines,
            Bars,
            Dots
        }
        public enum eGraphMode
        {
            All,
            Latest,
            Between
        }
        public enum eAxisMode
        {
            Dynamic,
            Static
        }
        public IDataPointProvider Provider { get; set; }
        public float RefreshRate
        {
            get { return 1000f / timer.Interval; }
            set { timer.Interval = Math.Max(1, (int)(1000f / value)); }
        }
        public bool RefreshEnabled
        {
            get { return timer.Enabled; }
            set { timer.Enabled = value; }
        }
        public eGraphMode GraphMode { get; set; }
        public eAxisMode AxisModeMin { get; set; }
        public eAxisMode AxisModeMax { get; set; }
        public float AxisStaticMin { get; set; }
        public float AxisStaticMax { get; set; }
        public eLineMode LineMode { get; set; }

        public TimeSpan GraphModeLatest { get; set; }
        public DateTime GraphModeFrom { get; set; }
        public DateTime GraphModeTo { get; set; }

        public DateTime ViewFrom { get; private set; }
        public DateTime ViewTo { get; private set; }

        public event EventHandler HasDrawn;

        private Timer timer;
        private bool mouseOver;

        public Graph()
        {
            DoubleBuffered = true;
            BorderStyle = BorderStyle.FixedSingle;
            BackColor = Color.White;

            timer = new Timer();
            timer.Tick += (o, e) => Invalidate();

            RefreshRate = 60;
            RefreshEnabled = true;
            GraphMode = eGraphMode.Latest;
            GraphModeLatest = TimeSpan.FromSeconds(100);
            GraphModeTo = DateTime.Now;
            GraphModeFrom = DateTime.Now.Subtract(TimeSpan.FromDays(1));
            AxisModeMax = eAxisMode.Dynamic;
            AxisModeMin = eAxisMode.Static;
            AxisStaticMax = 100;
            AxisStaticMin = 0;
            LineMode = eLineMode.ConnectedLines;
        }

        DateTime lastUpdate = DateTime.Now;
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

            e.Graphics.Clear(BackColor);

            if (Provider == null) return;

            DataPoint[] data = new DataPoint[0];
            DateTime from = DateTime.Now, to = DateTime.Now;
            switch (GraphMode)
            {
                case eGraphMode.All:
                    data = Provider.GetAll().ToArray();
                    break;
                case eGraphMode.Latest:
                    data = Provider.GetLatest(GraphModeLatest).ToArray();
                    break;
                case eGraphMode.Between:
                    data = Provider.GetBetween(GraphModeFrom, GraphModeTo).ToArray();
                    break;
            }
            if (data.Length == 0)
            {
                var size = e.Graphics.MeasureString("No data available", Font);
                e.Graphics.DrawString("No data available", Font, Brushes.Red, Width / 2f - size.Width / 2f, Height / 2f - size.Height / 2f);
                return;
            }
            switch (GraphMode)
            {
                case eGraphMode.All:
                    from = data[0].TimeStamp;
                    to = data[data.Length - 1].TimeStamp;
                    break;
                case eGraphMode.Latest:
                    from = DateTime.Now - GraphModeLatest;
                    to = DateTime.Now;
                    break;
                case eGraphMode.Between:
                    from = GraphModeFrom;
                    to = GraphModeTo;
                    break;
            }

            ViewFrom = from;
            ViewTo = to;

            var diff = DateTime.Now - lastUpdate;
            lastUpdate = DateTime.Now;
            var fps = diff.TotalMilliseconds > 0 ? 1000f / diff.TotalMilliseconds : 0;

            var min = AxisModeMin == eAxisMode.Static ? AxisStaticMin : data.Min(x => x.Latency);
            var max = AxisModeMax == eAxisMode.Static ? AxisStaticMax : data.Max(x => x.Latency) * 1.25f;
            var duration = to - from;
            var height = Math.Abs(min - max);
            if (height == 0) height = 10;

            var pen = new Pen(ForeColor);

            e.Graphics.DrawLine(Pens.LightGray, 0, Height * 0.75f, Width, Height * 0.75f);
            e.Graphics.DrawLine(Pens.LightGray, 0, Height * 0.5f, Width, Height * 0.5f);
            e.Graphics.DrawLine(Pens.LightGray, 0, Height * 0.25f, Width, Height * 0.25f);

            for (int i = 0; i < data.Length - 1; i++)
            {
                var x1 = (float)((to - data[i].TimeStamp).TotalSeconds / duration.TotalSeconds);
                var y1 = (data[i].Latency - min) / height;
                var x2 = (float)((to - data[i + 1].TimeStamp).TotalSeconds / duration.TotalSeconds);
                var y2 = (data[i + 1].Latency - min) / height;

                var xLeft = Width - x1 * Width;
                var xRight = Width - x2 * Width;
                var yLeft = Height - y1 * Height;
                var yRight = Height - y2 * Height;

                if (i == 0 && Math.Abs((data[i].TimeStamp - from).TotalSeconds) > 2)
                {
                    e.Graphics.FillRectangle(Brushes.LightGray,
                        0, 0, xRight, Height);
                } else if (i == data.Length -2 && Math.Abs((to - data[i+1].TimeStamp).TotalSeconds) > 2)
                {
                    e.Graphics.FillRectangle(Brushes.LightGray,
                        xRight, 0, Width - xRight, Height);
                }

                if (Math.Abs((data[i + 1].TimeStamp - data[i].TimeStamp).TotalSeconds) > 5)
                {
                    e.Graphics.FillRectangle(Brushes.LightGray,
                        xLeft, 0, xRight - xLeft, Height);
                    continue;
                }
                if (data[i].Success && data[i + 1].Success)
                {
                    switch (LineMode)
                    {
                        case eLineMode.ConnectedLines:
                            e.Graphics.DrawLine(pen, xLeft, yLeft, xRight, yRight);
                            break;
                        case eLineMode.Bars:
                            e.Graphics.DrawLine(pen, xLeft, yLeft, xRight, yLeft);
                            break;
                        case eLineMode.Dots:
                            e.Graphics.DrawRectangle(pen, xLeft - 1, yLeft - 1, 2, 2);
                            break;
                    }
                }else if (!data[i].Success && !data[i+1].Success)
                {
                    e.Graphics.FillRectangle(Brushes.Red, xLeft, 0, xRight - xLeft, Height);
                } else if (!data[i].Success)
                {
                    e.Graphics.DrawLine(Pens.Red, xLeft, 0, xLeft, Height);
                }
            }

            if (mouseOver)
            {
                var mousePos = PointToClient(Cursor.Position);
                var mouseX = (float)(Width - mousePos.X) / Width;
                var mouseTime = to.Subtract(TimeSpan.FromSeconds(duration.TotalSeconds * mouseX));
                var ordered = data.OrderBy(x => Math.Abs(mouseTime.Ticks - x.TimeStamp.Ticks)).ToArray();
                var mouseEntry = ordered.First();
                var mouseEntryIdx = Array.IndexOf(data, mouseEntry);
                var mouseEntryIdxNext = 0;
                if (mouseTime < mouseEntry.TimeStamp) mouseEntryIdxNext = mouseEntryIdx - 1;
                else mouseEntryIdxNext = mouseEntryIdx + 1;
                if (mouseEntryIdxNext >= 0 & mouseEntryIdxNext < data.Length)
                {
                    var mouseEntryNext = data[mouseEntryIdxNext];
                    //if (mouseEntry.Success && mouseEntryNext.Success)
                    if(Math.Abs((mouseEntryNext.TimeStamp - mouseEntry.TimeStamp).TotalSeconds) > 5)
                    {
                        DrawMouseText(
                            e.Graphics,
                            string.Format("{0}\n{1}\n{2}",
                            mouseTime.ToShortDateString(),
                            mouseTime.ToLongTimeString(),
                            "No data available"),
                            mousePos.X,
                            Pens.Red,
                            Pens.Red,
                            Brushes.White,
                            Brushes.Red);
                    }
                    else
                    {
                        var pingText = string.Format("{0}\n{1}\n{2}",
                            mouseEntry.TimeStamp.ToShortDateString(),
                            mouseEntry.TimeStamp.ToLongTimeString(),
                            mouseEntry.Success ? mouseEntry.Latency.ToString() + "ms" : mouseEntry.Status.ToString());

                        DrawMouseText(
                            e.Graphics,
                            pingText,
                            mousePos.X,
                            mouseEntry.Success ? Pens.Gray : Pens.Red,
                            mouseEntry.Success ? Pens.Gray : Pens.Red,
                            Brushes.White,
                            mouseEntry.Success ? Brushes.Gray : Brushes.Red
                            );
                    }
                }
                else
                {
                    DrawMouseText(
                        e.Graphics,
                        string.Format("{0}\n{1}\n{2}",
                            mouseTime.ToShortDateString(),
                            mouseTime.ToLongTimeString(),
                            "No data available"),
                        mousePos.X,
                        Pens.Red,
                        Pens.Red,
                        Brushes.White,
                        Brushes.Red);
                }
            }
            e.Graphics.DrawString(((int)(height * 0.25f)).ToString(), Font, Brushes.Gray, 0, Height * 0.75f);
            e.Graphics.DrawString(((int)(height * 0.5f)).ToString(), Font, Brushes.Gray, 0, Height * 0.5f);
            e.Graphics.DrawString(((int)(height * 0.75f)).ToString(), Font, Brushes.Gray, 0, Height * 0.25f);
            e.Graphics.DrawString(((int)height).ToString(), Font, Brushes.Gray, 0, 0);

            pen.Dispose();

            //e.Graphics.DrawString(fps.ToString("0.0"), Font, Brushes.Black, 4, 4);
            HasDrawn?.Invoke(this, EventArgs.Empty);
        }

        private void DrawMouseText(Graphics graphics, string text, float x, Pen penLine, Pen penBorder, Brush brushBackground, Brush brushText)
        {
            var pingTextSize = graphics.MeasureString(text, Font);
            graphics.DrawLine(penLine, x, 0, x, Height);

            graphics.FillRectangle(brushBackground,
                x + pingTextSize.Width > Width ? x - (int)pingTextSize.Width : x,
                0,
                pingTextSize.Width,
                pingTextSize.Height);
            graphics.DrawRectangle(
                penBorder,
                x + pingTextSize.Width > Width ? x - (int)pingTextSize.Width : x,
                0,
                pingTextSize.Width,
                pingTextSize.Height);
            graphics.DrawString(text,
                Font,
                brushText,
                x + pingTextSize.Width > Width ? x - (int)pingTextSize.Width : x,
                0);
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);

            if (GraphMode == eGraphMode.Between)
            {
                var pos = PointToClient(Cursor.Position);
                var x = (float)pos.X / Width;
                var duration = ViewTo - ViewFrom;
                var timePos = (ViewFrom + TimeSpan.FromSeconds(duration.TotalSeconds * x));
                GraphModeLatest = TimeSpan.FromSeconds(duration.TotalSeconds * 0.75f);
                GraphModeFrom = timePos - TimeSpan.FromSeconds(GraphModeLatest.TotalSeconds * 0.5f);
                GraphModeTo = timePos + TimeSpan.FromSeconds(GraphModeLatest.TotalSeconds * 0.5f);
            }
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            if (GraphMode == eGraphMode.Between)
            {
                var pos = PointToClient(Cursor.Position);
                var x = (float)pos.X / Width;
                var duration = ViewTo - ViewFrom;
                var timePos = (ViewFrom + TimeSpan.FromSeconds(duration.TotalSeconds * x));
                GraphModeFrom = timePos - TimeSpan.FromSeconds(GraphModeLatest.TotalSeconds * 0.5f);
                GraphModeTo = timePos + TimeSpan.FromSeconds(GraphModeLatest.TotalSeconds * 0.5f);
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            mouseOver = true;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            mouseOver = true;
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            mouseOver = false;
        }
    }
}
