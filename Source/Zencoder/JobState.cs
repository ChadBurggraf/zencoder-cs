//-----------------------------------------------------------------------
// <copyright file="JobState.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    /// <summary>
    /// Defines the possible <see cref="Job"/> states.
    /// </summary>
    public enum JobState
    {
        /// <summary>
        /// Identifies that the job has been cancelled.
        /// </summary>
        Cancelled,

        /// <summary>
        /// Identifies that the job failed to complete.
        /// </summary>
        Failed,

        /// <summary>
        /// Identifies that the job is finished.
        /// </summary>
        Finished,

        /// <summary>
        /// Identifies that the job is processing.
        /// </summary>
        Processing,

        /// <summary>
        /// Identifies that the job is queued for processing.
        /// </summary>
        Queued
    }
}
