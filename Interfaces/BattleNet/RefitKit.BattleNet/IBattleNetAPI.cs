using Refit;
using System.Threading.Tasks;

namespace RefitKit.BattleNet
{
    public interface IBattleNetAPI
    {
        /// <summary>
        /// The authorization request is the first part of the authorization code flow, 
        /// OAuth's authentication flow for performing API requests on behalf of a user. Applications can also ask for special access to user-specific data by specifying one or more "scopes."
        /// </summary>
        /// <typeparam name="TResponse">Response Type.</typeparam>
        /// <param name="clientId">Battle.net client Id.</param>
        /// <param name="redirectUri">The url to return the user to with the access code.</param>
        /// <param name="scope">Special access to specific data.</param>
        /// <param name="state">An opaque value supplied by the client to maintain state between the request and callback.</param>
        /// <returns></returns>
        [Get("/oauth/authorize?response_type=code&client_id={clientId}&redirect_uri={redirectUri}&scope={scope}&state={state}")]
        Task<TResponse> AuthorizeUser<TResponse>(string clientId, string redirectUri, string scope = null, string state = null);

        /// <summary>
        /// This request allows the application to exchange the access code for an access token to can use in subsequent API requests.
        /// </summary>
        /// <typeparam name="TResponse">Response Type.</typeparam>
        /// <param name="clientId">Battle.net client Id.</param>
        /// <param name="redirectUri">Must be identical to the redirect_uri value used in the authorization request.</param>
        /// <param name="code">The authorization code received from the authorization server.</param>
        /// <returns></returns>
        [Post("/oauth/token?grant_type=authorization_code&client_id={clientId}&redirect_uri={redirectUri}&code={code}")]
        Task<TResponse> GetAccessToken<TResponse>(string clientId, string redirectUri, string code);

        /// <summary>
        /// OAuth's authentication flow intended for application servers.
        /// *A BASIC token header is required to authenticate. Passing one through param is optional.
        /// </summary>
        /// <typeparam name="TResponse">Response Type.</typeparam>
        /// <param name="scope">A space-delimited, case-sensitive list of scopes that to which to request access.</param>
        /// <returns>TResponse</returns>
        [Post("/oauth/token?grant_type=client_credentials&scope={scope}")]
        [Headers("Authorization: Basic")]
        Task<TResponse> AuthorizeApplication<TResponse>(string scope = null, [Header("Authorization: Basic")]string basicToken = null);

        /// <summary>
        /// Verifies that a given bearer token is valid and retrieves metadata about the token, 
        /// including the client_id used to create the token, expiration timestamp, and scopes granted to the token.
        /// </summary>
        /// <typeparam name="TResponse">Response Type.</typeparam>
        /// <param name="token">Bearer access token to verify.</param>
        /// <returns>TResponse</returns>
        [Post("/oauth/check_token?token={token}")]
        [Headers("Authorization: Basic")]
        Task<TResponse> ValidateToken<TResponse>(string token);

        // TODO: 
        //[Get("/oauth/userinfo")]
        //Task<TResponse> GetUserInfo<TResponse>([Header("Authorization")]string accessToken);
    }
}
