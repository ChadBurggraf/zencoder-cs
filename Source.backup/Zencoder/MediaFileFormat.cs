//-----------------------------------------------------------------------
// <copyright file="MediaFileFormat.cs" company="Tasty Codes">
//     Copyright (c) 2011 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using System.ComponentModel;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the possible media file format containers.
    /// </summary>
    [JsonConverter(typeof(EnumDescriptionConverter))]
    public enum MediaFileFormat
    {
        /// <summary>
        /// Identifies the MP4 format.
        /// </summary>
        [Description("mp4")]
        MPFour = 0,

        /// <summary>
        /// Identifies the 3G2 format.
        /// </summary>
        [Description("3g2")]
        ThreeGTwo,

        /// <summary>
        /// Identifies the 3GP format.
        /// </summary>
        [Description("3gp")]
        ThreeGP,

        /// <summary>
        /// Identifies the 3GP2 format.
        /// </summary>
        [Description("3gp2")]
        ThreeGP2,

        /// <summary>
        /// Identifies the 3GPP format.
        /// </summary>
        [Description("3gpp")]
        ThreeGPP,

        /// <summary>
        /// Identifies the 3GPP2 format.
        /// </summary>
        [Description("3gpp2")]
        ThreeGPP2,

        /// <summary>
        /// Identifies the F4A format.
        /// </summary>
        [Description("f4a")]
        FFourA,

        /// <summary>
        /// Identifies the F4B format.
        /// </summary>
        [Description("f4b")]
        FFourB,

        /// <summary>
        /// Identifies the F4V format.
        /// </summary>
        [Description("f4v")]
        FFourV,

        /// <summary>
        /// Identifies the FLV format.
        /// </summary>
        [Description("flv")]
        FLV,

        /// <summary>
        /// Identifies the M4A format.
        /// </summary>
        [Description("m4a")]
        MFourA,

        /// <summary>
        /// Identifies the M4B format.
        /// </summary>
        [Description("m4b")]
        MFourB,

        /// <summary>
        /// Identifies the M4R format.
        /// </summary>
        [Description("m4r")]
        MFourR,

        /// <summary>
        /// Identifies the M4V format.
        /// </summary>
        [Description("m4v")]
        MFourV,

        /// <summary>
        /// Identifies the MOV format.
        /// </summary>
        [Description("mov")]
        MOV,

        /// <summary>
        /// Identifies the MP3 format.
        /// </summary>
        [Description("mp3")]
        MPThree,

        /// <summary>
        /// Identifies the OGA format.
        /// </summary>
        [Description("oga")]
        OGA,

        /// <summary>
        /// Identifies the OGG format.
        /// </summary>
        [Description("ogg")]
        OGG,

        /// <summary>
        /// Identifies the OGV format.
        /// </summary>
        [Description("ogv")]
        OGV,

        /// <summary>
        /// Identifies the OGX format.
        /// </summary>
        [Description("ogx")]
        OGX,

        /// <summary>
        /// Identifies a segmented media file.
        /// </summary>
        [Description("ts")]
        TS,

        /// <summary>
        /// Identifies the WEBM format.
        /// </summary>
        [Description("webm")]
        WEBM,

        /// <summary>
        /// Identifies the WMA format.
        /// </summary>
        [Description("wma")]
        WMA,

        /// <summary>
        /// Identifies the WMV format.
        /// </summary>
        [Description("wmv")]
        WMV
    }
}
