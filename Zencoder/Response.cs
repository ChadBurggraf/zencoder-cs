

namespace Zencoder
{
    using System;
    using System.Net;
    using System.Runtime.Serialization;

    [DataContract(Name = Response.ContractName)]
    public abstract class Response
    {
        private string[] errors;

        /// <summary>
        /// Gets the name of response data contracts.
        /// </summary>
        protected const string ContractName = "api-response";

        /// <summary>
        /// Gets or sets the error collection that was returned in the response.
        /// </summary>
        [DataMember(Name = "errors")]
        public string[] Errors
        {
            get { return this.errors ?? (this.errors = new string[0]); }
            set { this.errors = value; }
        }

        /// <summary>
        /// Gets the HTTP status code that was returned in the response.
        /// </summary>
        public HttpStatusCode StatusCode { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether the request was successful.
        /// </summary>
        public virtual bool Success
        {
            get { return this.StatusCode == HttpStatusCode.OK; }
        }
    }
}