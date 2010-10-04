

namespace Zencoder.Test
{
    using System;
    using System.Threading;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AccountTests : TestBase
    {
        [TestMethod]
        public void AccountAccountDetailsRequest()
        {
            AccountDetailsResponse response = Zencoder.AccountDetails();
            Assert.IsTrue(response.Success);

            AutoResetEvent[] handles = new AutoResetEvent[] { new AutoResetEvent(false) };

            Zencoder.AccountDetails(r =>
            {
                Assert.IsTrue(r.Success);
                handles[0].Set();
            });

            WaitHandle.WaitAll(handles);
        }

        [TestMethod]
        public void AccountAccountDetailsResponseFromJson()
        {
            AccountDetailsResponse.FromJson(@"{""account_state"":""active"",""plan"":""Growth"",""minutes_used"":12549,""minutes_included"":25000,""billing_state"":""active"",""integration_mode"":true}");
        }

        [TestMethod]
        public void AccountAccountIntegrationModeRequest()
        {
            AccountIntegrationModeResponse response = Zencoder.AccountIntegrationMode(true);
            Assert.IsTrue(response.Success);

            AutoResetEvent[] handles = new AutoResetEvent[] { new AutoResetEvent(false) };

            Zencoder.AccountIntegrationMode(true, r =>
            {
                Assert.IsTrue(r.Success);
                handles[0].Set();
            });

            WaitHandle.WaitAll(handles);
        }

        [TestMethod]
        public void AccountCreateAccountRequest()
        {
            CreateAccountResponse response = Zencoder.CreateAccount("test@example.com", "1234", "asdf1234", true, false);
            Assert.IsTrue(response.Success);

            AutoResetEvent[] handles = new AutoResetEvent[] { new AutoResetEvent(false) };

            Zencoder.CreateAccount("test@example.com", "1234", "asdf1234", true, false, r =>
            {
                Assert.IsTrue(r.Success);
                handles[0].Set();
            });

            WaitHandle.WaitAll(handles);
        }

        [TestMethod]
        public void AccountCreateAccountRequestToJson()
        {
            Assert.AreEqual(
                @"{""affiliate_code"":""asdf1234"",""email"":""test@example.com"",""newsletter"":""1"",""password"":""1234"",""terms_of_service"":""1""}", 
                new CreateAccountRequest(Zencoder.BaseUrl)
                {
                    AffiliateCode = "asdf1234",
                    Email = "test@example.com",
                    Newsletter = "1",
                    Password = "1234",
                    TermsOfService = "1"
                }.ToJson());
        }

        [TestMethod]
        public void AccountCreateAccountResponseFromJson()
        {
            CreateAccountResponse.FromJson(@"{""api_key"":""a123afdaf23fa231245fadcbbb"",""password"":""1234""}");
        }
    }
}
