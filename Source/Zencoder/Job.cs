//-----------------------------------------------------------------------
// <copyright file="Job.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Represents an encoding job when getting job details and/or listing jobs.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Job
    {
        private OutputMediaFile[] outputMediaFiles;
        private Thumbnail[] thumbnails;

        /// <summary>
        /// Gets or sets the date the job was created.
        /// </summary>
        [JsonProperty("created_at")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the number of simultaneous connections for Zencoder to use when
        /// downloading in input file. When not specified, defaults to 5. Valid values range
        /// from 0 to 25.
        /// </summary>
        [JsonProperty("download_connections", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? DownloadConnections { get; set; }

        /// <summary>
        /// Gets or sets the date the job was finished.
        /// </summary>
        [JsonProperty("finished_at")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime? FinishedAt { get; set; }

        /// <summary>
        /// Gets or sets an arbtrary string value to create a grouping for reporting purposes.
        /// </summary>
        [JsonProperty("grouping", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Grouping { get; set; }

        /// <summary>
        /// Gets or sets the job ID.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the job's input media file.
        /// </summary>
        [JsonProperty("input_media_file")]
        public InputMediaFile InputMediaFile { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to mock the job, 
        /// returning the normal response without actually creating a job.
        /// </summary>
        [JsonProperty("mock", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(BooleanConverter))]
        public bool? Mock { get; set; }

        /// <summary>
        /// Gets or sets the job's output media files.
        /// </summary>
        [JsonProperty("output_media_files")]
        public OutputMediaFile[] OutputMediaFiles
        {
            get { return this.outputMediaFiles ?? (this.outputMediaFiles = new OutputMediaFile[0]); }
            set { this.outputMediaFiles = value; }
        }

        /// <summary>
        /// Gets or sets an optional arbitrary string value to stor alongside the job.
        /// </summary>
        [JsonProperty("pass_through", DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string PassThrough { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether privacy mode is enabled for the job.
        /// </summary>
        [JsonProperty("private", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(BooleanConverter))]
        public bool? Private { get; set; }

        /// <summary>
        /// Gets or sets the current job state.
        /// </summary>
        [JsonProperty("state")]
        public JobState State { get; set; }

        /// <summary>
        /// Gets or sets the date the job was submitted.
        /// </summary>
        [JsonProperty("submitted_at")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime SubmittedAt { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the job is in test mode.
        /// </summary>
        [JsonProperty("test")]
        [JsonConverter(typeof(BooleanConverter))]
        public bool Test { get; set; }

        /// <summary>
        /// Gets or sets the job's thumbnails.
        /// </summary>
        [JsonProperty("thumbnails")]
        public Thumbnail[] Thumbnails
        {
            get { return this.thumbnails ?? (this.thumbnails = new Thumbnail[0]); }
            set { this.thumbnails = value; }
        }

        /// <summary>
        /// Gets or sets the date the job was last updated.
        /// </summary>
        [JsonProperty("updated_at")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime UpdatedAt { get; set; }
    }
}
