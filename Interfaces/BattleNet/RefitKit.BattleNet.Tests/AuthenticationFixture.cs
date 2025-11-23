using Newtonsoft.Json.Linq;
using Refit;
using RefitKit.Shared;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace RefitKit.BattleNet.Tests
{
    public class AuthenticationFixture : IAsyncLifetime
    {
        private readonly IBattleNetAPI _bNetApi;
        private readonly string _clientId;
        private readonly string _secret;

        public AuthenticationFixture()
        {
            _clientId = Environment.GetEnvironmentVariable("RfK_BNET_CLIENT_ID");
            _secret = Environment.GetEnvironmentVariable("RfK_BNET_SECRET");

            var authHeaderValue = Helpers.Base64EncodeCredentials(_clientId, _secret);

            _bNetApi =
                 RestService.For<IBattleNetAPI>(
                 Constants.BNetAPIBaseURL,
                 new RefitSettings
                 {
                     AuthorizationHeaderValueGetter = (_, _) => Task.FromResult(authHeaderValue)
                 });
        }

        public async Task InitializeAsync()
        {
            var response = await _bNetApi.AuthorizeApplication<HttpResponseMessage>();

            if(response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                JObject resData = JObject.Parse(json);

                Environment.SetEnvironmentVariable("RfK_TestAccessToken", resData["access_token"].ToString());
            }
        }

        public async Task DisposeAsync()
        {
            Environment.SetEnvironmentVariable("RfK_TestAccessToken", null);
            await Task.CompletedTask;
        }
    }
}
