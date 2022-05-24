//-----------------------------------------------------------------------
// <copyright file="Deinterlace.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the possible deinterlacing behaviors.
    /// </summary>
    [JsonConverter(typeof(EnumLowercaseJsonConverter))]
    public enum Deinterlace
    {
        /// <summary>
        /// Identifies that deinterlacing is the same as the input video.
        /// </summary>
        Detect = 0,

        /// <summary>
        /// Identifies that deinterlacing is on.
        /// </summary>
        On,

        /// <summary>
        /// Identifies that deinterlacing is off.
        /// </summary>
        Off
    }
}
