//-----------------------------------------------------------------------
// <copyright file="AspectMode.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the possible output video aspect modes.
    /// </summary>
    [JsonConverter(typeof(EnumLowercaseJsonConverter))]
    public enum AspectMode
    {
        /// <summary>
        /// Identifies that the input aspect ratio is preserved.
        /// </summary>
        Preserve = 0,

        /// <summary>
        /// Identifies that the output will be stretched to fit the specified size, even if distortion occurs.
        /// </summary>
        Stretch,

        /// <summary>
        /// Identifies that the output will be cropped to fit the specified size.
        /// Equivalent to "pan and scan".
        /// </summary>
        Crop,

        /// <summary>
        /// Identifies that the output will be letterboxed to match the specified size exactly.
        /// </summary>
        Pad
    }
}
