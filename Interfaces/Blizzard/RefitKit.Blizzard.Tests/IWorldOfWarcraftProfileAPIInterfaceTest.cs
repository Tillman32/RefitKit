using Refit;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;

namespace RefitKit.Blizzard.Tests
{
    public class IWorldOfWarcraftProfileAPIInterfaceTest
    {
        [Fact(DisplayName = "Interface has Authorization Bearer header")]
        public void InterfaceHasAuthorizationHeader()
        {
            var headersAttr = typeof(IWorldOfWarcraftProfileAPI).GetCustomAttribute<HeadersAttribute>();
            Assert.NotNull(headersAttr);
            Assert.Contains("Authorization: Bearer", headersAttr!.Headers);
        }

        [Fact(DisplayName = "Interface has account profile endpoints")]
        public void InterfaceHasAccountProfileEndpoints()
        {
            var methods = typeof(IWorldOfWarcraftProfileAPI).GetMethods();
            
            Assert.Contains(methods, m => m.Name == "GetAccountProfileSummary");
            Assert.Contains(methods, m => m.Name == "GetProtectedCharacterProfile");
            Assert.Contains(methods, m => m.Name == "GetAccountCollectionsIndex");
            Assert.Contains(methods, m => m.Name == "GetAccountMounts");
            Assert.Contains(methods, m => m.Name == "GetAccountPets");
        }

        [Fact(DisplayName = "Interface has character profile endpoints")]
        public void InterfaceHasCharacterProfileEndpoints()
        {
            var methods = typeof(IWorldOfWarcraftProfileAPI).GetMethods();
            
            Assert.Contains(methods, m => m.Name == "GetCharacterProfileSummary");
            Assert.Contains(methods, m => m.Name == "GetCharacterProfileStatus");
        }

        [Fact(DisplayName = "Interface has character achievements endpoints")]
        public void InterfaceHasCharacterAchievementsEndpoints()
        {
            var methods = typeof(IWorldOfWarcraftProfileAPI).GetMethods();
            
            Assert.Contains(methods, m => m.Name == "GetCharacterAchievementsSummary");
            Assert.Contains(methods, m => m.Name == "GetCharacterAchievementStatistics");
        }

        [Fact(DisplayName = "Interface has character appearance endpoint")]
        public void InterfaceHasCharacterAppearanceEndpoint()
        {
            var methods = typeof(IWorldOfWarcraftProfileAPI).GetMethods();
            
            Assert.Contains(methods, m => m.Name == "GetCharacterAppearanceSummary");
        }

        [Fact(DisplayName = "Interface has character collections endpoints")]
        public void InterfaceHasCharacterCollectionsEndpoints()
        {
            var methods = typeof(IWorldOfWarcraftProfileAPI).GetMethods();
            
            Assert.Contains(methods, m => m.Name == "GetCharacterCollectionsIndex");
            Assert.Contains(methods, m => m.Name == "GetCharacterMounts");
            Assert.Contains(methods, m => m.Name == "GetCharacterPets");
        }

        [Fact(DisplayName = "Interface has character encounters endpoints")]
        public void InterfaceHasCharacterEncountersEndpoints()
        {
            var methods = typeof(IWorldOfWarcraftProfileAPI).GetMethods();
            
            Assert.Contains(methods, m => m.Name == "GetCharacterEncountersSummary");
            Assert.Contains(methods, m => m.Name == "GetCharacterDungeons");
            Assert.Contains(methods, m => m.Name == "GetCharacterRaids");
        }

        [Fact(DisplayName = "Interface has character equipment endpoint")]
        public void InterfaceHasCharacterEquipmentEndpoint()
        {
            var methods = typeof(IWorldOfWarcraftProfileAPI).GetMethods();
            
            Assert.Contains(methods, m => m.Name == "GetCharacterEquipmentSummary");
        }

        [Fact(DisplayName = "Interface has character hunter pets endpoint")]
        public void InterfaceHasCharacterHunterPetsEndpoint()
        {
            var methods = typeof(IWorldOfWarcraftProfileAPI).GetMethods();
            
            Assert.Contains(methods, m => m.Name == "GetCharacterHunterPetsSummary");
        }

        [Fact(DisplayName = "Interface has character media endpoint")]
        public void InterfaceHasCharacterMediaEndpoint()
        {
            var methods = typeof(IWorldOfWarcraftProfileAPI).GetMethods();
            
            Assert.Contains(methods, m => m.Name == "GetCharacterMediaSummary");
        }

        [Fact(DisplayName = "Interface has character mythic keystone endpoints")]
        public void InterfaceHasCharacterMythicKeystoneEndpoints()
        {
            var methods = typeof(IWorldOfWarcraftProfileAPI).GetMethods();
            
            Assert.Contains(methods, m => m.Name == "GetCharacterMythicKeystoneProfile");
            Assert.Contains(methods, m => m.Name == "GetCharacterMythicKeystoneSeason");
        }

        [Fact(DisplayName = "Interface has character professions endpoint")]
        public void InterfaceHasCharacterProfessionsEndpoint()
        {
            var methods = typeof(IWorldOfWarcraftProfileAPI).GetMethods();
            
            Assert.Contains(methods, m => m.Name == "GetCharacterProfessionsSummary");
        }

        [Fact(DisplayName = "Interface has character PvP endpoints")]
        public void InterfaceHasCharacterPvPEndpoints()
        {
            var methods = typeof(IWorldOfWarcraftProfileAPI).GetMethods();
            
            Assert.Contains(methods, m => m.Name == "GetCharacterPvPBracketStatistics");
            Assert.Contains(methods, m => m.Name == "GetCharacterPvPSummary");
        }

        [Fact(DisplayName = "Interface has character quests endpoint")]
        public void InterfaceHasCharacterQuestsEndpoint()
        {
            var methods = typeof(IWorldOfWarcraftProfileAPI).GetMethods();
            
            Assert.Contains(methods, m => m.Name == "GetCharacterCompletedQuests");
        }

        [Fact(DisplayName = "Interface has character reputations endpoint")]
        public void InterfaceHasCharacterReputationsEndpoint()
        {
            var methods = typeof(IWorldOfWarcraftProfileAPI).GetMethods();
            
            Assert.Contains(methods, m => m.Name == "GetCharacterReputationsSummary");
        }

        [Fact(DisplayName = "Interface has character specializations endpoint")]
        public void InterfaceHasCharacterSpecializationsEndpoint()
        {
            var methods = typeof(IWorldOfWarcraftProfileAPI).GetMethods();
            
            Assert.Contains(methods, m => m.Name == "GetCharacterSpecializationsSummary");
        }

        [Fact(DisplayName = "Interface has character statistics endpoint")]
        public void InterfaceHasCharacterStatisticsEndpoint()
        {
            var methods = typeof(IWorldOfWarcraftProfileAPI).GetMethods();
            
            Assert.Contains(methods, m => m.Name == "GetCharacterStatisticsSummary");
        }

        [Fact(DisplayName = "Interface has character titles endpoint")]
        public void InterfaceHasCharacterTitlesEndpoint()
        {
            var methods = typeof(IWorldOfWarcraftProfileAPI).GetMethods();
            
            Assert.Contains(methods, m => m.Name == "GetCharacterTitlesSummary");
        }

        [Fact(DisplayName = "Interface has guild endpoints")]
        public void InterfaceHasGuildEndpoints()
        {
            var methods = typeof(IWorldOfWarcraftProfileAPI).GetMethods();
            
            Assert.Contains(methods, m => m.Name == "GetGuild");
            Assert.Contains(methods, m => m.Name == "GetGuildActivity");
            Assert.Contains(methods, m => m.Name == "GetGuildAchievements");
            Assert.Contains(methods, m => m.Name == "GetGuildRoster");
        }

        [Fact(DisplayName = "All methods return Task")]
        public void AllMethodsReturnTask()
        {
            var methods = typeof(IWorldOfWarcraftProfileAPI).GetMethods();
            
            foreach (var method in methods)
            {
                Assert.True(method.ReturnType.IsGenericType);
                Assert.Equal(typeof(Task<>), method.ReturnType.GetGenericTypeDefinition());
            }
        }

        [Fact(DisplayName = "GetAccountProfileSummary has correct Refit attributes")]
        public void GetAccountProfileSummaryHasCorrectAttributes()
        {
            var method = typeof(IWorldOfWarcraftProfileAPI).GetMethod("GetAccountProfileSummary");
            Assert.NotNull(method);
            
            var getAttr = method!.GetCustomAttribute<GetAttribute>();
            Assert.NotNull(getAttr);
            Assert.Contains("/profile/user/wow", getAttr!.Path);
        }

        [Fact(DisplayName = "GetCharacterProfileSummary has correct Refit attributes")]
        public void GetCharacterProfileSummaryHasCorrectAttributes()
        {
            var method = typeof(IWorldOfWarcraftProfileAPI).GetMethod("GetCharacterProfileSummary");
            Assert.NotNull(method);
            
            var getAttr = method!.GetCustomAttribute<GetAttribute>();
            Assert.NotNull(getAttr);
            Assert.Contains("/profile/wow/character", getAttr!.Path);
        }

        [Fact(DisplayName = "GetCharacterMythicKeystoneProfile has correct Refit attributes")]
        public void GetCharacterMythicKeystoneProfileHasCorrectAttributes()
        {
            var method = typeof(IWorldOfWarcraftProfileAPI).GetMethod("GetCharacterMythicKeystoneProfile");
            Assert.NotNull(method);
            
            var getAttr = method!.GetCustomAttribute<GetAttribute>();
            Assert.NotNull(getAttr);
            Assert.Contains("mythic-keystone-profile", getAttr!.Path);
        }

        [Fact(DisplayName = "GetGuild has correct Refit attributes")]
        public void GetGuildHasCorrectAttributes()
        {
            var method = typeof(IWorldOfWarcraftProfileAPI).GetMethod("GetGuild");
            Assert.NotNull(method);
            
            var getAttr = method!.GetCustomAttribute<GetAttribute>();
            Assert.NotNull(getAttr);
            Assert.Contains("/data/wow/guild", getAttr!.Path);
        }
    }
}
