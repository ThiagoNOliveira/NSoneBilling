using System;

namespace NSoneBilling
{
    public class ConnectionConfiguration
    {
        private ConnectionConfiguration(Environment environment, AuthenticationModel authenticationModel)
        {
            Environment = environment;
            AuthenticationModel = authenticationModel;
        }

        public Environment Environment { get; }

        internal AuthenticationModel AuthenticationModel { get; }

        internal string SecurityUri => "/security/api";

        internal string BillingUri => "/billing";

        internal string EnvironmentUrl()
        {
            switch (Environment)
            {
                case Environment.Production:
                    return "https://api.solutionsone.com.br";
                case Environment.Sandbox:
                    return "https://apisandbox.solutionsone.com.br";
                default:
                    throw new ArgumentException("Environment not configurated");
            }
        }

        public static ConnectionConfigurationBuilder Builder => new ConnectionConfigurationBuilder();

        public class ConnectionConfigurationBuilder
        {
            private string _applicationId;
            private string _clientId;
            private Environment _environment;
            private GrantType _grantType;
            private string _password;
            private string _username;

            public ConnectionConfigurationBuilder SetEnvironment(Environment environment)
            {
                _environment = environment;
                return this;
            }

            public ConnectionConfigurationBuilder SetOauthGrantType(GrantType grantType)
            {
                _grantType = grantType;
                return this;
            }

            public ConnectionConfigurationBuilder SetAuthenticationUsername(string username)
            {
                _username = username;
                return this;
            }

            public ConnectionConfigurationBuilder SetAuthenticationPassword(string password)
            {
                _password = password;
                return this;
            }

            public ConnectionConfigurationBuilder SetOauthApplicationId(string applicationId)
            {
                _applicationId = applicationId;
                return this;
            }

            public ConnectionConfigurationBuilder SetOauthClientId(string clientId)
            {
                _clientId = clientId;
                return this;
            }

            public ConnectionConfiguration Build()
            {
                return new ConnectionConfiguration(_environment, new AuthenticationModel
                {
                    GrantType = _grantType,
                    ApplicationId = _applicationId,
                    ClientId = _clientId,
                    Username = _username,
                    Password = _password
                });
            }
        }
    }
}