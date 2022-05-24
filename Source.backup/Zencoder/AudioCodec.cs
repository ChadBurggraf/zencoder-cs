//-----------------------------------------------------------------------
// <copyright file="AudioCodec.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the possible output audio codecs.
    /// </summary>
    [JsonConverter(typeof(EnumLowercaseJsonConverter))]
    public enum AudioCodec
    {
        /// <summary>
        /// Identifies the AAC audio codec.
        /// </summary>
        Aac = 0,

        /// <summary>
        /// Identifies the AMR audio codec.
        /// </summary>
        Amr,

        /// <summary>
        /// Identifies that MP3 audio codec.
        /// </summary>
        Mp3,

        /// <summary>
        /// Identifies the Vorbis audio codec.
        /// </summary>
        Vorbis,

        /// <summary>
        /// Identifies the WMA audio codec.
        /// </summary>
        Wma
    }
}
