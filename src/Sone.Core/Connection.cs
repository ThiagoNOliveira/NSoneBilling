using System;
using System.Threading;
using Sone.Core.RestFull;

namespace Sone.Core
{
    public class Connection : IDisposable
    {
        private ConnectionConfiguration _configuration;
        private TokenResponseModel _token;

        public Connection(ConnectionConfiguration configuration)
        {
            _configuration = configuration;
            OAuthSignIn();
        }

        public void Dispose()
        {
            OAuthSignOut();

            _configuration = null;
            _token = null;

            GC.SuppressFinalize(this);
        }

        private void OAuthSignIn()
        {
            _token = Requests.OAuthSignIn(_configuration.BaseUrl(ApiType.Security), null,
                _configuration.AuthenticationModel.Username, _configuration.AuthenticationModel.Password,
                _configuration.AuthenticationModel.ApplicationId, _configuration.AuthenticationModel.ClientId);

            Thread.GetDomain().SetData("Authorization", _token.AccessToken);
        }

        private void OAuthSignOut()
        {
            Requests.OAuthSignOut(_configuration.BaseUrl(ApiType.Security), null, _token.AccessToken);
        }

        public CreateContractResponse Hire(CreateContractRequest createContractRequest)
        {
            return Requests.Post<CreateContractResponse>($"{_configuration.BaseUrl(ApiType.Billing)}/hire", null, createContractRequest);
        }

    }
}