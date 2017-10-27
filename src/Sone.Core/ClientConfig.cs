using System;

namespace Sone.Core
{
    public class ApiClientConfig
    {
        private ApiClientConfig(Environment environment, Authentication authenticationModel,
            Version version = Version.V1)
        {
            Environment = environment;
            AuthenticationModel = authenticationModel;
            Version = version;
        }

        private Environment Environment { get; }

        public Authentication AuthenticationModel { get; }

        private Version Version { get; }

        public static ApiClientConfigBuilder Builder => new ApiClientConfigBuilder();

        internal string EnvironmentUrl()
        {
            switch (Environment)
            {
                case Environment.Production:
                    return "https://api.solutionsone.com.br/";
                case Environment.Sandbox:
                    return "https://apisandbox.solutionsone.com.br/";
                default:
                    throw new ArgumentException("Environment not configurated");
            }
        }

        public string BaseUrl(ApiType apiType)
        {
            switch (apiType)
            {
                case ApiType.Billing:
                    return $"{EnvironmentUrl()}billing/{Version:G}";
                case ApiType.Security:
                    return $"{EnvironmentUrl()}security/api/authentication/account/signin";

                default:
                    throw new ArgumentException("Api not Not Supported");
            }
        }

        public class ApiClientConfigBuilder
        {
            private string _applicationId;
            private string _clientId;
            private Environment _environment;
            private GrantType _grantType;
            private string _password;
            private string _username;

            public ApiClientConfigBuilder SetEnvironment(Environment environment)
            {
                _environment = environment;
                return this;
            }

            public ApiClientConfigBuilder SetVersion(Version version)
            {
                return this;
            }

            public ApiClientConfigBuilder SetOauthGrantType(GrantType grantType)
            {
                _grantType = grantType;
                return this;
            }

            public ApiClientConfigBuilder SetAuthenticationUsername(string username)
            {
                _username = username;
                return this;
            }

            public ApiClientConfigBuilder SetAuthenticationPassword(string password)
            {
                _password = password;
                return this;
            }

            public ApiClientConfigBuilder SetOauthApplicationId(string applicationId)
            {
                _applicationId = applicationId;
                return this;
            }

            public ApiClientConfigBuilder SetOauthClientId(string clientId)
            {
                _clientId = clientId;
                return this;
            }

            public ApiClientConfig Build()
            {
                return new ApiClientConfig(_environment, new Authentication
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