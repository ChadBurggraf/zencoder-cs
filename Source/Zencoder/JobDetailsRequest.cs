//-----------------------------------------------------------------------
// <copyright file="JobDetailsRequest.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using System.Globalization;
    using System.Web;
    using Newtonsoft.Json;

    /// <summary>
    /// Implements the job details request.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class JobDetailsRequest : Request<JobDetailsRequest, JobDetailsResponse>
    {
        private Uri url;

        /// <summary>
        /// Initializes a new instance of the JobDetailsRequest class.
        /// </summary>
        /// <param name="zencoder">The <see cref="Zencoder"/> service to create the request with.</param>
        public JobDetailsRequest(Zencoder zencoder)
            : base(zencoder)
        {
        }

        /// <summary>
        /// Initializes a new instance of the JobDetailsRequest class.
        /// </summary>
        /// <param name="apiKey">The API key to use when connecting to the service.</param>
        /// <param name="baseUrl">The service base URL.</param>
        public JobDetailsRequest(string apiKey, Uri baseUrl)
            : base(apiKey, baseUrl)
        {
        }

        /// <summary>
        /// Gets or sets the ID of the job to get details for.
        /// </summary>
        public int JobId { get; set; }

        /// <summary>
        /// Gets the concrete URL this request will call.
        /// </summary>
        public override Uri Url
        {
            get 
            {
                if (this.JobId < 1)
                {
                    throw new InvalidOperationException("JobId must be set before generating the request URL.");
                }

                return this.url ?? (this.url = BaseUrl.AppendPath(string.Concat("jobs/", this.JobId)).WithApiKey(ApiKey)); 
            }
        }

        /// <summary>
        /// Gets the HTTP verb to use when making the request.
        /// </summary>
        public override string Verb
        {
            get { return "GET"; }
        }
    }
}
