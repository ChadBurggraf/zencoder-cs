//-----------------------------------------------------------------------
// <copyright file="JobProgressRequest.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using System.Globalization;
    using Newtonsoft.Json;

    /// <summary>
    /// Implements the job progress request.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class JobProgressRequest : Request<JobProgressRequest, JobProgressResponse>
    {
        private int outputId;
        private Uri url;

        /// <summary>
        /// Initializes a new instance of the JobProgressRequest class.
        /// </summary>
        /// <param name="zencoder">The <see cref="Zencoder"/> service to create the request with.</param>
        public JobProgressRequest(Zencoder zencoder)
            : base(zencoder)
        {
        }

        /// <summary>
        /// Initializes a new instance of the JobProgressRequest class.
        /// </summary>
        /// <param name="apiKey">The API key to use when connecting to the service.</param>
        /// <param name="baseUrl">The service base URL.</param>
        public JobProgressRequest(string apiKey, Uri baseUrl)
            : base(apiKey, baseUrl)
        {
        }

        /// <summary>
        /// Gets or sets the ID of the <see cref="Output"/> to get progress for.
        /// </summary>
        public int OutputId
        {
            get
            {
                return this.outputId;
            }

            set
            {
                this.outputId = value;
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
                    if (this.OutputId < 1)
                    {
                        throw new InvalidOperationException("OutputId must be set before generating the request URL.");
                    }

                    string path = string.Format(CultureInfo.InvariantCulture, "outputs/{0}/progress", this.OutputId);
                    this.url = BaseUrl.AppendPath(path).WithApiKey(ApiKey);
                }

                return this.url;
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
