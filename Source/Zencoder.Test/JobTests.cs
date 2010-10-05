

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
        public void JobCreateJobRequestToJson()
        {
            const string Basic = @"{{""input"":""s3://bucket-name/file-name.avi"",""api_key"":""{0}""}}";

            Assert.AreEqual(
                String.Format(CultureInfo.InvariantCulture, Basic, ApiKey),
                new CreateJobRequest(Zencoder)
                {
                    Input = "s3://bucket-name/file-name.avi"
                }.ToJson());
        }
    }
}
