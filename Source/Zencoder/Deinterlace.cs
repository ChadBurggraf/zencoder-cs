//-----------------------------------------------------------------------
// <copyright file="Deinterlace.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;

    /// <summary>
    /// Defines the possible deinterlacing behaviors.
    /// </summary>
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
