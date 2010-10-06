//-----------------------------------------------------------------------
// <copyright file="JobWrapper.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Wraps a <see cref="Job"/> object for proper deserialization in a <see cref="ListJobsResponse"/>.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class JobWrapper
    {
        /// <summary>
        /// Gets or sets the wrapper's job object.
        /// </summary>
        [JsonProperty("job")]
        public Job Job { get; set; }
    }
}
