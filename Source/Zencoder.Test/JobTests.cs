

namespace Zencoder.Test
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class JobTests : TestBase
    {
        [TestMethod]
        public void JobCreateJobRequest()
        {
            CreateJobResponse response = Zencoder.CreateJob(
                "s3://bucket-name/file-name.avi",
                new Output[]
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
                });

            Assert.IsTrue(response.Success);

            AutoResetEvent[] handles = new AutoResetEvent[] { new AutoResetEvent(false) };

            Zencoder.CreateJob(
                "s3://bucket-name/file-name.avi",
                null,
                3,
                "asia",
                true,
                r =>
                {
                    Assert.IsTrue(r.Success);
                    handles[0].Set();
                });

            WaitHandle.WaitAll(handles);
        }

        [TestMethod]
        public void JobCreateJobRequestToJson()
        {
            const string One = @"{{""input"":""s3://bucket-name/file-name.avi"",""api_key"":""{0}""}}";
            const string Two = @"{{""download_connections"":3,""input"":""s3://bucket-name/file-name.avi"",""region"":""asia"",""api_key"":""{0}""}}";

            Assert.AreEqual(
                String.Format(CultureInfo.InvariantCulture, One, ApiKey),
                new CreateJobRequest(Zencoder)
                {
                    Input = "s3://bucket-name/file-name.avi"
                }.ToJson());

            Assert.AreEqual(
                String.Format(CultureInfo.InvariantCulture, Two, ApiKey),
                new CreateJobRequest(Zencoder)
                {
                    DownloadConnections = 3,
                    Input = "s3://bucket-name/file-name.avi",
                    Region = "asia"
                }.ToJson());
        }

        [TestMethod]
        public void JobListJobsFromJson()
        {
            ListJobsResponse response = ListJobsResponse.FromJson(ListJobsResponseJson);
            Assert.AreEqual(1, response.Jobs.Length);

            Job first = response.Jobs.First();
            Assert.AreEqual(new DateTime(2010, 1, 1), first.FinishedAt);
            Assert.AreEqual(1, first.Id);
            Assert.AreEqual("finished", first.State);

            Assert.AreEqual("mpeg4", first.InputMediaFile.Format);
            Assert.AreEqual(24883, first.InputMediaFile.DurationInMiliseconds);
            Assert.AreEqual(2, first.InputMediaFile.Channels);
            Assert.AreEqual(VideoCodec.H264, first.InputMediaFile.VideoCodec);
            Assert.AreEqual(1, first.OutputMediaFiles.Length);

            MediaFile output = first.OutputMediaFiles.First();
            Assert.AreEqual(AudioCodec.Aac, output.AudioCodec);
            Assert.AreEqual(false, output.Test);
        }

        #region List Jobs Response JSON

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
    }
}
