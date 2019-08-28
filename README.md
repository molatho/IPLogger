# IPLogger
A friend of mine asked me to write an application that would allow you to create a list of IP addresses and detect whether they're online or offline by continuosly sending ping-requests to them. This project turned out to be quite a lot of fun which is why I took some time and added some convenience features.

## Features
* Type out or get IP addresses by sending DNS requests and add them to your pool of targets to ping
* View a detailled graph and a list of all recorded downtimes for each address
* Individually toggle pinging addresses
* Launch on system startup (configurable)
* Runs in background
* Customize ping intervals and timeouts

## Screenshots
![Main window](/images/main.png)
The main window shows an overview of your list of targets to ping. For each target it displays their latest status, uptime and downtime.
![Graph](/images/graph.png)
The detail view features a graph of all recorded ping-requests.
![Add target](/images/add_target.png)
One can add targets by either typing out a name and an IP address or by resolving a hostname.