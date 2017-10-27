using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Web;
using Newtonsoft.Json;

namespace Sone.Core.RestFull
{
    /// <summary>
    ///     Performs restful operations.
    /// </summary>
    public static class Requests
    {
        /// <summary>
        ///     Retrieve a specified resource or list.
        /// </summary>
        /// <typeparam name="T">Type of return.</typeparam>
        /// <param name="url">URL of resource.</param>
        /// <param name="uriTemplate">URI template for resource.</param>
        /// <param name="parameters">Parameters to format the uri template.</param>
        /// <returns>Object of type informed.</returns>
        public static T Get<T>(string url, string uriTemplate = "", Dictionary<string, string> parameters = null)
            where T : new()
        {
            var restResponse = Execute(HttpMethod.Get, url, uriTemplate, parameters);

            using (var stream = restResponse.GetResponseStream())
            {
                var reader = new StreamReader(stream, Encoding.UTF8);

                return JsonConvert.DeserializeObject<T>(reader.ReadToEnd());
            }
        }

        /// <summary>
        ///     Creates one specific resource.
        /// </summary>
        /// <typeparam name="T">Type of return.</typeparam>
        /// <param name="url">URL of resource.</param>
        /// <param name="uriTemplate">URI template for resource.</param>
        /// <param name="body">Object to submit.</param>
        /// <param name="parameters">Parameters to format the uri template.</param>
        /// <returns>Object of type informed.</returns>
        public static T Post<T>(string url, string uriTemplate, object body,
            Dictionary<string, string> parameters = null)
            where T : new()
        {
            if (uriTemplate == null)
                uriTemplate = string.Empty;

            var restResponse = Execute(HttpMethod.Post, url, uriTemplate, parameters, body);

            using (var stream = restResponse.GetResponseStream())
            {
                var reader = new StreamReader(stream, Encoding.UTF8);

                return JsonConvert.DeserializeObject<T>(reader.ReadToEnd());
            }
        }

        /// <summary>
        ///     Creates one specific resource.
        /// </summary>
        /// <param name="url">URL of resource.</param>
        /// <param name="uriTemplate">URI template for resource.</param>
        /// <param name="body">Object to submit.</param>
        /// <param name="parameters">Parameters to format the uri template.</param>
        public static void Post(string url, string uriTemplate, object body,
            Dictionary<string, string> parameters = null)
        {
            Execute(HttpMethod.Post, url, uriTemplate, parameters, body);
        }

        /// <summary>
        ///     Updates one specific resource.
        /// </summary>
        /// <param name="url">URL of resource.</param>
        /// <param name="uriTemplate">URI template for resource.</param>
        /// <param name="body"></param>
        /// <param name="parameters">Parameters to format the uri template.</param>
        public static void Put(string url, string uriTemplate, Dictionary<string, string> parameters = null,
            object body = null)
        {
            Execute(HttpMethod.Put, url, uriTemplate, parameters, body);
        }

        /// <summary>
        ///     Deletes one specific resource.
        /// </summary>
        /// <param name="url">URL of resource.</param>
        /// <param name="uriTemplate">URI template for resource.</param>
        /// <param name="parameters">Parameters to format the uri template.</param>
        public static void Delete(string url, string uriTemplate, Dictionary<string, string> parameters = null)
        {
            Execute(HttpMethod.Delete, url, uriTemplate, parameters);
        }

        /// <summary>
        ///     Method responsible for authenticating the user in the WebApi project.
        /// </summary>
        /// <param name="url">URL of resource.</param>
        /// <param name="uriTemplate">URI template for resource.</param>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="applicationId"></param>
        /// <param name="clientId"></param>
        /// <returns></returns>
        public static TokenResponseModel OAuthSignIn(string url, string uriTemplate, string login, string password,
            string applicationId, string clientId)
        {
            TokenResponseModel result = null;

            if (uriTemplate == null)
                uriTemplate = string.Empty;

            using (var client = new HttpClient())
            {
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("username", login),
                    new KeyValuePair<string, string>("password", password),
                    new KeyValuePair<string, string>("applicationId", applicationId),
                    new KeyValuePair<string, string>("client_id", clientId)
                });

                var response = client.PostAsync(url + uriTemplate, content).Result;

                if (response.IsSuccessStatusCode)
                    result =
                        JsonConvert.DeserializeObject<TokenResponseModel>(response.Content.ReadAsStringAsync().Result);
            }

            return result;
        }

        /// <summary>
        ///     Method responsible for authenticating the user in the WebApi project.
        /// </summary>
        /// <param name="url">URL of resource.</param>
        /// <param name="uriTemplate">URI template for resource.</param>
        /// <param name="provider"></param>
        /// <param name="userId"></param>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public static TokenResponseModel OAuthSignInSocial(string url, string uriTemplate, string provider,
            string userId, string cpf)
        {
            TokenResponseModel result = null;

            if (uriTemplate == null)
                uriTemplate = string.Empty;

            using (var client = new HttpClient())
            {
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("userID", userId),
                    new KeyValuePair<string, string>("provider", provider),
                    new KeyValuePair<string, string>("cpf", cpf)
                });

                var response = client.PostAsync(url + uriTemplate, content).Result;

                if (response.IsSuccessStatusCode)
                    result =
                        JsonConvert.DeserializeObject<TokenResponseModel>(response.Content.ReadAsStringAsync().Result);
            }

            return result;
        }

        /// <summary>
        ///     Method responsible for authenticating the user in the WebApi project.
        /// </summary>
        /// <param name="url">URL of resource.</param>
        /// <param name="uriTemplate">URI template for resource.</param>
        /// <param name="token"></param>
        /// <returns></returns>
        public static void OAuthSignOut(string url, string uriTemplate, string token)
        {
            if (uriTemplate == null)
                uriTemplate = string.Empty;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = client.DeleteAsync(url + uriTemplate).Result;

                if (!response.IsSuccessStatusCode)
                    throw new ApplicationException("Http Error: " + response.StatusCode);
            }
        }

        #region Private Methods

        private static HttpWebResponse Execute(HttpMethod method, string url, string uriTemplate = "",
            Dictionary<string, string> parameters = null, object body = null, string contentType = "application/json")
        {
            if (uriTemplate == null)
                uriTemplate = string.Empty;

            var uri = string.Concat(url,
                parameters?.Aggregate(uriTemplate,
                    (current, parameter) => current.Replace(parameter.Key, parameter.Value)));
            var restRequest = WebRequest.Create(uri);

            ((HttpWebRequest)restRequest).AutomaticDecompression =
                DecompressionMethods.GZip | DecompressionMethods.Deflate;
            restRequest.Method = method.ToString();

            if (HttpContext.Current != null)
            {
                if (HttpContext.Current.Items.Contains("RequestId"))
                    restRequest.Headers.Add("X-RequestId", HttpContext.Current?.Items["RequestId"].ToString());

                if (HttpContext.Current.Items.Contains("Authorization"))
                    restRequest.Headers.Add("Authorization", $"bearer {HttpContext.Current?.Items["Authorization"]}");
            }
            else
            {
                var authorization = Thread.GetDomain().GetData("Authorization");
                if (authorization != null)
                    restRequest.Headers.Add("Authorization", $"bearer {authorization}");
            }

            restRequest.ContentType = contentType;
            restRequest.Headers.Add("x-origin", "sdk-v1");

            if (method != HttpMethod.Post && method != HttpMethod.Put && body == null)
                return (HttpWebResponse)restRequest.GetResponse();

            Stream content = new MemoryStream(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(body)));
            var reqStream = restRequest.GetRequestStream();
            content.CopyTo(reqStream);
            reqStream.Close();

            return (HttpWebResponse)restRequest.GetResponse();
        }

        #endregion
    }
}