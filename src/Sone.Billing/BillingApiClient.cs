using System;
using System.Security.Authentication;
using System.Threading;
using Sone.Billing.Model.Contract;
using Sone.Core;
using Sone.Core.RestFull;

namespace Sone.Billing
{
    public class BillingApiClient : IDisposable
    {
        private ApiClientConfig _configuration;
        private TokenResponseModel _token;

        public BillingApiClient(ApiClientConfig configuration)
        {
            _configuration = configuration;
            OAuthSignIn();
        }

        public void Dispose()
        {
            //  OAuthSignOut();

            _configuration = null;
            _token = null;

            GC.SuppressFinalize(this);
        }

        private void OAuthSignIn()
        {
            _token = Requests.OAuthSignIn(_configuration.BaseUrl(ApiType.Security), null,
                _configuration.AuthenticationModel.Username, _configuration.AuthenticationModel.Password,
                _configuration.AuthenticationModel.ApplicationId, _configuration.AuthenticationModel.ClientId);

            if (_token == null)
                throw new AuthenticationException("Could not authenticate");

            Thread.GetDomain().SetData("Authorization", _token.AccessToken);
        }

        private void OAuthSignOut()
        {
            Requests.OAuthSignOut(_configuration.BaseUrl(ApiType.Security), null, _token.AccessToken);
        }

        public CreateContractResponse Hire(CreateContractRequest createContractRequest)
        {
            return Requests.Post<CreateContractResponse>($"{_configuration.BaseUrl(ApiType.Billing)}/contracts", null,
                createContractRequest);
        }
    }
}