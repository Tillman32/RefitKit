using Refit;
using RefitKit.BattleNet.Tests;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RefitKit.Blizzard.Tests
{
    public class IWorldOfWarcraftCommunityAPITest : IClassFixture<LaunchSettingsFixture>, IClassFixture<AuthenticationFixture>
    {
        private readonly IWorldOfWarcraftCommunityAPI _wowApi;
        private readonly string _accessToken;

        public IWorldOfWarcraftCommunityAPITest()
        {
            _accessToken = Environment.GetEnvironmentVariable("RfK_TestAccessToken");

            _wowApi =
                RestService.For<IWorldOfWarcraftCommunityAPI>(
                Constants.BlizzardAPIBaseURL,
                new RefitSettings
                {
                    AuthorizationHeaderValueGetter = (_, _) => Task.FromResult(_accessToken)
                });
        }

        [Fact(DisplayName = "Achievement")]
        public async Task GetAchievement()
        {
            var id = 2144;

            var response = await _wowApi.GetAchievement<HttpResponseMessage>(id);

            Assert.Equal("OK", response.StatusCode.ToString());
        }

        [Fact(DisplayName = "Auction Data")]
        public async Task GetAuctionData()
        {
            var realm = "Illidan";

            var response = await _wowApi.GetAuctionData<HttpResponseMessage>(realm);

            Assert.Equal("OK", response.StatusCode.ToString());
        }

        [Fact(DisplayName = "Boss List")]
        public async Task GetBossList()
        {
            var response = await _wowApi.GetBossList<HttpResponseMessage>();

            Assert.Equal("OK", response.StatusCode.ToString());
        }

        [Fact(DisplayName = "Boss")]
        public async Task GetBoss()
        {
            var bossId = 24723;

            var response = await _wowApi.GetBoss<HttpResponseMessage>(bossId);

            Assert.Equal("OK", response.StatusCode.ToString());
        }

        [Fact(DisplayName = "Realm Status")]
        public async Task GetRealmStatus()
        {
            var realms = "Illidan,Stormreaver"; 

            var response = await _wowApi.GetRealmStatus<HttpResponseMessage>(realms);

            Assert.Equal("OK", response.StatusCode.ToString());
        }
    }
}
