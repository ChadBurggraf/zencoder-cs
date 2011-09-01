//-----------------------------------------------------------------------
// <copyright file="DeleteJobRequest.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Implements the delete job request.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class DeleteJobRequest : Request<DeleteJobRequest, DeleteJobResponse>
    {
        private int jobId;
        private Uri url;

        /// <summary>
        /// Initializes a new instance of the DeleteJobRequest class.
        /// </summary>
        /// <param name="zencoder">The <see cref="Zencoder"/> service to create the request with.</param>
        public DeleteJobRequest(Zencoder zencoder)
            : base(zencoder)
        {
        }

        /// <summary>
        /// Initializes a new instance of the DeleteJobRequest class.
        /// </summary>
        /// <param name="apiKey">The API key to use when connecting to the service.</param>
        /// <param name="baseUrl">The service base URL.</param>
        public DeleteJobRequest(string apiKey, Uri baseUrl)
            : base(apiKey, baseUrl)
        {
        }

        /// <summary>
        /// Gets or sets the ID of the job to delete.
        /// </summary>
        public int JobId
        {
            get 
            { 
                return this.jobId; 
            }

            set 
            {
                this.jobId = value;
                this.url = null;
            }
        }

        /// <summary>
        /// Gets the concrete URL this request will call.
        /// </summary>
        public override Uri Url
        {
            get 
            {
                if (this.url == null)
                {
                    if (this.JobId < 1)
                    {
                        throw new InvalidOperationException("JobId must be set before generating the request URL.");
                    }

                    this.url = BaseUrl.AppendPath(string.Concat("jobs/", this.JobId)).WithApiKey(ApiKey);
                }

                return this.url;
            }
        }

        /// <summary>
        /// Gets the HTTP verb to use when making the request.
        /// </summary>
        public override string Verb
        {
            get { return "DELETE"; }
        }
    }
}
