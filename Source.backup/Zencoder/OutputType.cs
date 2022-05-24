//-----------------------------------------------------------------------
// <copyright file="OutputType.cs" company="Tasty Codes">
//     Copyright (c) 2011 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the possible output types.
    /// </summary>
    [JsonConverter(typeof(EnumLowercaseJsonConverter))]
    public enum OutputType
    {
        /// <summary>
        /// Identifies standard output.
        /// </summary>
        Standard = 0,

        /// <summary>
        /// Identifies segmented output for Apple HTTP Live Streaming.
        /// </summary>
        Segmented,

        /// <summary>
        /// Identifies that the output is the master M3U8 file
        /// for a multi-bitrate output stream. Cannot be the only
        /// output for a job.
        /// </summary>
        Playlist
    }
}
