//-----------------------------------------------------------------------
// <copyright file="OutputEvent.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the possible <see cref="Output"/> progress events.
    /// </summary>
    [JsonConverter(typeof(EnumLowercaseUnderscoreJsonConverter))]
    public enum OutputEvent
    {
        /// <summary>
        /// Identifies that an unkown output event was received from the service.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Identifies that the input is being downloaded.
        /// </summary>
        Downloading,

        /// <summary>
        /// Identifies that the input is being inspected.
        /// </summary>
        Inspecting,

        /// <summary>
        /// Identifies that the output is being transcoded.
        /// </summary>
        Transcoding,

        /// <summary>
        /// Identifies that the output is being uploaded.
        /// </summary>
        Uploading
    }
}
