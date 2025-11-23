using Refit;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;

namespace RefitKit.Blizzard.Tests
{
    public class IWorldOfWarcraftGameDataAPIInterfaceTest
    {
        [Fact(DisplayName = "Interface has Authorization Bearer header")]
        public void InterfaceHasAuthorizationHeader()
        {
            var headersAttr = typeof(IWorldOfWarcraftGameDataAPI).GetCustomAttribute<HeadersAttribute>();
            Assert.NotNull(headersAttr);
            Assert.Contains("Authorization: Bearer", headersAttr!.Headers);
        }

        [Fact(DisplayName = "Interface has achievement endpoints")]
        public void InterfaceHasAchievementEndpoints()
        {
            var methods = typeof(IWorldOfWarcraftGameDataAPI).GetMethods();
            
            Assert.Contains(methods, m => m.Name == "GetAchievementIndex");
            Assert.Contains(methods, m => m.Name == "GetAchievement");
            Assert.Contains(methods, m => m.Name == "GetAchievementCategoryIndex");
            Assert.Contains(methods, m => m.Name == "GetAchievementCategory");
        }

        [Fact(DisplayName = "Interface has auction house endpoints")]
        public void InterfaceHasAuctionHouseEndpoints()
        {
            var methods = typeof(IWorldOfWarcraftGameDataAPI).GetMethods();
            
            Assert.Contains(methods, m => m.Name == "GetAuctions");
            Assert.Contains(methods, m => m.Name == "GetCommodityAuctions");
        }

        [Fact(DisplayName = "Interface has connected realm endpoints")]
        public void InterfaceHasConnectedRealmEndpoints()
        {
            var methods = typeof(IWorldOfWarcraftGameDataAPI).GetMethods();
            
            Assert.Contains(methods, m => m.Name == "GetConnectedRealmIndex");
            Assert.Contains(methods, m => m.Name == "GetConnectedRealm");
        }

        [Fact(DisplayName = "Interface has creature endpoints")]
        public void InterfaceHasCreatureEndpoints()
        {
            var methods = typeof(IWorldOfWarcraftGameDataAPI).GetMethods();
            
            Assert.Contains(methods, m => m.Name == "GetCreatureFamily");
            Assert.Contains(methods, m => m.Name == "GetCreatureType");
            Assert.Contains(methods, m => m.Name == "GetCreature");
        }

        [Fact(DisplayName = "Interface has item endpoints")]
        public void InterfaceHasItemEndpoints()
        {
            var methods = typeof(IWorldOfWarcraftGameDataAPI).GetMethods();
            
            Assert.Contains(methods, m => m.Name == "GetItemClassIndex");
            Assert.Contains(methods, m => m.Name == "GetItemClass");
            Assert.Contains(methods, m => m.Name == "GetItem");
            Assert.Contains(methods, m => m.Name == "GetItemMedia");
        }

        [Fact(DisplayName = "Interface has mount endpoints")]
        public void InterfaceHasMountEndpoints()
        {
            var methods = typeof(IWorldOfWarcraftGameDataAPI).GetMethods();
            
            Assert.Contains(methods, m => m.Name == "GetMountIndex");
            Assert.Contains(methods, m => m.Name == "GetMount");
        }

        [Fact(DisplayName = "Interface has mythic keystone endpoints")]
        public void InterfaceHasMythicKeystoneEndpoints()
        {
            var methods = typeof(IWorldOfWarcraftGameDataAPI).GetMethods();
            
            Assert.Contains(methods, m => m.Name == "GetMythicKeystoneDungeonIndex");
            Assert.Contains(methods, m => m.Name == "GetMythicKeystoneDungeon");
            Assert.Contains(methods, m => m.Name == "GetMythicKeystonePeriodIndex");
            Assert.Contains(methods, m => m.Name == "GetMythicKeystonePeriod");
            Assert.Contains(methods, m => m.Name == "GetMythicKeystoneSeasonIndex");
            Assert.Contains(methods, m => m.Name == "GetMythicKeystoneSeason");
        }

        [Fact(DisplayName = "Interface has mythic keystone leaderboard endpoints")]
        public void InterfaceHasMythicKeystoneLeaderboardEndpoints()
        {
            var methods = typeof(IWorldOfWarcraftGameDataAPI).GetMethods();
            
            Assert.Contains(methods, m => m.Name == "GetMythicKeystoneLeaderboardIndex");
            Assert.Contains(methods, m => m.Name == "GetMythicKeystoneLeaderboard");
        }

        [Fact(DisplayName = "Interface has pet endpoints")]
        public void InterfaceHasPetEndpoints()
        {
            var methods = typeof(IWorldOfWarcraftGameDataAPI).GetMethods();
            
            Assert.Contains(methods, m => m.Name == "GetPetIndex");
            Assert.Contains(methods, m => m.Name == "GetPet");
        }

        [Fact(DisplayName = "Interface has playable class endpoints")]
        public void InterfaceHasPlayableClassEndpoints()
        {
            var methods = typeof(IWorldOfWarcraftGameDataAPI).GetMethods();
            
            Assert.Contains(methods, m => m.Name == "GetPlayableClassIndex");
            Assert.Contains(methods, m => m.Name == "GetPlayableClass");
            Assert.Contains(methods, m => m.Name == "GetPlayableClassMedia");
        }

        [Fact(DisplayName = "Interface has playable race endpoints")]
        public void InterfaceHasPlayableRaceEndpoints()
        {
            var methods = typeof(IWorldOfWarcraftGameDataAPI).GetMethods();
            
            Assert.Contains(methods, m => m.Name == "GetPlayableRaceIndex");
            Assert.Contains(methods, m => m.Name == "GetPlayableRace");
        }

        [Fact(DisplayName = "Interface has realm endpoints")]
        public void InterfaceHasRealmEndpoints()
        {
            var methods = typeof(IWorldOfWarcraftGameDataAPI).GetMethods();
            
            Assert.Contains(methods, m => m.Name == "GetRealmIndex");
            Assert.Contains(methods, m => m.Name == "GetRealm");
        }

        [Fact(DisplayName = "Interface has region endpoints")]
        public void InterfaceHasRegionEndpoints()
        {
            var methods = typeof(IWorldOfWarcraftGameDataAPI).GetMethods();
            
            Assert.Contains(methods, m => m.Name == "GetRegionIndex");
            Assert.Contains(methods, m => m.Name == "GetRegion");
        }

        [Fact(DisplayName = "Interface has spell endpoints")]
        public void InterfaceHasSpellEndpoints()
        {
            var methods = typeof(IWorldOfWarcraftGameDataAPI).GetMethods();
            
            Assert.Contains(methods, m => m.Name == "GetSpell");
            Assert.Contains(methods, m => m.Name == "GetSpellMedia");
        }

        [Fact(DisplayName = "Interface has title endpoints")]
        public void InterfaceHasTitleEndpoints()
        {
            var methods = typeof(IWorldOfWarcraftGameDataAPI).GetMethods();
            
            Assert.Contains(methods, m => m.Name == "GetTitleIndex");
            Assert.Contains(methods, m => m.Name == "GetTitle");
        }

        [Fact(DisplayName = "Interface has WoW Token endpoint")]
        public void InterfaceHasWoWTokenEndpoint()
        {
            var methods = typeof(IWorldOfWarcraftGameDataAPI).GetMethods();
            
            Assert.Contains(methods, m => m.Name == "GetWoWTokenIndex");
        }

        [Fact(DisplayName = "All methods return Task")]
        public void AllMethodsReturnTask()
        {
            var methods = typeof(IWorldOfWarcraftGameDataAPI).GetMethods();
            
            foreach (var method in methods)
            {
                Assert.True(method.ReturnType.IsGenericType);
                Assert.Equal(typeof(Task<>), method.ReturnType.GetGenericTypeDefinition());
            }
        }

        [Fact(DisplayName = "GetAchievementIndex has correct Refit attributes")]
        public void GetAchievementIndexHasCorrectAttributes()
        {
            var method = typeof(IWorldOfWarcraftGameDataAPI).GetMethod("GetAchievementIndex");
            Assert.NotNull(method);
            
            var getAttr = method!.GetCustomAttribute<GetAttribute>();
            Assert.NotNull(getAttr);
            Assert.Contains("/data/wow/achievement/index", getAttr!.Path);
        }

        [Fact(DisplayName = "GetAuctions has correct Refit attributes")]
        public void GetAuctionsHasCorrectAttributes()
        {
            var method = typeof(IWorldOfWarcraftGameDataAPI).GetMethod("GetAuctions");
            Assert.NotNull(method);
            
            var getAttr = method!.GetCustomAttribute<GetAttribute>();
            Assert.NotNull(getAttr);
            Assert.Contains("/data/wow/connected-realm", getAttr!.Path);
            Assert.Contains("auctions", getAttr.Path);
        }

        [Fact(DisplayName = "GetMythicKeystoneLeaderboard has correct Refit attributes")]
        public void GetMythicKeystoneLeaderboardHasCorrectAttributes()
        {
            var method = typeof(IWorldOfWarcraftGameDataAPI).GetMethod("GetMythicKeystoneLeaderboard");
            Assert.NotNull(method);
            
            var getAttr = method!.GetCustomAttribute<GetAttribute>();
            Assert.NotNull(getAttr);
            Assert.Contains("mythic-leaderboard", getAttr!.Path);
        }
    }
}
