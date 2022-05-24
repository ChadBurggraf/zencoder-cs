//-----------------------------------------------------------------------
// <copyright file="OutputState.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the possible <see cref="OutputMediaFile"/> states.
    /// </summary>
    [JsonConverter(typeof(EnumLowercaseUnderscoreJsonConverter))]
    public enum OutputState
    {
        /// <summary>
        /// Identifies that an unkown output state was received from the service.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Identifies that the output is being assigned.
        /// </summary>
        Assigning = 1,

        /// <summary>
        /// Identifies that the job the output belongs to has been cancelled.
        /// </summary>
        Cancelled = 2,

        /// <summary>
        /// Identifies that the output failed to complete.
        /// </summary>
        Failed = 3,

        /// <summary>
        /// Identifies that the output is finished.
        /// </summary>
        Finished = 4,

        /// <summary>
        /// Identifies that the output did not define an input.
        /// </summary>
        NoInput = 5,

        /// <summary>
        /// Identifies that the output is processing.
        /// </summary>
        Processing = 6,

        /// <summary>
        /// Identifies that the output is queued for processing.
        /// </summary>
        Queued = 7,

        /// <summary>
        /// Identifies that the output is waiting to be queued.
        /// </summary>
        Waiting = 8
    }
}
