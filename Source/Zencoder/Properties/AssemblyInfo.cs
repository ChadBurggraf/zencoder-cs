//-----------------------------------------------------------------------
// <copyright file="AssemblyInfo.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("Zencoder .NET")]
[assembly: AssemblyDescription(".NET client library for the Zencoder API.")]
[assembly: Guid("e7c51f55-31dd-4a4c-9842-9b4c2aeef669")]
[assembly: CLSCompliant(true)]


// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

[assembly: InternalsVisibleTo("Zencoder.Test")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]

// Used for NuGet packaging, uses semantic versioning: major.minor.patch-prerelease.
[assembly: AssemblyInformationalVersion("2.0.0")]

// Keep this the same as AssemblyInformationalVersion.
[assembly: AssemblyFileVersion("2.0.0")]

// ONLY change this when the major version changes; never with minor/patch/build versions.
[assembly: AssemblyVersion("2.0.0.0")]