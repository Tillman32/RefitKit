using Refit;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;

namespace RefitKit.Blizzard.Tests
{
    public class IWorldOfWarcraftCommunityAPIInterfaceTest
    {
        [Fact(DisplayName = "Interface has expected methods")]
        public void InterfaceHasExpectedMethods()
        {
            var methods = typeof(IWorldOfWarcraftCommunityAPI).GetMethods();
            
            Assert.NotEmpty(methods);
            Assert.Contains(methods, m => m.Name == "GetAchievement");
            Assert.Contains(methods, m => m.Name == "GetAuctionData");
            Assert.Contains(methods, m => m.Name == "GetBossList");
            Assert.Contains(methods, m => m.Name == "GetBoss");
            Assert.Contains(methods, m => m.Name == "GetRealmLeaderboard");
            Assert.Contains(methods, m => m.Name == "GetRegionLeaderboard");
            Assert.Contains(methods, m => m.Name == "GetRealmStatus");
        }

        [Fact(DisplayName = "Interface has Authorization Bearer header")]
        public void InterfaceHasAuthorizationHeader()
        {
            var headersAttr = typeof(IWorldOfWarcraftCommunityAPI).GetCustomAttribute<HeadersAttribute>();
            Assert.NotNull(headersAttr);
            Assert.Contains("Authorization: Bearer", headersAttr!.Headers);
        }

        [Fact(DisplayName = "GetAchievement method has correct Refit attributes")]
        public void GetAchievementMethodHasCorrectAttributes()
        {
            var method = typeof(IWorldOfWarcraftCommunityAPI).GetMethod("GetAchievement");
            Assert.NotNull(method);
            
            var getAttr = method!.GetCustomAttribute<GetAttribute>();
            Assert.NotNull(getAttr);
            Assert.Contains("wow/achievement", getAttr!.Path);
        }

        [Fact(DisplayName = "GetAuctionData method has correct Refit attributes")]
        public void GetAuctionDataMethodHasCorrectAttributes()
        {
            var method = typeof(IWorldOfWarcraftCommunityAPI).GetMethod("GetAuctionData");
            Assert.NotNull(method);
            
            var getAttr = method!.GetCustomAttribute<GetAttribute>();
            Assert.NotNull(getAttr);
            Assert.Contains("wow/auction/data", getAttr!.Path);
        }

        [Fact(DisplayName = "GetBossList method has correct Refit attributes")]
        public void GetBossListMethodHasCorrectAttributes()
        {
            var method = typeof(IWorldOfWarcraftCommunityAPI).GetMethod("GetBossList");
            Assert.NotNull(method);
            
            var getAttr = method!.GetCustomAttribute<GetAttribute>();
            Assert.NotNull(getAttr);
            Assert.Contains("wow/boss", getAttr!.Path);
        }

        [Fact(DisplayName = "GetRealmStatus method has correct Refit attributes")]
        public void GetRealmStatusMethodHasCorrectAttributes()
        {
            var method = typeof(IWorldOfWarcraftCommunityAPI).GetMethod("GetRealmStatus");
            Assert.NotNull(method);
            
            var getAttr = method!.GetCustomAttribute<GetAttribute>();
            Assert.NotNull(getAttr);
            Assert.Contains("wow/realm/status", getAttr!.Path);
        }

        [Fact(DisplayName = "All methods return Task")]
        public void AllMethodsReturnTask()
        {
            var methods = typeof(IWorldOfWarcraftCommunityAPI).GetMethods();
            
            foreach (var method in methods)
            {
                Assert.True(method.ReturnType.IsGenericType);
                Assert.Equal(typeof(Task<>), method.ReturnType.GetGenericTypeDefinition());
            }
        }

        [Fact(DisplayName = "Constants class has BlizzardAPIBaseURL")]
        public void ConstantsHasBlizzardAPIBaseURL()
        {
            Assert.NotNull(Constants.BlizzardAPIBaseURL);
            Assert.NotEmpty(Constants.BlizzardAPIBaseURL);
            Assert.StartsWith("https://", Constants.BlizzardAPIBaseURL);
        }

        [Fact(DisplayName = "GetCharacterProfile overloads exist")]
        public void GetCharacterProfileOverloadsExist()
        {
            var methods = typeof(IWorldOfWarcraftCommunityAPI)
                .GetMethods()
                .Where(m => m.Name == "GetCharacterProfile")
                .ToList();
            
            Assert.NotEmpty(methods);
            // There should be at least 2 GetCharacterProfile methods
            Assert.True(methods.Count >= 2);
        }

        [Fact(DisplayName = "Character-specific methods exist")]
        public void CharacterSpecificMethodsExist()
        {
            var methods = typeof(IWorldOfWarcraftCommunityAPI).GetMethods();
            
            Assert.Contains(methods, m => m.Name == "GetCharacterAppearance");
            Assert.Contains(methods, m => m.Name == "GetCharacterFeed");
            Assert.Contains(methods, m => m.Name == "GetCharacterGuild");
        }
    }
}
