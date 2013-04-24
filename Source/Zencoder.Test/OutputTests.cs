//-----------------------------------------------------------------------
// <copyright file="OutputTests.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder.Test
{
    using System;
    using System.Globalization;
    using System.Threading;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;

    /// <summary>
    /// Output tests.
    /// </summary>
    [TestClass]
    public class OutputTests : TestBase
    {
        #region Access Control JSON

        /// <summary>
        /// Test JSON for S3 access control output serialization.
        /// </summary>
        private const string AccessControlJson = @"{{""input"":""s3://bucket-name/file-name.avi"",""outputs"":[{{""access_control"":[{{""grantee"":""cdc7931a9574b1055d5b76112021d0e9"",""permissions"":[""READ"",""WRITE""]}},{{""grantee"":""someone@tastycodes.com"",""permissions"":[""FULL_CONTROL""]}},{{""grantee"":""http://acs.amazonaws.com/groups/global/AllUsers"",""permissions"":[""READ""]}}],""thumbnails"":[{{""label"":null,""number"":1}}],""url"":""s3://output-bucket/output-file-1-name.mp4""}}],""api_key"":""{0}""}}";

        #endregion

        /// <summary>
        /// Output access control to JSON tests.
        /// </summary>
        [TestMethod]
        public void OutputAccessControlToJson()
        {
            Output output = new Output()
                .WithUrl(new Uri("s3://output-bucket/output-file-1-name.mp4"))
                .WithAccessControls(
                    new S3Access[]
                    {
                        new S3Access() { Grantee = "cdc7931a9574b1055d5b76112021d0e9", Permissions = new[] { S3Permission.Read, S3Permission.Write } },
                        new S3Access() { Grantee = "someone@tastycodes.com", Permissions = new[] { S3Permission.FullControl } },
                        new S3Access() { Grantee = "http://acs.amazonaws.com/groups/global/AllUsers", Permissions = new[] { S3Permission.Read } }
                    })
                .WithThumbnails(new Thumbnails().WithNumber(1));

            CreateJobRequest request = new CreateJobRequest(Zencoder)
                .WithInputUrl(new Uri("s3://bucket-name/file-name.avi"))
                .WithOutput(output);

            Assert.AreEqual(string.Format(CultureInfo.InvariantCulture, AccessControlJson, ApiKey), request.ToJson());
        }

        /// <summary>
        /// Output H264 create job tests.
        /// </summary>
        [TestMethod]
        public void OutputH264CreateJob()
        {
            Output output = new Output()
            {
                H264Level = H264Level.FourPointOne,
                H264ReferenceFrames = 5,
                H264Profile = H264Profile.High,
                Tuning = Tuning.FastDecode
            };

            CreateJobResponse response = Zencoder.CreateJob("s3://bucket-name/file-name.avi", new Output[] { output });
            Assert.IsTrue(response.Success);
        }

        /// <summary>
        /// Output H264 to JSON tests.
        /// </summary>
        [TestMethod]
        public void OutputH264ToJson()
        {
            const string Json = @"{""h264_level"":""4.1"",""h264_profile"":""high"",""h264_reference_frames"":5,""tuning"":""fastdecode""}";

            Output output = new Output()
            {
                H264Level = H264Level.FourPointOne,
                H264ReferenceFrames = 5,
                H264Profile = H264Profile.High,
                Tuning = Tuning.FastDecode
            };

            Assert.AreEqual(Json, JsonConvert.SerializeObject(output));
        }

        /// <summary>
        /// Output notification to JSON tests.
        /// </summary>
        [TestMethod]
        public void OutputNotificationToJson()
        {
            Assert.AreEqual(
                @"{""format"":""json"",""url"":""http://user:password@tastycodes.com/zencoder1""}",
                JsonConvert.SerializeObject(Notification.ForHttp("http://user:password@tastycodes.com/zencoder1")));

            Assert.AreEqual(
                @"""admin@tastycodes.com""",
                JsonConvert.SerializeObject(Notification.ForEmail("admin@tastycodes.com")));

            Notification[] notifications = new Notification[]
            {
                Notification.ForHttp("http://user:password@tastycodes.com/zencoder2"),
                Notification.ForEmail("admin@tastycodes.com")
            };

            Assert.AreEqual(
                @"[{""format"":""json"",""url"":""http://user:password@tastycodes.com/zencoder2""},""admin@tastycodes.com""]",
                JsonConvert.SerializeObject(notifications));
        }

        /// <summary>
        /// Output to JSON tests.
        /// </summary>
        [TestMethod]
        public void OutputOutputToJson()
        {
            const string One = @"{{""input"":""s3://bucket-name/file-name.avi"",""outputs"":[{{""height"":320,""label"":""iPhone"",""url"":""s3://output-bucket/output-file-1-name.mp4"",""width"":480}},{{""height"":720,""label"":""WebHD"",""url"":""s3://output-bucket/output-file-2-name.mp4"",""width"":1280}}],""api_key"":""{0}""}}";

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

            CreateJobRequest request = new CreateJobRequest(Zencoder)
            {
                Input = "s3://bucket-name/file-name.avi",
                Outputs = outputs
            };

            Assert.AreEqual(string.Format(CultureInfo.InvariantCulture, One, ApiKey), request.ToJson());
        }

        /// <summary>
        /// Output segmented streams to JSON tests.
        /// </summary>
        [TestMethod]
        public void OutputSegmentedStreamsToJson()
        {
            const string One = @"{{""input"":""http://example.com/file-name.avi"",""outputs"":[{{""segment_seconds"":30}},{{""type"":""playlist"",""streams"":[{{""bandwidth"":240,""path"":""low/index.m3u8""}},{{""bandwidth"":640,""path"":""high/index.m3u8""}}]}}],""api_key"":""{0}""}}";

            Output output = new Output()
            {
                SegmentSeconds = 30
            };

            Output playlist = new Output()
            {
                OutputType = OutputType.Playlist,
                Streams = new PlaylistStream[]
                {
                    new PlaylistStream()
                    {
                        Bandwidth = 240,
                        Path = "low/index.m3u8"
                    },
                    new PlaylistStream()
                    {
                        Bandwidth = 640,
                        Path = "high/index.m3u8"
                    }
                }
            };

            CreateJobRequest request = new CreateJobRequest(Zencoder)
            {
                Input = "http://example.com/file-name.avi",
                Outputs = new Output[] { output, playlist }
            };

            Assert.AreEqual(string.Format(CultureInfo.InvariantCulture, One, ApiKey), request.ToJson());
        }

        /// <summary>
        /// Output thumbnails to JSON tests.
        /// </summary>
        [TestMethod]
        public void OutputThumbnailsToJson()
        {
            const string One = @"{{""input"":""http://example.com/file-name.avi"",""outputs"":[{{""thumbnails"":[{{""base_url"":""s3://bucket/directory"",""height"":120,""label"":null,""number"":6,""prefix"":""custom"",""width"":160}}]}}],""api_key"":""{0}""}}";
            const string Two = @"{{""input"":""http://example.com/file-name.avi"",""outputs"":[{{""thumbnails"":[{{""headers"":{{""x-amz-acl"":""public-read-write""}},""base_url"":""s3://bucket/directory"",""filename"":""{{{{number}}}}_{{{{width}}}}x{{{{height}}}}-thumbnail"",""height"":120,""interval_in_frames"":10,""label"":null,""prefix"":""custom"",""width"":160}}]}}],""api_key"":""{0}""}}";

            Thumbnails thumbs = new Thumbnails()
            {
                BaseUrl = "s3://bucket/directory",
                Prefix = "custom"
            };

            Output output = new Output()
            {
                Thumbnails = new Thumbnails[] { thumbs.WithNumber(6).WithSize(160, 120) }
            };

            CreateJobRequest request = new CreateJobRequest(Zencoder)
            {
                Input = "http://example.com/file-name.avi",
                Outputs = new Output[] { output }
            };

            Assert.AreEqual(string.Format(CultureInfo.InvariantCulture, One, ApiKey), request.ToJson());

            thumbs = thumbs.WithIntervalInFrames(10);
            thumbs.FileName = "{{number}}_{{width}}x{{height}}-thumbnail";
            thumbs.Headers["x-amz-acl"] = "public-read-write";

            output.Thumbnails = new Thumbnails[] { thumbs };

            Assert.AreEqual(string.Format(CultureInfo.InvariantCulture, Two, ApiKey), request.ToJson());
        }

        /// <summary>
        /// Output watermark to JSON tests.
        /// </summary>
        [TestMethod]
        public void OutputWatermarkToJson()
        {
            const string One = @"{{""input"":""http://example.com/file-name.avi"",""outputs"":[{{""watermarks"":[{{""height"":""24"",""url"":""s3://bucket/watermark_file.png"",""width"":""32"",""x"":""20"",""y"":""-10%""}}]}}],""api_key"":""{0}""}}";

            Watermark watermark = new Watermark()
            {
                Url = "s3://bucket/watermark_file.png",
                X = "20",
                Y = "-10%"
            };

            Output[] outputs = new Output[] { new Output().WithWatermark(watermark.WithSizeInPixels(32, 24)) };

            CreateJobRequest request = new CreateJobRequest(Zencoder)
            {
                Input = "http://example.com/file-name.avi",
                Outputs = outputs
            };

            Assert.AreEqual(string.Format(CultureInfo.InvariantCulture, One, ApiKey), request.ToJson());
        }
    }
}
