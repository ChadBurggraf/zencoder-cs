

namespace Zencoder.Test
{
    using System;
    using System.Globalization;
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
    }
}
