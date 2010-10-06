# Zencoder .NET
#### A .NET C# client library for the [zencoder.com](http://zencoder.com/) API

Visit <http://zencoder.com/docs/api> for full API documentation.

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

## Still Missing

 - Thumbnail support
 - Notification support
 - Enumerations of all of the possible state/status flags
 - S3 access control lists
 
I'm actively working on these things.

## License

Licensed under the [MIT](http://www.opensource.org/licenses/mit-license.html) license. See LICENSE.txt.

Copyright (c) 2010 Chad Burggraf. 