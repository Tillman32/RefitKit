using Refit;
using System.Threading.Tasks;

namespace RefitKit.Blizzard
{
    /// <summary>
    /// World of Warcraft Game Data API - Modern endpoints for game data access
    /// Requires OAuth 2.0 access token
    /// </summary>
    [Headers("Authorization: Bearer")]
    public interface IWorldOfWarcraftGameDataAPI
    {
        #region Achievement API

        /// <summary>
        /// Returns an index of achievements.
        /// </summary>
        [Get("/data/wow/achievement/index?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetAchievementIndex<TResponse>(string @namespace = "static-us", string locale = "en_US");

        /// <summary>
        /// Returns an achievement by ID.
        /// </summary>
        [Get("/data/wow/achievement/{achievementId}?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetAchievement<TResponse>(int achievementId, string @namespace = "static-us", string locale = "en_US");

        /// <summary>
        /// Returns an index of achievement categories.
        /// </summary>
        [Get("/data/wow/achievement-category/index?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetAchievementCategoryIndex<TResponse>(string @namespace = "static-us", string locale = "en_US");

        /// <summary>
        /// Returns an achievement category by ID.
        /// </summary>
        [Get("/data/wow/achievement-category/{achievementCategoryId}?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetAchievementCategory<TResponse>(int achievementCategoryId, string @namespace = "static-us", string locale = "en_US");

        #endregion

        #region Auction House API

        /// <summary>
        /// Returns all active auctions for a connected realm.
        /// </summary>
        [Get("/data/wow/connected-realm/{connectedRealmId}/auctions?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetAuctions<TResponse>(int connectedRealmId, string @namespace = "dynamic-us", string locale = "en_US");

        /// <summary>
        /// Returns all active commodity auctions.
        /// </summary>
        [Get("/data/wow/auctions/commodities?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetCommodityAuctions<TResponse>(string @namespace = "dynamic-us", string locale = "en_US");

        #endregion

        #region Connected Realm API

        /// <summary>
        /// Returns an index of connected realms.
        /// </summary>
        [Get("/data/wow/connected-realm/index?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetConnectedRealmIndex<TResponse>(string @namespace = "dynamic-us", string locale = "en_US");

        /// <summary>
        /// Returns a connected realm by ID.
        /// </summary>
        [Get("/data/wow/connected-realm/{connectedRealmId}?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetConnectedRealm<TResponse>(int connectedRealmId, string @namespace = "dynamic-us", string locale = "en_US");

        #endregion

        #region Creature API

        /// <summary>
        /// Returns a creature family by ID.
        /// </summary>
        [Get("/data/wow/creature-family/{creatureFamilyId}?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetCreatureFamily<TResponse>(int creatureFamilyId, string @namespace = "static-us", string locale = "en_US");

        /// <summary>
        /// Returns a creature type by ID.
        /// </summary>
        [Get("/data/wow/creature-type/{creatureTypeId}?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetCreatureType<TResponse>(int creatureTypeId, string @namespace = "static-us", string locale = "en_US");

        /// <summary>
        /// Returns a creature by ID.
        /// </summary>
        [Get("/data/wow/creature/{creatureId}?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetCreature<TResponse>(int creatureId, string @namespace = "static-us", string locale = "en_US");

        #endregion

        #region Guild Crest API

        /// <summary>
        /// Returns an index of guild crest media.
        /// </summary>
        [Get("/data/wow/guild-crest/index?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetGuildCrestIndex<TResponse>(string @namespace = "static-us", string locale = "en_US");

        #endregion

        #region Item API

        /// <summary>
        /// Returns an index of item classes.
        /// </summary>
        [Get("/data/wow/item-class/index?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetItemClassIndex<TResponse>(string @namespace = "static-us", string locale = "en_US");

        /// <summary>
        /// Returns an item class by ID.
        /// </summary>
        [Get("/data/wow/item-class/{itemClassId}?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetItemClass<TResponse>(int itemClassId, string @namespace = "static-us", string locale = "en_US");

        /// <summary>
        /// Returns an item by ID.
        /// </summary>
        [Get("/data/wow/item/{itemId}?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetItem<TResponse>(int itemId, string @namespace = "static-us", string locale = "en_US");

        /// <summary>
        /// Returns media for an item by ID.
        /// </summary>
        [Get("/data/wow/media/item/{itemId}?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetItemMedia<TResponse>(int itemId, string @namespace = "static-us", string locale = "en_US");

        #endregion

        #region Mount API

        /// <summary>
        /// Returns an index of mounts.
        /// </summary>
        [Get("/data/wow/mount/index?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetMountIndex<TResponse>(string @namespace = "static-us", string locale = "en_US");

        /// <summary>
        /// Returns a mount by ID.
        /// </summary>
        [Get("/data/wow/mount/{mountId}?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetMount<TResponse>(int mountId, string @namespace = "static-us", string locale = "en_US");

        #endregion

        #region Mythic Keystone API

        /// <summary>
        /// Returns an index of Mythic Keystone dungeons.
        /// </summary>
        [Get("/data/wow/mythic-keystone/dungeon/index?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetMythicKeystoneDungeonIndex<TResponse>(string @namespace = "dynamic-us", string locale = "en_US");

        /// <summary>
        /// Returns a Mythic Keystone dungeon by ID.
        /// </summary>
        [Get("/data/wow/mythic-keystone/dungeon/{dungeonId}?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetMythicKeystoneDungeon<TResponse>(int dungeonId, string @namespace = "dynamic-us", string locale = "en_US");

        /// <summary>
        /// Returns an index of Mythic Keystone periods.
        /// </summary>
        [Get("/data/wow/mythic-keystone/period/index?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetMythicKeystonePeriodIndex<TResponse>(string @namespace = "dynamic-us", string locale = "en_US");

        /// <summary>
        /// Returns a Mythic Keystone period by ID.
        /// </summary>
        [Get("/data/wow/mythic-keystone/period/{periodId}?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetMythicKeystonePeriod<TResponse>(int periodId, string @namespace = "dynamic-us", string locale = "en_US");

        /// <summary>
        /// Returns an index of Mythic Keystone seasons.
        /// </summary>
        [Get("/data/wow/mythic-keystone/season/index?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetMythicKeystoneSeasonIndex<TResponse>(string @namespace = "dynamic-us", string locale = "en_US");

        /// <summary>
        /// Returns a Mythic Keystone season by ID.
        /// </summary>
        [Get("/data/wow/mythic-keystone/season/{seasonId}?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetMythicKeystoneSeason<TResponse>(int seasonId, string @namespace = "dynamic-us", string locale = "en_US");

        #endregion

        #region Mythic Keystone Leaderboard API

        /// <summary>
        /// Returns an index of Mythic Keystone Leaderboards for a connected realm.
        /// </summary>
        [Get("/data/wow/connected-realm/{connectedRealmId}/mythic-leaderboard/index?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetMythicKeystoneLeaderboardIndex<TResponse>(int connectedRealmId, string @namespace = "dynamic-us", string locale = "en_US");

        /// <summary>
        /// Returns a Mythic Keystone Leaderboard for a dungeon and period.
        /// </summary>
        [Get("/data/wow/connected-realm/{connectedRealmId}/mythic-leaderboard/{dungeonId}/period/{period}?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetMythicKeystoneLeaderboard<TResponse>(int connectedRealmId, int dungeonId, int period, string @namespace = "dynamic-us", string locale = "en_US");

        #endregion

        #region Pet API

        /// <summary>
        /// Returns an index of pets.
        /// </summary>
        [Get("/data/wow/pet/index?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetPetIndex<TResponse>(string @namespace = "static-us", string locale = "en_US");

        /// <summary>
        /// Returns a pet by ID.
        /// </summary>
        [Get("/data/wow/pet/{petId}?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetPet<TResponse>(int petId, string @namespace = "static-us", string locale = "en_US");

        #endregion

        #region Playable Class API

        /// <summary>
        /// Returns an index of playable classes.
        /// </summary>
        [Get("/data/wow/playable-class/index?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetPlayableClassIndex<TResponse>(string @namespace = "static-us", string locale = "en_US");

        /// <summary>
        /// Returns a playable class by ID.
        /// </summary>
        [Get("/data/wow/playable-class/{classId}?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetPlayableClass<TResponse>(int classId, string @namespace = "static-us", string locale = "en_US");

        /// <summary>
        /// Returns media for a playable class by ID.
        /// </summary>
        [Get("/data/wow/media/playable-class/{classId}?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetPlayableClassMedia<TResponse>(int classId, string @namespace = "static-us", string locale = "en_US");

        #endregion

        #region Playable Race API

        /// <summary>
        /// Returns an index of playable races.
        /// </summary>
        [Get("/data/wow/playable-race/index?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetPlayableRaceIndex<TResponse>(string @namespace = "static-us", string locale = "en_US");

        /// <summary>
        /// Returns a playable race by ID.
        /// </summary>
        [Get("/data/wow/playable-race/{raceId}?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetPlayableRace<TResponse>(int raceId, string @namespace = "static-us", string locale = "en_US");

        #endregion

        #region Realm API

        /// <summary>
        /// Returns an index of realms.
        /// </summary>
        [Get("/data/wow/realm/index?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetRealmIndex<TResponse>(string @namespace = "dynamic-us", string locale = "en_US");

        /// <summary>
        /// Returns a realm by slug.
        /// </summary>
        [Get("/data/wow/realm/{realmSlug}?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetRealm<TResponse>(string realmSlug, string @namespace = "dynamic-us", string locale = "en_US");

        #endregion

        #region Region API

        /// <summary>
        /// Returns an index of regions.
        /// </summary>
        [Get("/data/wow/region/index?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetRegionIndex<TResponse>(string @namespace = "dynamic-us", string locale = "en_US");

        /// <summary>
        /// Returns a region by ID.
        /// </summary>
        [Get("/data/wow/region/{regionId}?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetRegion<TResponse>(int regionId, string @namespace = "dynamic-us", string locale = "en_US");

        #endregion

        #region Spell API

        /// <summary>
        /// Returns a spell by ID.
        /// </summary>
        [Get("/data/wow/spell/{spellId}?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetSpell<TResponse>(int spellId, string @namespace = "static-us", string locale = "en_US");

        /// <summary>
        /// Returns media for a spell by ID.
        /// </summary>
        [Get("/data/wow/media/spell/{spellId}?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetSpellMedia<TResponse>(int spellId, string @namespace = "static-us", string locale = "en_US");

        #endregion

        #region Title API

        /// <summary>
        /// Returns an index of titles.
        /// </summary>
        [Get("/data/wow/title/index?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetTitleIndex<TResponse>(string @namespace = "static-us", string locale = "en_US");

        /// <summary>
        /// Returns a title by ID.
        /// </summary>
        [Get("/data/wow/title/{titleId}?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetTitle<TResponse>(int titleId, string @namespace = "static-us", string locale = "en_US");

        #endregion

        #region WoW Token API

        /// <summary>
        /// Returns the WoW Token index (current token price).
        /// </summary>
        [Get("/data/wow/token/index?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetWoWTokenIndex<TResponse>(string @namespace = "dynamic-us", string locale = "en_US");

        #endregion
    }
}
