//-----------------------------------------------------------------------
// <copyright file="JobTests.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder.Test
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Threading;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Job tests.
    /// </summary>
    [TestClass]
    public class JobTests : TestBase
    {
        #region Jobs Response JSON

        /// <summary>
        /// Test JSON for job details response deserialization.
        /// </summary>
        private const string JobDetailsResponseJson =
            @"{
              ""job"": {
                ""created_at"": ""2010-01-01T00:00:00Z"",
                ""finished_at"": ""2010-01-01T00:00:00Z"",
                ""updated_at"": ""2010-01-01T00:00:00Z"",
                ""submitted_at"": ""2010-01-01T00:00:00Z"",
                ""pass_through"": null,
                ""id"": 1,
                ""input_media_file"": {
                  ""format"": ""mpeg4"",
                  ""created_at"": ""2010-01-01T00:00:00Z"",
                  ""frame_rate"": 29,
                  ""finished_at"": ""2010-01-01T00:00:00Z"",
                  ""updated_at"": ""2010-01-01T00:00:00Z"",
                  ""duration_in_ms"": 24883,
                  ""audio_sample_rate"": 48000,
                  ""url"": ""s3://bucket/test.mp4"",
                  ""id"": 1,
                  ""error_message"": null,
                  ""error_class"": null,
                  ""audio_bitrate_in_kbps"": 95,
                  ""audio_codec"": ""aac"",
                  ""height"": 352,
                  ""file_size_bytes"": 1862748,
                  ""video_codec"": ""h264"",
                  ""test"": false,
                  ""channels"": ""2"",
                  ""width"": 624,
                  ""video_bitrate_in_kbps"": 498,
                  ""state"": ""finished""
                },
                ""test"": false,
                ""output_media_files"": [{
                  ""format"": ""mpeg4"",
                  ""created_at"": ""2010-01-01T00:00:00Z"",
                  ""frame_rate"": 29,
                  ""finished_at"": ""2010-01-01T00:00:00Z"",
                  ""updated_at"": ""2010-01-01T00:00:00Z"",
                  ""duration_in_ms"": 24883,
                  ""audio_sample_rate"": 44100,
                  ""url"": ""http://s3.amazonaws.com/bucket/video.mp4"",
                  ""id"": 1,
                  ""error_message"": null,
                  ""error_class"": null,
                  ""audio_bitrate_in_kbps"": 92,
                  ""audio_codec"": ""aac"",
                  ""height"": 352,
                  ""file_size_bytes"": 1386663,
                  ""video_codec"": ""h264"",
                  ""test"": false,
                  ""channels"": ""2"",
                  ""width"": 624,
                  ""video_bitrate_in_kbps"": 351,
                  ""state"": ""finished"",
                  ""label"": ""Web""
                }],
                ""thumbnails"": [{
                  ""created_at"": ""2010-01-01T00:00:00Z"",
                  ""updated_at"": ""2010-01-01T00:00:00Z"",
                  ""url"": ""http://s3.amazonaws.com/bucket/video/frame_0000.png"",
                  ""id"": 1
                }],
                ""state"": ""finished""
              }
            }";

        /// <summary>
        /// Test JSON for job details response deserialization.
        /// Note additional new test values including: total_bitrate_in_kbps,
        /// non-integer framerate, thumbnail group label, thumbnail format
        /// </summary>
        private const string JobDetailsResponseTestSetTwoJson =
            @"{
              ""job"": {
              ""created_at"": ""2011-04-04T11:21:14-05:00"",
              ""finished_at"": ""2011-04-04T11:22:16-05:00"",
              ""updated_at"": ""2011-04-04T11:22:16-05:00"",
              ""submitted_at"": ""2011-04-04T11:21:14-05:00"",
                ""pass_through"": null,
                ""id"": 1,
                ""input_media_file"": {
                  ""total_bitrate_in_kbps"": 6524,
                  ""format"": ""mpeg4"",
                  ""created_at"": ""2011-04-04T18:21:14+02:00"",
                  ""frame_rate"": 25.05,
                  ""finished_at"": ""2011-04-04T18:21:32+02:00"",
                  ""updated_at"": ""2011-04-04T18:21:32+02:00"",
                  ""duration_in_ms"": 122000,
                  ""audio_sample_rate"": 32000,
                  ""url"": ""http://example.com/test.mp4"",
                  ""id"": 1,
                  ""error_message"": null,
                  ""error_class"": null,
                  ""audio_bitrate_in_kbps"": 1024,
                  ""audio_codec"": ""pcm_s16le"",
                  ""height"": 576,
                  ""file_size_bytes"": 100299080,
                  ""video_codec"": ""h264"",
                  ""test"": true,
                  ""channels"": ""2"",
                  ""width"": 720,
                  ""video_bitrate_in_kbps"": 5500,
                  ""state"": ""finished""
                },
                ""test"": false,
                ""output_media_files"": [{
                  ""total_bitrate_in_kbps"": 586,
                  ""format"": ""mpeg4"",
                  ""created_at"": ""2010-01-01T00:00:00Z"",
                  ""frame_rate"": 29,
                  ""finished_at"": ""2010-01-01T00:00:00Z"",
                  ""updated_at"": ""2010-01-01T00:00:00Z"",
                  ""duration_in_ms"": 5080,
                  ""audio_sample_rate"": 32000,
                  ""url"": ""http://s3.amazonaws.com/bucket/video.mp4"",
                  ""id"": 1,
                  ""error_message"": null,
                  ""error_class"": null,
                  ""audio_bitrate_in_kbps"": 60,
                  ""audio_codec"": ""aac"",
                  ""height"": 360,
                  ""file_size_bytes"": 375236,
                  ""video_codec"": ""h264"",
                  ""test"": false,
                  ""channels"": ""2"",
                  ""width"": 640,
                  ""video_bitrate_in_kbps"": 526,
                  ""state"": ""finished"",
                  ""label"": ""Web""
                }],
                ""thumbnails"": [{
                  ""group_label"": ""group-label-value-1"",
                  ""format"": ""png"",
                  ""created_at"": ""2011-04-04T11:22:16-05:00"",
                  ""updated_at"": ""2011-04-04T11:22:16-05:00"",
                  ""url"": ""http://s3.amazonaws.com/bucket/video/frame_0000.png"",
                  ""id"": 1,
                  ""height"": 360,
                  ""file_size_bytes"": 417387,
                  ""width"": 640
                  },
                  {
                  ""group_label"": ""group-label-value-1"",
                  ""format"": ""png"",
                  ""created_at"": ""2011-04-04T11:22:16-05:00"",
                  ""updated_at"": ""2011-04-04T11:22:16-05:00"",
                  ""url"": ""http://s3.amazonaws.com/bucket/video/frame_0001.png"",
                  ""id"": 5829389,
                  ""height"": 360,
                  ""file_size_bytes"": 382938,
                  ""width"": 640
                }],
                ""state"": ""finished""
              }
            }";

        /// <summary>
        /// Test JSON for list jobs response deserialization.
        /// </summary>
        private const string ListJobsResponseJson =
            @"[{
              ""job"": {
                ""created_at"": ""2010-01-01T00:00:00Z"",
                ""finished_at"": ""2010-01-01T00:00:00Z"",
                ""updated_at"": ""2010-01-01T00:00:00Z"",
                ""submitted_at"": ""2010-01-01T00:00:00Z"",
                ""pass_through"": null,
                ""id"": 1,
                ""input_media_file"": {
                  ""format"": ""mpeg4"",
                  ""created_at"": ""2010-01-01T00:00:00Z"",
                  ""frame_rate"": 29,
                  ""finished_at"": ""2010-01-01T00:00:00Z"",
                  ""updated_at"": ""2010-01-01T00:00:00Z"",
                  ""duration_in_ms"": 24883,
                  ""audio_sample_rate"": 48000,
                  ""url"": ""s3://bucket/test.mp4"",
                  ""id"": 1,
                  ""error_message"": null,
                  ""error_class"": null,
                  ""audio_bitrate_in_kbps"": 95,
                  ""audio_codec"": ""aac"",
                  ""height"": 352,
                  ""file_size_bytes"": 1862748,
                  ""video_codec"": ""h264"",
                  ""test"": false,
                  ""channels"": ""2"",
                  ""width"": 624,
                  ""video_bitrate_in_kbps"": 498,
                  ""state"": ""finished""
                },
                ""test"": false,
                ""output_media_files"": [{
                  ""format"": ""mpeg4"",
                  ""created_at"": ""2010-01-01T00:00:00Z"",
                  ""frame_rate"": 29,
                  ""finished_at"": ""2010-01-01T00:00:00Z"",
                  ""updated_at"": ""2010-01-01T00:00:00Z"",
                  ""duration_in_ms"": 24883,
                  ""audio_sample_rate"": 44100,
                  ""url"": ""http://s3.amazonaws.com/bucket/video.mp4"",
                  ""id"": 1,
                  ""error_message"": null,
                  ""error_class"": null,
                  ""audio_bitrate_in_kbps"": 92,
                  ""audio_codec"": ""aac"",
                  ""height"": 352,
                  ""file_size_bytes"": 1386663,
                  ""video_codec"": ""h264"",
                  ""test"": false,
                  ""channels"": ""2"",
                  ""width"": 624,
                  ""video_bitrate_in_kbps"": 351,
                  ""state"": ""finished"",
                  ""label"": ""Web""
                }],
                ""thumbnails"": [{
                  ""created_at"": ""2010-01-01T00:00:00Z"",
                  ""updated_at"": ""2010-01-01T00:00:00Z"",
                  ""url"": ""http://s3.amazonaws.com/bucket/video/frame_0000.png"",
                  ""id"": 1
                }],
                ""state"": ""finished""
              }
            }]";

        #endregion

        /// <summary>
        /// Cancel job request tests.
        /// </summary>
        [TestMethod]
        public void JobCancelJobRequest()
        {
            CreateJobResponse createResponse = Zencoder.CreateJob("s3://bucket-name/file-name.avi", null, null, null, true, false);
            Assert.IsTrue(createResponse.Success);

            CancelJobResponse cancelResponse = Zencoder.CancelJob(createResponse.Id);
            Assert.IsTrue(cancelResponse.Success);

            AutoResetEvent[] handles = new AutoResetEvent[] { new AutoResetEvent(false) };

            Zencoder.CancelJob(
                createResponse.Id, 
                r =>
                {
                    Assert.IsTrue(r.InConflict);
                    handles[0].Set();
                });

            WaitHandle.WaitAll(handles);
        }

        /// <summary>
        /// Create job request tests.
        /// </summary>
        [TestMethod]
        public void JobCreateJobRequest()
        {
            Output[] outputs = new Output[]
            {
                new Output()
                {
                    Label = "iPhone",
                    Url = "s3://output-bucket/output-file-1-name.mp4",
                    Width = 480,
                    Height = 320
                },
                new Output() 
                {
                    Label = "WebHD",
                    Url = "s3://output-bucket/output-file-2-name.mp4",
                    Width = 1280,
                    Height = 720
                }
            };

            CreateJobResponse response = Zencoder.CreateJob("s3://bucket-name/file-name.avi", outputs, null, null, true, true);
            Assert.IsTrue(response.Success);
            Assert.AreEqual(outputs.Count(), response.Outputs.Count());
            
            AutoResetEvent[] handles = new AutoResetEvent[] { new AutoResetEvent(false) };

            Zencoder.CreateJob(
                "s3://bucket-name/file-name.avi",
                null,
                3,
                "asia",
                true,
                true,
                r =>
                {
                    Assert.IsTrue(r.Success);
                    Assert.IsTrue(r.Outputs.Count() > 0);
                    handles[0].Set();
                });

            WaitHandle.WaitAll(handles);
        }

        /// <summary>
        /// Create job request to JSON tests.
        /// </summary>
        [TestMethod]
        public void JobCreateJobRequestToJson()
        {
            const string One = @"{{""input"":""s3://bucket-name/file-name.avi"",""api_key"":""{0}""}}";
            const string Two = @"{{""download_connections"":3,""input"":""s3://bucket-name/file-name.avi"",""region"":""asia"",""api_key"":""{0}""}}";

            CreateJobRequest request = new CreateJobRequest(Zencoder)
            {
                Input = "s3://bucket-name/file-name.avi"
            };

            Assert.AreEqual(string.Format(CultureInfo.InvariantCulture, One, ApiKey), request.ToJson());

            request = new CreateJobRequest(Zencoder)
            {
                DownloadConnections = 3,
                Input = "s3://bucket-name/file-name.avi",
                Region = "asia"
            };

            Assert.AreEqual(string.Format(CultureInfo.InvariantCulture, Two, ApiKey), request.ToJson());
        }

        /// <summary>
        /// Create job response from JSON tests.
        /// </summary>
        [TestMethod]
        public void JobCreateJobResponseFromJson()
        {
            CreateJobResponse response = CreateJobResponse.FromJson(@"{""id"":""1234"",""outputs"":[{""id"":""4321""}]}");
            Assert.AreEqual(1234, response.Id);
            Assert.AreEqual(1, response.Outputs.Length);
            Assert.AreEqual(4321, response.Outputs.First().Id);
        }

        /// <summary>
        /// Delete job request tests.
        /// </summary>
        [TestMethod]
        public void JobDeleteJobRequest()
        {
            CreateJobResponse createResponse = Zencoder.CreateJob("s3://bucket-name/file-name.avi", null, null, null, true, false);
            Assert.IsTrue(createResponse.Success);

            // TODO: Investigate whether Zencoder has truly deprecated this API operation.
            // For now, just test for an InConflict status, because that's what it seems
            // we should expect.
            DeleteJobResponse deleteResponse = Zencoder.DeleteJob(createResponse.Id);
            Assert.IsTrue(deleteResponse.InConflict);

            AutoResetEvent[] handles = new AutoResetEvent[] { new AutoResetEvent(false) };

            Zencoder.DeleteJob(
                createResponse.Id, 
                r =>
                {
                    Assert.IsTrue(r.InConflict);
                    handles[0].Set();
                });

            WaitHandle.WaitAll(handles);
        }

        /// <summary>
        /// Job details from JSON tests.
        /// </summary>
        [TestMethod]
        public void JobJobDetailsFromJson()
        {
            JobDetailsResponse response = JobDetailsResponse.FromJson(JobDetailsResponseJson);
            Assert.AreEqual(new DateTime(2010, 1, 1), response.Job.FinishedAt);
            Assert.AreEqual(1, response.Job.Id);
            Assert.AreEqual(JobState.Finished, response.Job.State);

            Assert.AreEqual("mpeg4", response.Job.InputMediaFile.Format);
            Assert.AreEqual(24883, response.Job.InputMediaFile.DurationInMiliseconds);
            Assert.AreEqual(2, response.Job.InputMediaFile.Channels);
            Assert.AreEqual("h264", response.Job.InputMediaFile.VideoCodec);
            Assert.AreEqual(1, response.Job.OutputMediaFiles.Length);
        }

        /// <summary>
        /// Job details from JSON tests.
        /// </summary>
        [TestMethod]
        public void JobJobDetailsTestSetTwoFromJson()
        {
            JobDetailsResponse response = JobDetailsResponse.FromJson(JobDetailsResponseTestSetTwoJson);
            Assert.AreEqual(new DateTimeOffset(2011, 4, 4, 11, 22, 16, TimeSpan.FromHours(-5)).ToUniversalTime(), response.Job.FinishedAt.Value.ToUniversalTime());
            Assert.AreEqual(1, response.Job.Id);
            Assert.AreEqual(JobState.Finished, response.Job.State);

            Assert.AreEqual("mpeg4", response.Job.InputMediaFile.Format);
            Assert.AreEqual(122000, response.Job.InputMediaFile.DurationInMiliseconds);
            Assert.AreEqual(2, response.Job.InputMediaFile.Channels);
            Assert.AreEqual("h264", response.Job.InputMediaFile.VideoCodec);
            Assert.AreEqual(1, response.Job.OutputMediaFiles.Length);

            Assert.AreEqual("pcm_s16le", response.Job.InputMediaFile.AudioCodec);
            Assert.AreEqual(25.05f, response.Job.InputMediaFile.FrameRate);
            Assert.AreEqual(6524, response.Job.InputMediaFile.TotalBitrateInKbps);
            Assert.AreEqual(586, response.Job.OutputMediaFiles[0].TotalBitrateInKbps);
            
            // TODO: implement ability to get thumbnail element of response.
            // Assert.AreEqual("group-label-value-1", response.Job.
        }

        /// <summary>
        /// Job details request tests.
        /// </summary>
        [TestMethod]
        public void JobJobDetailsRequest()
        {
            CreateJobResponse createResponse = Zencoder.CreateJob("s3://bucket-name/file-name.avi", null, null, null, true, false);
            Assert.IsTrue(createResponse.Success);

            JobDetailsResponse detailsResponse = Zencoder.JobDetails(createResponse.Id);
            Assert.IsTrue(detailsResponse.Success);

            AutoResetEvent[] handles = new AutoResetEvent[] { new AutoResetEvent(false) };

            Zencoder.JobDetails(
                createResponse.Id, 
                r =>
                {
                    Assert.IsTrue(r.Success);
                    handles[0].Set();
                });

            WaitHandle.WaitAll(handles);
        }

        /// <summary>
        /// Job progress request tests.
        /// </summary>
        [TestMethod]
        public void JobJobProgressRequest()
        {
            Output output = new Output()
            {
                Label = "iPhone",
                Url = "s3://output-bucket/output-file-1-name.mp4",
                Width = 480,
                Height = 320
            };

            CreateJobResponse createResponse = Zencoder.CreateJob("s3://bucket-name/file-name.avi", new Output[] { output });
            Assert.IsTrue(createResponse.Success);

            JobProgressResponse progressResponse = Zencoder.JobProgress(createResponse.Outputs.First().Id);
            Assert.IsTrue(progressResponse.Success);

            AutoResetEvent[] handles = new AutoResetEvent[] { new AutoResetEvent(false) };

            Zencoder.JobProgress(
                createResponse.Outputs.First().Id,
                r =>
                {
                    Assert.IsTrue(r.Success);
                    handles[0].Set();
                });

            WaitHandle.WaitAll(handles);
        }

        /// <summary>
        /// Job progress response from JSON tests.
        /// </summary>
        [TestMethod]
        public void JobJobProgressResponseFromJson()
        {
            JobProgressResponse response = JobProgressResponse.FromJson(@"{""state"":""processing"",""current_event"":""Transcoding"",""progress"":""32.34567345""}");
            Assert.AreEqual(OutputState.Processing, response.State);
            Assert.AreEqual(OutputEvent.Transcoding, response.CurrentEvent);
            Assert.AreEqual(32.34567345, response.Progress);
        }

        /// <summary>
        /// List jobs request tests.
        /// </summary>
        [TestMethod]
        public void JobListJobsRequest()
        {
            ListJobsResponse response = Zencoder.ListJobs();
            Assert.IsTrue(response.Success);

            AutoResetEvent[] handles = new AutoResetEvent[] { new AutoResetEvent(false) };

            Zencoder.ListJobs(
                r =>
                {
                    Assert.IsTrue(r.Success);
                    handles[0].Set();
                });

            WaitHandle.WaitAll(handles);
        }

        /// <summary>
        /// List jobs from JSON tests.
        /// </summary>
        [TestMethod]
        public void JobListJobsFromJson()
        {
            ListJobsResponse response = ListJobsResponse.FromJson(ListJobsResponseJson);
            Assert.AreEqual(1, response.Jobs.Length);

            Job first = response.Jobs.First();
            Assert.AreEqual(new DateTime(2010, 1, 1), first.FinishedAt);
            Assert.AreEqual(1, first.Id);
            Assert.AreEqual(JobState.Finished, first.State);

            Assert.AreEqual("mpeg4", first.InputMediaFile.Format);
            Assert.AreEqual(24883, first.InputMediaFile.DurationInMiliseconds);
            Assert.AreEqual(2, first.InputMediaFile.Channels);
            Assert.AreEqual("h264", first.InputMediaFile.VideoCodec);
            Assert.AreEqual(1, first.OutputMediaFiles.Length);

            OutputMediaFile output = first.OutputMediaFiles.First();
            Assert.AreEqual(AudioCodec.Aac, output.AudioCodec);
            Assert.AreEqual(false, output.Test);
        }

        /// <summary>
        /// Nested async job request tests.
        /// </summary>
        [TestMethod]
        public void JobNestedAsyncRequests()
        {
            ManualResetEvent[] handles = new ManualResetEvent[] 
            { 
                new ManualResetEvent(false),
                new ManualResetEvent(false)
            };

            // Nested async calls.
            Zencoder.CreateJob(
                "s3://bucket-name/file-name.avi",
                null,
                3,
                "asia",
                true,
                false,
                r =>
                {
                    Assert.IsTrue(r.Success);

                    Zencoder.JobDetails(
                        r.Id,
                        dr =>
                        {
                            Assert.IsTrue(dr.Success);
                            handles[0].Set();
                        });
                });

            // Async call then a sync call.
            Zencoder.CreateJob(
                "s3://bucket-name/file-name.avi",
                null,
                3,
                "asia",
                true,
                false,
                r =>
                {
                    Assert.IsTrue(r.Success);
                    Assert.IsTrue(Zencoder.JobDetails(r.Id).Success);
                    handles[1].Set();
                });

            WaitHandle.WaitAll(handles);
        }

        /// <summary>
        /// Resubmit job request tests.
        /// </summary>
        [TestMethod]
        public void JobResubmitJobRequest()
        {
            CreateJobResponse createResponse = Zencoder.CreateJob("s3://bucket-name/file-name.avi", null, null, null, true, false);
            Assert.IsTrue(createResponse.Success);

            ResubmitJobResponse resubmitResponse = Zencoder.ResubmitJob(createResponse.Id);
            Assert.IsTrue(resubmitResponse.Success);

            AutoResetEvent[] handles = new AutoResetEvent[] { new AutoResetEvent(false) };

            Zencoder.ResubmitJob(
                createResponse.Id, 
                r =>
                {
                    Assert.IsTrue(r.Success);
                    handles[0].Set();
                });

            WaitHandle.WaitAll(handles);
        }
    }
}
