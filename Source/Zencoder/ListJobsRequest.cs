//-----------------------------------------------------------------------
// <copyright file="ListJobsRequest.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Web;
    using Newtonsoft.Json;

    /// <summary>
    /// Implements the list jobs request.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ListJobsRequest : Request<ListJobsRequest, ListJobsResponse>
    {
        private int? pageNumber, pageSize;
        private Uri url;

        /// <summary>
        /// Initializes a new instance of the ListJobsRequest class.
        /// </summary>
        /// <param name="zencoder">The <see cref="Zencoder"/> service to create the request with.</param>
        public ListJobsRequest(Zencoder zencoder)
            : base(zencoder)
        {
        }

        /// <summary>
        /// Initializes a new instance of the ListJobsRequest class.
        /// </summary>
        /// <param name="apiKey">The API key to use when connecting to the service.</param>
        /// <param name="baseUrl">The service base URL.</param>
        public ListJobsRequest(string apiKey, Uri baseUrl)
            : base(apiKey, baseUrl)
        {
        }

        /// <summary>
        /// Gets or sets the page number to list.
        /// </summary>
        public int PageNumber
        {
            get
            {
                return (int)(this.pageNumber ?? (this.pageNumber = 1));
            }

            set
            {
                if (value < 1)
                {
                    this.pageNumber = 1;
                }
                else
                {
                    this.pageNumber = value;
                }

                this.url = null;
            }
        }

        /// <summary>
        /// Gets or sets the page size to list.
        /// </summary>
        public int PageSize
        {
            get
            {
                return (int)(this.pageSize ?? (this.pageSize = 50));
            }

            set
            {
                if (value < 1)
                {
                    this.pageSize = 1;
                }
                else
                {
                    this.pageSize = value;
                }

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
                    string query = string.Format(
                        CultureInfo.InvariantCulture,
                        "{0}={1}&page={2}&per_page={3}",
                        HttpUtility.UrlEncode(Zencoder.ApiKeyQueryKey),
                        ApiKey,
                        this.PageNumber,
                        this.PageSize);

                    this.url = BaseUrl.AppendPath("jobs").WithQueryString(query);
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

        /// <summary>
        /// Sets this isntance's paging properties.
        /// </summary>
        /// <param name="pageNumber">The page number to set, or null to reset to the default.</param>
        /// <param name="pageSize">The page size to set, or null to reset to the default.</param>
        /// <returns>This instance.</returns>
        public ListJobsRequest ForPage(int? pageNumber, int? pageSize)
        {
            this.pageNumber = this.pageSize = null;

            if (pageNumber != null)
            {
                this.PageNumber = pageNumber.Value;
            }

            if (pageSize != null)
            {
                this.PageSize = pageSize.Value;
            }

            return this;
        }
    }
}
