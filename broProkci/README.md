## Borocito-Component
This is a component. And it can be installed with '`boro-get`'.  
Check [this readme](https://github.com/Borocito/Components-for-Borocito/blob/main/boro-get/README.md) to know how to implement `boro-get`, with your BorocitoCLI instances.  

## About
This plugin allow creating a channel between Borocito CLI TCP/IP server to a Cloud-Based TCP/IP server, so you can connect to Borocito CLI instances over the internet with a VPS or Serverless Python application serving a server.
This plugins allow that Man-in-the-Middle communication.

> Single Instance Package  
## Usage
Just install it. It will connect to the Owner Server TCP/IP on port 13120.  

If you want to use a specific remote ip address and port, you can do so by launching it with the parameter:  
```sh
--ip 67.420.666.69:1337
```
> If not, it will be using the OwnerServer value from the Windows Registry.  
> You have to specify a port, this field is not optional.  

### WARNING
**The plugins created are not perfect. I recommend you take a look at the code to know what it does and how it does it, so you avoid unpredictable behavior or bad practices.**