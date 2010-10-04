
namespace Zencoder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;

    /// <summary>
    /// Implements the create encoding job request.
    /// </summary>
    [DataContract(Name = Request.ContractName)]
    [KnownType(typeof(Output))]
    public class CreateJobRequest : Request<CreateJobRequest, CreateJobResponse>
    {
        private int? downloadConnections;
        private Output[] outputs;

        /// <summary>
        /// Initializes a new instance of the CreateJobRequest class.
        /// </summary>
        /// <param name="zencoder">The <see cref="Zencoder"/> service to create the request with.</param>
        public CreateJobRequest(Zencoder zencoder)
            : base(zencoder)
        {
        }

        /// <summary>
        /// Initializes a new instance of the CreateJobRequest class.
        /// </summary>
        /// <param name="apiKey">The API key to use when connecting to the service.</param>
        /// <param name="baseUrl">The service base URL.</param>
        public CreateJobRequest(string apiKey, Uri baseUrl)
            : base(apiKey, baseUrl)
        {
        }

        /// <summary>
        /// Gets or sets the number of connections to use when downloading the input file.
        /// Defaults to 5. Maximum allowed is 25.
        /// </summary>
        [DataMember(Name = "download_connections", EmitDefaultValue = false)]
        public int? DownloadConnections
        {
            get
            {
                return this.downloadConnections;
            }

            set
            {
                if (value != null && value < 1)
                {
                    this.downloadConnections = 1;
                }
                else if (value != null && value > 25)
                {
                    this.downloadConnections = 25;
                }
                else
                {
                    this.downloadConnections = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the URL of the audo or video file to process.
        /// </summary>
        [DataMember(Name = "input")]
        public string Input { get; set; }

        /// <summary>
        /// Gets or sets the output collection definiing outputs for the job.
        /// </summary>
        [DataMember(Name = "outputs")]
        public Output[] Outputs
        {
            get { return this.outputs ?? (this.outputs = new Output[0]); }
            set { this.outputs = value; }
        }

        /// <summary>
        /// Gets or sets the region to use when processing the job.
        /// Defaults to "us".
        /// </summary>
        [DataMember(Name = "region", EmitDefaultValue = false)]
        public string Region { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether test mode is enabled for the job.
        /// Use 1 for true, 0 for false.
        /// </summary>
        [DataMember(Name = "test", EmitDefaultValue = false)]
        public int? Test { get; set; }

        /// <summary>
        /// Gets the concrete URL this request will call.
        /// </summary>
        public override Uri Url
        {
            get { return BaseUrl.AppendPath("jobs"); }
        }

        /// <summary>
        /// Gets the HTTP verb to use when making the request.
        /// </summary>
        public override string Verb
        {
            get { return "POST"; }
        }

        /// <summary>
        /// Sets the value of this instanc's <see cref="Input"/> URL.
        /// </summary>
        /// <param name="url">The URL to set.</param>
        /// <returns>This instance.</returns>
        public CreateJobRequest WithInputUrl(Uri url)
        {
            this.Input = url.ToString();
            return this;
        }

        /// <summary>
        /// Appends an <see cref="Output"/> to this instance's <see cref="Outputs"/> collection.
        /// </summary>
        /// <param name="output">The output to append.</param>
        /// <returns>This instance.</returns>
        public CreateJobRequest WithOutput(Output output)
        {
            if (output != null)
            {
                return this.WithOutputs(new Output[] { output });
            }

            return this;
        }

        /// <summary>
        /// Appends a collection <see cref="Output"/>s to this instance's <see cref="Outputs"/> collection.
        /// </summary>
        /// <param name="outputs">The outputs to append.</param>
        /// <returns>This instance.</returns>
        public CreateJobRequest WithOutputs(IEnumerable<Output> outputs)
        {
            if (outputs != null)
            {
                this.Outputs = this.Outputs.Concat(outputs).ToArray();
            }

            return this;
        }
    }
}