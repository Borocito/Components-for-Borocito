## Borocito-Component
This is a component. And it can be installed with '`boro-get`'.  
Check [this readme](https://github.com/Borocito/Components-for-Borocito/blob/main/boro-get/README.md) to know how to implement `boro-get`, with your BorocitoCLI instances.  

## About
This plugin can handle multi clients TCP/IP connections. And can keep a good channel for every other TCP/IP software that wants to communicate with the Borocito CLI instance.  
Is compatible with boro-hear.

**This component is no longer needed, as Borocito CLI now implements handling multi-clients.** _And now, this component is deprecated._
> If you want some Server TCP/IP <-> Borocito TCP/IP, [broProkci](https://github.com/Borocito/Components-for-Borocito/tree/main/broProkci) is what u are looking for.

> Single Instance Package  
## Usage
Just install it and then launch any TCP/IP socket client to connect to port 13121.  

### WARNING
**The plugins created are not perfect. I recommend you take a look at the code to know what it does and how it does it, so you avoid unpredictable behavior or bad practices.**