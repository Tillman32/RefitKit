using Refit;
using System.Threading.Tasks;

namespace RefitKit.Blizzard
{
    /// <summary>
    /// World of Warcraft Profile API - Access to player profile data
    /// Requires OAuth 2.0 access token with appropriate scopes
    /// </summary>
    [Headers("Authorization: Bearer")]
    public interface IWorldOfWarcraftProfileAPI
    {
        #region Account Profile API

        /// <summary>
        /// Returns a profile summary for an account.
        /// Requires wow.profile scope.
        /// </summary>
        [Get("/profile/user/wow?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetAccountProfileSummary<TResponse>(string @namespace = "profile-us", string locale = "en_US");

        /// <summary>
        /// Returns a summary of the protected characters for an account.
        /// Requires wow.profile scope.
        /// </summary>
        [Get("/profile/user/wow/protected-character/{realmId}-{characterId}?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetProtectedCharacterProfile<TResponse>(int realmId, int characterId, string @namespace = "profile-us", string locale = "en_US");

        /// <summary>
        /// Returns a summary of the collections for an account.
        /// Requires wow.profile scope.
        /// </summary>
        [Get("/profile/user/wow/collections?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetAccountCollectionsIndex<TResponse>(string @namespace = "profile-us", string locale = "en_US");

        /// <summary>
        /// Returns a summary of the mounts for an account.
        /// Requires wow.profile scope.
        /// </summary>
        [Get("/profile/user/wow/collections/mounts?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetAccountMounts<TResponse>(string @namespace = "profile-us", string locale = "en_US");

        /// <summary>
        /// Returns a summary of the battle pets for an account.
        /// Requires wow.profile scope.
        /// </summary>
        [Get("/profile/user/wow/collections/pets?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetAccountPets<TResponse>(string @namespace = "profile-us", string locale = "en_US");

        #endregion

        #region Character Achievements API

        /// <summary>
        /// Returns a summary of the achievements for a character.
        /// </summary>
        [Get("/profile/wow/character/{realmSlug}/{characterName}/achievements?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetCharacterAchievementsSummary<TResponse>(string realmSlug, string characterName, string @namespace = "profile-us", string locale = "en_US");

        /// <summary>
        /// Returns a character's statistics.
        /// </summary>
        [Get("/profile/wow/character/{realmSlug}/{characterName}/achievements/statistics?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetCharacterAchievementStatistics<TResponse>(string realmSlug, string characterName, string @namespace = "profile-us", string locale = "en_US");

        #endregion

        #region Character Appearance API

        /// <summary>
        /// Returns a summary of a character's appearance settings.
        /// </summary>
        [Get("/profile/wow/character/{realmSlug}/{characterName}/appearance?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetCharacterAppearanceSummary<TResponse>(string realmSlug, string characterName, string @namespace = "profile-us", string locale = "en_US");

        #endregion

        #region Character Collections API

        /// <summary>
        /// Returns an index of collection types for a character.
        /// </summary>
        [Get("/profile/wow/character/{realmSlug}/{characterName}/collections?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetCharacterCollectionsIndex<TResponse>(string realmSlug, string characterName, string @namespace = "profile-us", string locale = "en_US");

        /// <summary>
        /// Returns a summary of the mounts for a character.
        /// </summary>
        [Get("/profile/wow/character/{realmSlug}/{characterName}/collections/mounts?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetCharacterMounts<TResponse>(string realmSlug, string characterName, string @namespace = "profile-us", string locale = "en_US");

        /// <summary>
        /// Returns a summary of the battle pets for a character.
        /// </summary>
        [Get("/profile/wow/character/{realmSlug}/{characterName}/collections/pets?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetCharacterPets<TResponse>(string realmSlug, string characterName, string @namespace = "profile-us", string locale = "en_US");

        #endregion

        #region Character Encounters API

        /// <summary>
        /// Returns a summary of a character's encounters.
        /// </summary>
        [Get("/profile/wow/character/{realmSlug}/{characterName}/encounters?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetCharacterEncountersSummary<TResponse>(string realmSlug, string characterName, string @namespace = "profile-us", string locale = "en_US");

        /// <summary>
        /// Returns a summary of a character's completed dungeons.
        /// </summary>
        [Get("/profile/wow/character/{realmSlug}/{characterName}/encounters/dungeons?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetCharacterDungeons<TResponse>(string realmSlug, string characterName, string @namespace = "profile-us", string locale = "en_US");

        /// <summary>
        /// Returns a summary of a character's completed raids.
        /// </summary>
        [Get("/profile/wow/character/{realmSlug}/{characterName}/encounters/raids?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetCharacterRaids<TResponse>(string realmSlug, string characterName, string @namespace = "profile-us", string locale = "en_US");

        #endregion

        #region Character Equipment API

        /// <summary>
        /// Returns a summary of the equipment for a character.
        /// </summary>
        [Get("/profile/wow/character/{realmSlug}/{characterName}/equipment?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetCharacterEquipmentSummary<TResponse>(string realmSlug, string characterName, string @namespace = "profile-us", string locale = "en_US");

        #endregion

        #region Character Hunter Pets API

        /// <summary>
        /// Returns a summary of a character's hunter pets (if the character is a hunter).
        /// </summary>
        [Get("/profile/wow/character/{realmSlug}/{characterName}/hunter-pets?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetCharacterHunterPetsSummary<TResponse>(string realmSlug, string characterName, string @namespace = "profile-us", string locale = "en_US");

        #endregion

        #region Character Media API

        /// <summary>
        /// Returns a summary of the media assets available for a character (such as an avatar render).
        /// </summary>
        [Get("/profile/wow/character/{realmSlug}/{characterName}/character-media?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetCharacterMediaSummary<TResponse>(string realmSlug, string characterName, string @namespace = "profile-us", string locale = "en_US");

        #endregion

        #region Character Mythic Keystone Profile API

        /// <summary>
        /// Returns the Mythic Keystone profile index for a character.
        /// </summary>
        [Get("/profile/wow/character/{realmSlug}/{characterName}/mythic-keystone-profile?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetCharacterMythicKeystoneProfile<TResponse>(string realmSlug, string characterName, string @namespace = "profile-us", string locale = "en_US");

        /// <summary>
        /// Returns the Mythic Keystone season details for a character.
        /// </summary>
        [Get("/profile/wow/character/{realmSlug}/{characterName}/mythic-keystone-profile/season/{seasonId}?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetCharacterMythicKeystoneSeason<TResponse>(string realmSlug, string characterName, int seasonId, string @namespace = "profile-us", string locale = "en_US");

        #endregion

        #region Character Professions API

        /// <summary>
        /// Returns a summary of a character's professions.
        /// </summary>
        [Get("/profile/wow/character/{realmSlug}/{characterName}/professions?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetCharacterProfessionsSummary<TResponse>(string realmSlug, string characterName, string @namespace = "profile-us", string locale = "en_US");

        #endregion

        #region Character Profile API

        /// <summary>
        /// Returns a profile summary for a character.
        /// </summary>
        [Get("/profile/wow/character/{realmSlug}/{characterName}?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetCharacterProfileSummary<TResponse>(string realmSlug, string characterName, string @namespace = "profile-us", string locale = "en_US");

        /// <summary>
        /// Returns the status and a summary of a character.
        /// </summary>
        [Get("/profile/wow/character/{realmSlug}/{characterName}/status?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetCharacterProfileStatus<TResponse>(string realmSlug, string characterName, string @namespace = "profile-us", string locale = "en_US");

        #endregion

        #region Character PvP API

        /// <summary>
        /// Returns a PvP bracket statistics for a character.
        /// </summary>
        [Get("/profile/wow/character/{realmSlug}/{characterName}/pvp-bracket/{pvpBracket}?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetCharacterPvPBracketStatistics<TResponse>(string realmSlug, string characterName, string pvpBracket, string @namespace = "profile-us", string locale = "en_US");

        /// <summary>
        /// Returns a PvP summary for a character.
        /// </summary>
        [Get("/profile/wow/character/{realmSlug}/{characterName}/pvp-summary?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetCharacterPvPSummary<TResponse>(string realmSlug, string characterName, string @namespace = "profile-us", string locale = "en_US");

        #endregion

        #region Character Quests API

        /// <summary>
        /// Returns a character's completed quests.
        /// </summary>
        [Get("/profile/wow/character/{realmSlug}/{characterName}/quests/completed?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetCharacterCompletedQuests<TResponse>(string realmSlug, string characterName, string @namespace = "profile-us", string locale = "en_US");

        #endregion

        #region Character Reputations API

        /// <summary>
        /// Returns a summary of a character's reputations.
        /// </summary>
        [Get("/profile/wow/character/{realmSlug}/{characterName}/reputations?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetCharacterReputationsSummary<TResponse>(string realmSlug, string characterName, string @namespace = "profile-us", string locale = "en_US");

        #endregion

        #region Character Specializations API

        /// <summary>
        /// Returns a summary of a character's specializations.
        /// </summary>
        [Get("/profile/wow/character/{realmSlug}/{characterName}/specializations?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetCharacterSpecializationsSummary<TResponse>(string realmSlug, string characterName, string @namespace = "profile-us", string locale = "en_US");

        #endregion

        #region Character Statistics API

        /// <summary>
        /// Returns a statistics summary for a character.
        /// </summary>
        [Get("/profile/wow/character/{realmSlug}/{characterName}/statistics?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetCharacterStatisticsSummary<TResponse>(string realmSlug, string characterName, string @namespace = "profile-us", string locale = "en_US");

        #endregion

        #region Character Titles API

        /// <summary>
        /// Returns a summary of a character's titles.
        /// </summary>
        [Get("/profile/wow/character/{realmSlug}/{characterName}/titles?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetCharacterTitlesSummary<TResponse>(string realmSlug, string characterName, string @namespace = "profile-us", string locale = "en_US");

        #endregion

        #region Guild API

        /// <summary>
        /// Returns a guild by realm and name.
        /// </summary>
        [Get("/data/wow/guild/{realmSlug}/{nameSlug}?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetGuild<TResponse>(string realmSlug, string nameSlug, string @namespace = "profile-us", string locale = "en_US");

        /// <summary>
        /// Returns a summary of the activity for a guild.
        /// </summary>
        [Get("/data/wow/guild/{realmSlug}/{nameSlug}/activity?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetGuildActivity<TResponse>(string realmSlug, string nameSlug, string @namespace = "profile-us", string locale = "en_US");

        /// <summary>
        /// Returns a summary of the achievements earned by a guild.
        /// </summary>
        [Get("/data/wow/guild/{realmSlug}/{nameSlug}/achievements?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetGuildAchievements<TResponse>(string realmSlug, string nameSlug, string @namespace = "profile-us", string locale = "en_US");

        /// <summary>
        /// Returns a roster of members for a guild.
        /// </summary>
        [Get("/data/wow/guild/{realmSlug}/{nameSlug}/roster?namespace={namespace}&locale={locale}")]
        Task<TResponse> GetGuildRoster<TResponse>(string realmSlug, string nameSlug, string @namespace = "profile-us", string locale = "en_US");

        #endregion
    }
}
