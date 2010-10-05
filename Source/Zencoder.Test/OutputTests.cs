namespace Zencoder.Test
{
    using System;
    using System.Globalization;
    using System.Threading;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class OutputTests : TestBase
    {
        [TestMethod]
        public void OutputOutputToJson()
        {
            const string One = @"{{""input"":""s3://bucket-name/file-name.avi"",""outputs"":[{{""height"":320,""label"":""iPhone"",""url"":""s3://output-bucket/output-file-1-name.mp4"",""width"":480}},{{""height"":720,""label"":""WebHD"",""url"":""s3://output-bucket/output-file-2-name.mp4"",""width"":1280}}],""api_key"":""{0}""}}";

            Assert.AreEqual(
                String.Format(CultureInfo.InvariantCulture, One, ApiKey),
                new CreateJobRequest(Zencoder)
                {
                    Input = "s3://bucket-name/file-name.avi",
                    Outputs = new Output[]
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
                    }
                }.ToJson());
        }

        [TestMethod]
        public void OutputWatermarkToJson()
        {
            const string One = @"{{""input"":""http://example.com/file-name.avi"",""outputs"":[{{""watermarks"":[{{""height"":""24"",""url"":""s3://bucket/watermark_file.png"",""width"":""32"",""x"":""20"",""y"":""-10%""}}]}}],""api_key"":""{0}""}}";

            Assert.AreEqual(
                String.Format(CultureInfo.InvariantCulture, One, ApiKey),
                new CreateJobRequest(Zencoder)
                {
                    Input = "http://example.com/file-name.avi",
                    Outputs = new Output[]
                    {
                        new Output().WithWatermark(
                            new Watermark()
                            {
                                Url = "s3://bucket/watermark_file.png",
                                X = "20",
                                Y = "-10%"
                            }.WithSizeInPixels(32, 24))
                    }
                }.ToJson());
        }
    }
}
