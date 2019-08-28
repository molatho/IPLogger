using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPLogger.Utils
{
    public class TimeBufferedStream : Stream
    {
        public Stream BaseStream { get; private set; }
        public TimeSpan Time { get; set; }
        public DateTime LastFlush { get; private set; }
        public override bool CanRead => bufferedStream.CanRead;
        public override bool CanSeek => bufferedStream.CanSeek;
        public override bool CanWrite => bufferedStream.CanWrite;
        public override long Length => bufferedStream.Length;
        public override long Position { get => bufferedStream.Position; set => bufferedStream.Position = value; }

        private BufferedStream bufferedStream;
        private Stream baseStream;

        public TimeBufferedStream(Stream baseStream, TimeSpan time)
        {
            this.baseStream = baseStream;
            bufferedStream = new BufferedStream(baseStream);
            Time = time;
            LastFlush = DateTime.MinValue;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (!disposing)
                bufferedStream.Dispose();
        }

        public override void Flush() { bufferedStream.Flush(); }
        public override int Read(byte[] buffer, int offset, int count) { return bufferedStream.Read(buffer, offset, count); }
        public override long Seek(long offset, SeekOrigin origin) { return bufferedStream.Seek(offset, origin); }
        public override void SetLength(long value) { bufferedStream.SetLength(value); }


        public override void Write(byte[] buffer, int offset, int count)
        {
            bufferedStream.Write(buffer, offset, count);
            var now = DateTime.Now;
            if (now - LastFlush > Time)
            {
                bufferedStream.Flush();
                LastFlush = now;
            }
        }
    }
}
