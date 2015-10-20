## Quick Start to Installing SessionM MMC C# wrapper libs

You will need a SessionM Mobile Marketing Cloud account in order to use this
API for running your Loyalty Solution. 

Email: sales@sessionm.com 
Or
Connect with us on www.sessionm.com

##Pre-requisites

* C# compiler
* Microsoft .NET 4.5.2 or greater
* Visual Studio 2015 Express / Professional


##Installing 

You can clone the git repo and copy it into your .NET Solution folder.
Add the project to your Solution by importing it in Visual Studio.
Add from your Website or WebApplication project reference to `SessionM.MMC`.

**NOTE**: *Files in the SessionM.MMC should never be editted directly*.

##Configuring

You will need to create and add an XML Configuration file `SMServiceConfig.xml` into your `Release` , `Debug` or other application executable folder. You can obtain credentials for the configuration from the Applicaiton Properties page in SessionM Mobile Marketing Cloud portal.

```
<Configurations>
  <configuration>
    <ServerUrl>https://www.example.com</ServerUrl>
    <ApiKey>key</ApiKey>
    <ApiSecret>secret</ApiSecret>
  </configuration>
</Configurations>
```
## Example 

SessionM.MMC.TestApp

`Program.cs`

