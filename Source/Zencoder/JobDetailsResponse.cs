

namespace Zencoder
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Implements the job details response.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class JobDetailsResponse : Response<JobDetailsRequest, JobDetailsResponse>
    {
        /// <summary>
        /// Gets or sets the job returned with the response.
        /// </summary>
        [JsonProperty("job")]
        public Job Job { get; set; }
    }
}
