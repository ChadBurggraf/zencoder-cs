//-----------------------------------------------------------------------
// <copyright file="CreateJobResponse.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using System.Net;
    using Newtonsoft.Json;

    /// <summary>
    /// Implements the create encoding job response.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class CreateJobResponse : Response<CreateJobRequest, CreateJobResponse>
    {
        /// <summary>
        /// Gets or sets the job ID.
        /// </summary>
        [JsonProperty("id")]
        [JsonConverter(typeof(DefaultingIntegerConverter))]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the response output collection.
        /// </summary>
        [JsonProperty("outputs")]
        public ResponseOutput[] Outputs { get; set; }

        /// <summary>
        /// Gets a value indicating whether the request was successful.
        /// </summary>
        public override bool Success
        {
            get { return RequestException == null && StatusCode == HttpStatusCode.Created; }
        }
    }
}