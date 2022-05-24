//-----------------------------------------------------------------------
// <copyright file="WatermarkOrigin.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the possible watermark origin values.
    /// </summary>
    [JsonConverter(typeof(EnumLowercaseJsonConverter))]
    public enum WatermarkOrigin
    {
        /// <summary>
        /// Identifies that a watermark placement is based on the visible content
        /// area of an output, not including padding.
        /// </summary>
        Content = 0,

        /// <summary>
        /// Identifies that watermark placement is based on the full resolution
        /// of an output, including any padding.
        /// </summary>
        Frame
    }
}
