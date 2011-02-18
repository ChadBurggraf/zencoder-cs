//-----------------------------------------------------------------------
// <copyright file="OutputMediaFile.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Represents a single output media file in a <see cref="Job"/>.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class OutputMediaFile : MediaFile
    {
        /// <summary>
        /// Gets or sets the file's state with respect to its parent job.
        /// </summary>
        [JsonProperty("state")]
        public OutputState State { get; set; }
    }
}
