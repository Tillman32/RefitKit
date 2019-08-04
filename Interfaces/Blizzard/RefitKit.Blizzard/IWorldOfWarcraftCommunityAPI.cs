using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RefitKit.Blizzard
{
    [Headers("Authorization: Bearer")]
    public interface IWorldOfWarcraftCommunityAPI
    {
        /// <summary>
        /// Achievement API
        /// </summary>
        /// <typeparam name="TResponse">Response Type.</typeparam>
        /// <param name="id">The ID of the achievement to retrieve.</param>
        /// <param name="region">The region of the data to retrieve.</param>
        /// <param name="locale">The locale to reflect in localized data.</param>
        /// <returns></returns>
        [Get("/wow/achievement/{id}?region={region}&locale={locale}")]
        Task<TResponse> GetAchievement<TResponse>(int id, string region = "us", string locale = "en_US");

        /// <summary>
        /// Auction APIs currently provide rolling batches of data about current auctions. Fetching auction dumps is a two-step process that involves checking a per-realm index file to determine if a recent dump has been generated and then fetching the most recently generated dump file (if necessary).
        /// This API resource provides a per-realm list of recently generated auction house data dumps.
        /// </summary>
        /// <typeparam name="TResponse">Response Type.</typeparam>
        /// <param name="realm">The realm to request.</param>
        /// <param name="region">The region of the data to retrieve.</param>
        /// <param name="locale">The locale to reflect in localized data.</param>
        /// <returns></returns>
        [Get("/wow/auction/data/{realm}?region={region}&locale={locale}")]
        Task<TResponse> GetAuctionData<TResponse>(string realm, string region = "us", string locale = "en_US");

        /// <summary>
        /// Returns a list of all supported bosses. A "boss" in this context should be considered a boss encounter, which may include more than one NPC.
        /// </summary>
        /// <typeparam name="TResponse">Response Type.</typeparam>
        /// <param name="region">The region of the data to retrieve.</param>
        /// <param name="locale">The locale to reflect in localized data.</param>
        /// <returns></returns>
        [Get("/wow/boss/")]
        Task<TResponse> GetBossList<TResponse>(string region = "us", string locale = "en_US");

        /// <summary>
        /// The boss API provides information about bosses. A "boss" in this context should be considered a boss encounter, which may include more than one NPC.
        /// </summary>
        /// <typeparam name="TResponse">Response Type.</typeparam>
        /// <param name="bossId">The ID of the boss to retrieve.</param>
        /// <param name="region">The region of the data to retrieve.</param>
        /// <param name="locale">The locale to reflect in localized data.</param>
        /// <returns></returns>
        [Get("/wow/boss/{bossId}")]
        Task<TResponse> GetBoss<TResponse>(int bossId, string region = "us", string locale = "en_US");

        /// <summary>
        /// The request returns data for all nine challenge mode maps (currently).
        /// </summary>
        /// <typeparam name="TResponse">Response Type.</typeparam>
        /// <param name="realm">The realm to request.</param>
        /// <param name="region">The region of the data to retrieve.</param>
        /// <param name="locale">The locale to reflect in localized data.</param>
        /// <returns></returns>
        [Get("/wow/challenge/{realm}")]
        Task<TResponse> GetRealmLeaderboard<TResponse>(string realm, string region = "us", string locale = "en_US");

        /// <summary>
        /// The region leaderboard has the exact same data format as the realm leaderboards except there is no realm field. 
        /// Instead, the response has the top 100 results gathered for each map for all of the available realm leaderboards in a region.
        /// </summary>
        /// <typeparam name="TResponse">Response Type.</typeparam>
        /// <param name="region">The region of the data to retrieve.</param>
        /// <param name="locale">The locale to reflect in localized data.</param>
        /// <returns></returns>
        [Get("/wow/challenge/region")]
        Task<TResponse> GetRegionLeaderboard<TResponse>(string region = "us", string locale = "en_US");

        [Get("/wow/character/{realm}/{characterName}/fields={fields}")]
        Task<TResponse> GetCharacterProfile<TResponse>(string realm, string characterName, string fields = null, string region = "us", string locale = "en_US");

        [Get("/wow/character/{realm}/{characterName}?fields=achievements")]
        Task<TResponse> GetCharacterProfile<TResponse>(string realm, string characterName, string region = "us", string locale = "en_US");

        [Get("/wow/character/{realm}/{characterName}?fields=appearance")]
        Task<TResponse> GetCharacterAppearance<TResponse>(string realm, string characterName, string region = "us", string locale = "en_US");

        [Get("/wow/character/{realm}/{characterName}?fields=feed")]
        Task<TResponse> GetCharacterFeed<TResponse>(string realm, string characterName, string region = "us", string locale = "en_US");

        [Get("/wow/character/{realm}/{characterName}?fields=guild")]
        Task<TResponse> GetCharacterGuild<TResponse>(string realm, string characterName, string region = "us", string locale = "en_US");

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TResponse">Response Type.</typeparam>
        /// <param name="limitRealms">CSV string of realms</param>
        /// <param name="region">The region of the data to retrieve.</param>
        /// <param name="locale">The locale to reflect in localized data.</param>
        /// <returns></returns>
        [Get("/wow/realm/status?realms={limitRealms}&region={region}&locale={locale}")]
        Task<TResponse> GetRealmStatus<TResponse>(string limitRealms = null, string region = "us", string locale = "en_US");
    }
}