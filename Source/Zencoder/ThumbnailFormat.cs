//-----------------------------------------------------------------------
// <copyright file="ThumbnailFormat.cs" company="Tasty Codes">
//     Copyright (c) 2011 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the possible thumbnail image formats.
    /// </summary>
    [JsonConverter(typeof(EnumLowercaseJsonConverter))]
    public enum ThumbnailFormat
    {
        /// <summary>
        /// Identifies the PNG thumbnail format.
        /// </summary>
        Png = 0,

        /// <summary>
        /// Identifies the JPEG thumbnail format.
        /// </summary>
        Jpg
    }
}
