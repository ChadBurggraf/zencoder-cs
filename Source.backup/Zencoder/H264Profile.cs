//-----------------------------------------------------------------------
// <copyright file="H264Profile.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the possible H264 profiles.
    /// </summary>
    [JsonConverter(typeof(EnumLowercaseJsonConverter))]
    public enum H264Profile
    {
        /// <summary>
        /// Identifies the baseline profile.
        /// </summary>
        Baseline = 0,

        /// <summary>
        /// Identifies the main profile.
        /// </summary>
        Main,

        /// <summary>
        /// Identifies the high profile.
        /// </summary>
        High
    }
}
