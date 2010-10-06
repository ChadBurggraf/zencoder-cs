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

    /// <summary>
    /// Output tests.
    /// </summary>
    [TestClass]
    public class OutputTests : TestBase
    {
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

            Assert.AreEqual(String.Format(CultureInfo.InvariantCulture, One, ApiKey), request.ToJson());
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

            Assert.AreEqual(String.Format(CultureInfo.InvariantCulture, One, ApiKey), request.ToJson());
        }
    }
}
