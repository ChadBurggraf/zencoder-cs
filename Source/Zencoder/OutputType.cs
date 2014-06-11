//-----------------------------------------------------------------------
// <copyright file="OutputType.cs" company="Tasty Codes">
//     Copyright (c) 2011 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel;
using System.Runtime.Serialization;
using Newtonsoft.Json.Converters;

namespace Zencoder
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the possible output types.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OutputType
    {
        /// <summary>
        /// Identifies standard output.
        /// </summary>
        [EnumMember(Value = "standard")]
        Standard = 0,

        /// <summary>
        /// Identifies segmented output for Apple HTTP Live Streaming.
        /// </summary>
        [EnumMember(Value = "segmented")]
        Segmented,

        /// <summary>
        /// Identifies that the output is the master M3U8 file
        /// for a multi-bitrate output stream. Cannot be the only
        /// output for a job.
        /// </summary>
        [EnumMember(Value = "playlist")]
        Playlist,

        /// <summary>
        /// Identifies a transfer-only job, v2 API only.
        /// </summary>
        [EnumMember(Value = "transfer-only")]
        TransferOnly
    }
}
