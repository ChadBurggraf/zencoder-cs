//-----------------------------------------------------------------------
// <copyright file="ListJobsResponse.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;

    /// <summary>
    /// Implements the list jobs response.
    /// </summary>
    [FromJsonStream(Method = "FromJson", Type = typeof(ListJobsResponse))]
    [FromJsonString(Method = "FromJson", Type = typeof(ListJobsResponse))]
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ListJobsResponse : Response<ListJobsRequest, ListJobsResponse>
    {
        private Job[] jobs;

        /// <summary>
        /// Gets or sets the jobs returned with the response.
        /// </summary>
        public Job[] Jobs
        {
            get { return this.jobs ?? (this.jobs = new Job[0]); }
            set { this.jobs = value; }
        }

        /// <summary>
        /// Creates a new <see cref="Response"/> instance from the given JSON string.
        /// </summary>
        /// <param name="json">A string of JSON representing the response.</param>
        /// <returns>A <see cref="Response"/>.</returns>
        public static new ListJobsResponse FromJson(string json)
        {
            return new ListJobsResponse() 
            {
                Jobs = JsonConvert.DeserializeObject<JobWrapper[]>(json).Select(j => j.Job).ToArray()
            };
        }

        /// <summary>
        /// Creates a new <see cref="Response"/> instance from the JSON data in the given stream.
        /// </summary>
        /// <param name="stream">The stream to create the response from.</param>
        /// <returns>A <see cref="Response"/>.</returns>
        public static new ListJobsResponse FromJson(Stream stream)
        {
            JsonSerializer serializer = new JsonSerializer();

            using (StreamReader sr = new StreamReader(stream))
            {
                using (JsonReader jr = new JsonTextReader(sr))
                {
                    return new ListJobsResponse() 
                    {
                        Jobs = serializer.Deserialize<JobWrapper[]>(jr).Select(j => j.Job).ToArray()
                    };
                }
            }
        }
    }
}
