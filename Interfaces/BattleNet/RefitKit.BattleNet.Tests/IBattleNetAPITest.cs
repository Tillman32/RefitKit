using NSubstitute;
using Refit;
using RefitKit.Shared;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RefitKit.BattleNet.Tests
{
    public class IBattleNetAPITest : IClassFixture<LaunchSettingsFixture>, IClassFixture<AuthenticationFixture>
    {
        private readonly IBattleNetAPI _bNetApi;
        private readonly string _clientId;
        private readonly string _authHeaderValue;
        private readonly string _accessToken;

        public IBattleNetAPITest()
        {
            _clientId = Environment.GetEnvironmentVariable("RfK_BNET_CLIENT_ID");
            var secret = Environment.GetEnvironmentVariable("RfK_BNET_SECRET");

            _authHeaderValue = Helpers.Base64EncodeCredentials(_clientId, secret);
            _accessToken = Environment.GetEnvironmentVariable("RfK_TestAccessToken");

            _bNetApi = 
                RestService.For<IBattleNetAPI>(
                Constants.BNetAPIBaseURL,
                new RefitSettings
                {
                    AuthorizationHeaderValueGetter = () => Task.FromResult(_authHeaderValue)
                });
        }

        [Fact(DisplayName = "Authorize User")]
        public async Task AuthorizeUser()
        {
            var redirectUrl = Environment.GetEnvironmentVariable("RfK_AUTH_REDIRECT_URL");

            var response = await _bNetApi.AuthorizeUser<HttpResponseMessage>(_clientId, redirectUrl);

            // TODO: This test could be improved. The response is a web page for the user to accept, with a callback. 
            Assert.Equal("OK", response.StatusCode.ToString());
        }

        [Fact(DisplayName = "Authorize Application")]
        public async Task AuthorizeApplication()
        {
            var response = await _bNetApi.AuthorizeApplication<HttpResponseMessage>();

            Assert.Equal("OK", response.StatusCode.ToString());
        }

        [Fact(DisplayName = "Validate Token")]
        public async Task ValidateToken()
        {
            var response = await _bNetApi.ValidateToken<HttpResponseMessage>(_accessToken);

            Assert.Equal("OK", response.StatusCode.ToString());
        }
    }
}
