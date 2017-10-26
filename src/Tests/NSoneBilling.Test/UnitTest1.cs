using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NSoneBilling.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var cnnC = ConnectionConfiguration.Builder
                .SetEnvironment(Environment.Sandbox)
                .SetOauthGrantType(GrantType.Password)
                .SetOauthApplicationId("1")
                .SetOauthClientId("jh3123jh12")
                .SetAuthenticationUsername("")
                .SetAuthenticationPassword("")
                .Build();

            using (var connection = new Connection(cnnC))
            {
                connection.Hire(new { });
                connection.Cancel(new { });
                connection.Update(new { });
                connection.ChangePaymentMode(new { });
            }
        }
    }
}