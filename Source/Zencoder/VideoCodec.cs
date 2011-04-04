//-----------------------------------------------------------------------
// <copyright file="VideoCodec.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the possible output video codecs.
    /// </summary>
    [JsonConverter(typeof(EnumLowercaseJsonConverter))]
    public enum VideoCodec
    {
        /// <summary>
        /// Identifies the H.264 codec.
        /// </summary>
        H264 = 0,

        /// <summary>
        /// Identifies the MPEG4 codec.
        /// </summary>
        Mpeg4,

        /// <summary>
        /// Identifies the Theora codec.
        /// </summary>
        Theora,

        /// <summary>
        /// Identifies the VP6 codec.
        /// </summary>
        VP6,

        /// <summary>
        /// Identifies the VP8 codec.
        /// </summary>
        VP8,

        /// <summary>
        /// Identifies the WMV codec.
        /// </summary>
        Wmv
    }
}
