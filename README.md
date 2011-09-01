# Zencoder .NET
#### A .NET C# client library for the [zencoder.com](http://zencoder.com/) API

Visit <https://app.zencoder.com/docs> for full API documentation.

This is an attempt at a fully object-oriented implementation of the Zencoder API for .NET. 
It is compatible with .NET 3.5 and above (although the limited 3.5 features used could be
removed for 2.0 compatibility if someone asks for it).

XML comments are used extensively throughout, so it should be pretty discoverable if you're
using an IDE that supports intellisense.

## Building

Run the build script with MSBuild v3.5 (C:\Windows\Microsoft.NET\Framework\v3.5\MSBuild.exe or similar).

    msbuild build.proj
    
You can also build using the solution in Visual Studio 2008.

## Basic Usage

All of the requests can be accessed through a `Zencoder` object instance. Construct one with
your API key:

    var zen = new Zencoder(api_key);
    
You can then create a job:

	zen.CreateJob("s3://bucket-name/file-name.avi", new Output[] {
		// Define your output(s) here.
	});

There is also full non-blocking (async) support, so the non-blocking version of the above call is:

	zen.CreateJob("s3://bucket-name/file-name.avi", new Output[] {
		// Define your output(s) here.
	}, response => {
		// Work with the response here.
	});

It's not much harder to work with each API action's requestion & response objects, so feel free to
rock it that way if you prefer.

**Please note:** the above input file URLs (`s3://bucket-name/file-name.avi`) are only examples. Zencoder
supports a number of input and output location types (e.g., HTTP, S3, Cloud Files, FTP and SFTP). Please 
[see the Zencoder documentation](https://app.zencoder.com/docs/api/encoding/job/input) for more information.

## HTTP Notifications

You can define both [email and HTTP](https://app.zencoder.com/docs/api/encoding/notifications) notifications with
your job outputs. If you have an ASP.NET application, you can use the built-in `NotificationHandler`
to process those notifications for you.

Add the handler to your Web.config and configure each receiver that you want called when a
notification comes in. Receivers implement `INotificationReceiver`, which is a single method:
`OnReceive(HttpPostNotification)`.

An example Web.config:

    <configuration>
      <configSections>
        <section name="zencoder" type="Zencoder.ZencoderSettings, Zencoder"/>
      </configSections>
      <system.web>
        <httpHandlers>
          <add path="zencoder.ashx" verb="POST" type="Zencoder.NotificationHandler, Zencoder"/>
        </httpHandlers>
      </system.web>
      <system.webServer>
        <handlers>
         <add name="zencoder.ashx" path="zencoder.ashx" verb="POST" type="Zencoder.NotificationHandler, Zencoder" preCondition="managedHandler"/>
        </handlers>
      </system.webServer>
      <zencoder>
        <!-- You could also skip this part of the configuration and add your receivers to
             Zencoder.NotificationHandler.Receivers programatically. -->
        <notifications>
          <!-- Each notification receiver should implement Zencoder.INotificationReceiver -->
          <add name="MyReceiver" value="MyAssembly.MyReceiver, MyAssembly"/>
          <add name="MyOtherReceiver" value="MyAssembly.MyOtherReceiver, MyAssembly"/>
        </notifications>
      </zencoder>
    </configuration>

## Enumerations

I've gone ahead and enumerated most things that are enumarble. All the tests are passing, but
the JSON converters I've written haven't been put through the paces as well as I'd like for it
to be "production ready". If something fails because I didn't define an enum flag or there is just
a bug in one of the custom converters, please let me know! I'd love to get some more test coverage
in there as well.

## License

Licensed under the [MIT](http://www.opensource.org/licenses/mit-license.html) license. See LICENSE.txt.

Copyright (c) 2010 Chad Burggraf. 