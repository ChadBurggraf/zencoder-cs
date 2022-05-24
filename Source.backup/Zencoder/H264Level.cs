//-----------------------------------------------------------------------
// <copyright file="H264Level.cs" company="Tasty Codes">
//     Copyright (c) 2011 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using System.ComponentModel;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the possible H264 levels.
    /// </summary>
    [JsonConverter(typeof(EnumDescriptionConverter))]
    public enum H264Level
    {
        /// <summary>
        /// Identifies level 3.
        /// </summary>
        [Description("3")]
        Three = 0,

        /// <summary>
        /// Identifies level 1.
        /// </summary>
        [Description("1")]
        One,

        /// <summary>
        /// Identifies level 1b.
        /// </summary>
        [Description("1b")]
        OneB,

        /// <summary>
        /// Identifies level 1.1.
        /// </summary>
        [Description("1.1")]
        OnePointOne,

        /// <summary>
        /// Identifies level 1.2.
        /// </summary>
        [Description("1.2")]
        OnePointTwo,

        /// <summary>
        /// Identifies level 1.3.
        /// </summary>
        [Description("1.3")]
        OnePointThree,

        /// <summary>
        /// Identifies level 2.
        /// </summary>
        [Description("2")]
        Two,

        /// <summary>
        /// Identifies level 2.1.
        /// </summary>
        [Description("2.1")]
        TwoPointOne,

        /// <summary>
        /// Identifies level 2.2.
        /// </summary>
        [Description("2.2")]
        TwoPointTwo,

        /// <summary>
        /// Identifies level 3.1.
        /// </summary>
        [Description("3.1")]
        ThreePointOne,

        /// <summary>
        /// Identifies level 3.2.
        /// </summary>
        [Description("3.2")]
        ThreePointTwo,

        /// <summary>
        /// Identifies level 4.
        /// </summary>
        [Description("4")]
        Four,

        /// <summary>
        /// Identifies level 4.1.
        /// </summary>
        [Description("4.1")]
        FourPointOne,

        /// <summary>
        /// Identifies level 4.2.
        /// </summary>
        [Description("4.2")]
        FourPointTwo,

        /// <summary>
        /// Identifies level 5.
        /// </summary>
        [Description("5")]
        Five,

        /// <summary>
        /// Identifies level 5.1.
        /// </summary>
        [Description("5.1")]
        FivePointOne
    }
}
