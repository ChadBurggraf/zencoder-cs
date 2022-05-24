//-----------------------------------------------------------------------
// <copyright file="DenoiseFilter.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Defins the possible denoise filter values.
    /// </summary>
    [JsonConverter(typeof(EnumLowercaseJsonConverter))]
    public enum DenoiseFilter
    {
        /// <summary>
        /// Identifies the weak denoise filter.
        /// </summary>
        Weak,

        /// <summary>
        /// Identifies the medium denoise filter.
        /// </summary>
        Medium,

        /// <summary>
        /// Identifies the strong denoise filter.
        /// </summary>
        Strong,

        /// <summary>
        /// Identifies the strongest denoise filter.
        /// </summary>
        Strongest
    }
}
