//-----------------------------------------------------------------------
// <copyright file="Tuning.cs" company="Tasty Codes">
//     Copyright (c) 2011 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using Newtonsoft.Json;
    
    /// <summary>
    /// Defines the possible H264 tuning values.
    /// </summary>
    [JsonConverter(typeof(EnumLowercaseJsonConverter))]
    public enum Tuning
    {
        /// <summary>
        /// Optimizes for most non-animated video.
        /// </summary>
        Film,

        /// <summary>
        /// Optimizes for animation.
        /// </summary>
        Animation,

        /// <summary>
        /// Optimizes for film with high levels of grain.
        /// </summary>
        Grain,

        /// <summary>
        /// Uses peak signal-to-noise ratio to optimize quality.
        /// </summary>
        Psnr,

        /// <summary>
        /// Uses structural similarity to optimize quality.
        /// </summary>
        Ssim,

        /// <summary>
        /// Reduces encoding complexity to allow for easier decoding.
        /// </summary>
        FastDecode,

        /// <summary>
        /// Removes the internal H264 buffer to improve quality.
        /// </summary>
        ZeroLatency
    }
}
