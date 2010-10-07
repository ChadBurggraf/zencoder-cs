//-----------------------------------------------------------------------
// <copyright file="OutputEvent.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;

    /// <summary>
    /// Defines the possible <see cref="Output"/> progress events.
    /// </summary>
    public enum OutputEvent
    {
        /// <summary>
        /// Identifies that the input is being downloaded.
        /// </summary>
        Downloading,

        /// <summary>
        /// Identifies that the input is being inspected.
        /// </summary>
        Inspecting,

        /// <summary>
        /// Identifies that the output is being transcoded.
        /// </summary>
        Transcoding,

        /// <summary>
        /// Identifies that the output is being uploaded.
        /// </summary>
        Uploading
    }
}
