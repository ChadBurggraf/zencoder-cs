//-----------------------------------------------------------------------
// <copyright file="InputState.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the possible <see cref="InputMediaFile"/> states.
    /// </summary>
    [JsonConverter(typeof(EnumLowercaseUnderscoreJsonConverter))]
    public enum InputState
    {
        /// <summary>
        /// Identifies that an unkown input state was received from the service.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Identifies that the job the input belongs to has been cancelled.
        /// </summary>
        Cancelled,

        /// <summary>
        /// Identifies that the input failed to complete.
        /// </summary>
        Failed,

        /// <summary>
        /// Identifies that the input is finished.
        /// </summary>
        Finished,

        /// <summary>
        /// Identifies that the input is pending.
        /// </summary>
        Pending,

        /// <summary>
        /// Identifies that the input is processing.
        /// </summary>
        Processing,

        /// <summary>
        /// Identifies that the input is waiting to be queued.
        /// </summary>
        Waiting
    }
}
