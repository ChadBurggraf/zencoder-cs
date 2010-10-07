//-----------------------------------------------------------------------
// <copyright file="OutputState.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    /// <summary>
    /// Defines the possible <see cref="Output"/> states.
    /// </summary>
    public enum OutputState
    {
        /// <summary>
        /// Identifies that the job the output belongs to has been cancelled.
        /// </summary>
        Cancelled,

        /// <summary>
        /// Identifies that the output failed to complete.
        /// </summary>
        Failed,

        /// <summary>
        /// Identifies that the output is finished.
        /// </summary>
        Finished,

        /// <summary>
        /// Identifies that the output is processing.
        /// </summary>
        Processing,

        /// <summary>
        /// Identifies that the output is queued for processing.
        /// </summary>
        Queued
    }
}
