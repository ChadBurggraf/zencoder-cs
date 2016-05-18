//-----------------------------------------------------------------------
// <copyright file="JobState.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the possible <see cref="Job"/> states.
    /// </summary>
    [JsonConverter(typeof(EnumLowercaseUnderscoreJsonConverter))]
    public enum JobState
    {
        /// <summary>
        /// Identifies that an unkown job state was received from the service.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Identifies that the job has been cancelled.
        /// </summary>
        Cancelled = 1,

        /// <summary>
        /// Identifies that the job failed to complete.
        /// </summary>
        Failed = 2,

        /// <summary>
        /// Identifies that the job is finished.
        /// </summary>
        Finished = 3,

        /// <summary>
        /// Identifies that the job is pending.
        /// </summary>
        Pending = 4,

        /// <summary>
        /// Identifies that the job is processing.
        /// </summary>
        Processing = 5,

        /// <summary>
        /// Identifies that the job is waiting to be queued.
        /// </summary>
        Waiting = 6
    }
}
