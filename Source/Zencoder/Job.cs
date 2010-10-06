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
        private MediaFile[] outputMediaFiles;

        /// <summary>
        /// Gets or sets the date the job was created.
        /// </summary>
        [JsonProperty("created_at")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the date the job was finished.
        /// </summary>
        [JsonProperty("finished_at")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime? FinishedAt { get; set; }

        /// <summary>
        /// Gets or sets the job ID.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the job's input media file.
        /// </summary>
        [JsonProperty("input_media_file")]
        public MediaFile InputMediaFile { get; set; }

        /// <summary>
        /// Gets or sets the job's output media files.
        /// </summary>
        [JsonProperty("output_media_files")]
        public MediaFile[] OutputMediaFiles
        {
            get { return this.outputMediaFiles ?? (this.outputMediaFiles = new MediaFile[0]); }
            set { this.outputMediaFiles = value; }
        }

        /// <summary>
        /// Gets or sets the date the job was submitted.
        /// </summary>
        [JsonProperty("submitted_at")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime SubmittedAt { get; set; }

        /// <summary>
        /// Gets or sets the current job state.
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the job is in test mode.
        /// </summary>
        [JsonProperty("test")]
        public bool Test { get; set; }

        /// <summary>
        /// Gets or sets the date the job was last updated.
        /// </summary>
        [JsonProperty("updated_at")]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime UpdatedAt { get; set; }
    }
}
