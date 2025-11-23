using Refit;
using System.Threading.Tasks;

namespace RefitKit.GitHub
{
    /// <summary>
    /// GitHub REST API v3 interface for Refit
    /// </summary>
    public interface IGitHubAPI
    {
        /// <summary>
        /// Get a repository by owner and repo name
        /// </summary>
        /// <typeparam name="TResponse">Response Type.</typeparam>
        /// <param name="owner">The account owner of the repository. The name is not case sensitive.</param>
        /// <param name="repo">The name of the repository without the .git extension. The name is not case sensitive.</param>
        /// <returns>TResponse</returns>
        [Get("/repos/{owner}/{repo}")]
        Task<TResponse> GetRepository<TResponse>(string owner, string repo);

        /// <summary>
        /// List repositories for a user
        /// </summary>
        /// <typeparam name="TResponse">Response Type.</typeparam>
        /// <param name="username">The handle for the GitHub user account.</param>
        /// <param name="type">Can be one of: all, owner, member. Default: owner</param>
        /// <param name="sort">Can be one of: created, updated, pushed, full_name. Default: full_name</param>
        /// <param name="direction">Can be one of: asc, desc. Default: asc when using full_name, otherwise desc</param>
        /// <param name="perPage">The number of results per page (max 100). Default: 30</param>
        /// <param name="page">The page number of the results to fetch. Default: 1</param>
        /// <returns>TResponse</returns>
        [Get("/users/{username}/repos?type={type}&sort={sort}&direction={direction}&per_page={perPage}&page={page}")]
        Task<TResponse> ListUserRepositories<TResponse>(string username, string type = "owner", string sort = "full_name", string direction = null, int perPage = 30, int page = 1);

        /// <summary>
        /// Get a user by username
        /// </summary>
        /// <typeparam name="TResponse">Response Type.</typeparam>
        /// <param name="username">The handle for the GitHub user account.</param>
        /// <returns>TResponse</returns>
        [Get("/users/{username}")]
        Task<TResponse> GetUser<TResponse>(string username);

        /// <summary>
        /// Get the authenticated user (requires authentication)
        /// </summary>
        /// <typeparam name="TResponse">Response Type.</typeparam>
        /// <returns>TResponse</returns>
        [Get("/user")]
        [Headers("Authorization: Bearer")]
        Task<TResponse> GetAuthenticatedUser<TResponse>();

        /// <summary>
        /// List issues for a repository
        /// </summary>
        /// <typeparam name="TResponse">Response Type.</typeparam>
        /// <param name="owner">The account owner of the repository. The name is not case sensitive.</param>
        /// <param name="repo">The name of the repository without the .git extension. The name is not case sensitive.</param>
        /// <param name="state">Indicates the state of the issues to return. Can be either open, closed, or all. Default: open</param>
        /// <param name="sort">What to sort results by. Can be either created, updated, comments. Default: created</param>
        /// <param name="direction">The direction to sort the results by. Can be either asc or desc. Default: desc</param>
        /// <param name="perPage">The number of results per page (max 100). Default: 30</param>
        /// <param name="page">The page number of the results to fetch. Default: 1</param>
        /// <returns>TResponse</returns>
        [Get("/repos/{owner}/{repo}/issues?state={state}&sort={sort}&direction={direction}&per_page={perPage}&page={page}")]
        Task<TResponse> ListIssues<TResponse>(string owner, string repo, string state = "open", string sort = "created", string direction = "desc", int perPage = 30, int page = 1);

        /// <summary>
        /// Get a single issue
        /// </summary>
        /// <typeparam name="TResponse">Response Type.</typeparam>
        /// <param name="owner">The account owner of the repository. The name is not case sensitive.</param>
        /// <param name="repo">The name of the repository without the .git extension. The name is not case sensitive.</param>
        /// <param name="issueNumber">The number that identifies the issue.</param>
        /// <returns>TResponse</returns>
        [Get("/repos/{owner}/{repo}/issues/{issueNumber}")]
        Task<TResponse> GetIssue<TResponse>(string owner, string repo, int issueNumber);

        /// <summary>
        /// List pull requests for a repository
        /// </summary>
        /// <typeparam name="TResponse">Response Type.</typeparam>
        /// <param name="owner">The account owner of the repository. The name is not case sensitive.</param>
        /// <param name="repo">The name of the repository without the .git extension. The name is not case sensitive.</param>
        /// <param name="state">Either open, closed, or all to filter by state. Default: open</param>
        /// <param name="sort">What to sort results by. Can be either created, updated, popularity, long-running. Default: created</param>
        /// <param name="direction">The direction to sort the results by. Can be either asc or desc. Default: desc</param>
        /// <param name="perPage">The number of results per page (max 100). Default: 30</param>
        /// <param name="page">The page number of the results to fetch. Default: 1</param>
        /// <returns>TResponse</returns>
        [Get("/repos/{owner}/{repo}/pulls?state={state}&sort={sort}&direction={direction}&per_page={perPage}&page={page}")]
        Task<TResponse> ListPullRequests<TResponse>(string owner, string repo, string state = "open", string sort = "created", string direction = "desc", int perPage = 30, int page = 1);

        /// <summary>
        /// Get a single pull request
        /// </summary>
        /// <typeparam name="TResponse">Response Type.</typeparam>
        /// <param name="owner">The account owner of the repository. The name is not case sensitive.</param>
        /// <param name="repo">The name of the repository without the .git extension. The name is not case sensitive.</param>
        /// <param name="pullNumber">The number that identifies the pull request.</param>
        /// <returns>TResponse</returns>
        [Get("/repos/{owner}/{repo}/pulls/{pullNumber}")]
        Task<TResponse> GetPullRequest<TResponse>(string owner, string repo, int pullNumber);

        /// <summary>
        /// List commits on a repository
        /// </summary>
        /// <typeparam name="TResponse">Response Type.</typeparam>
        /// <param name="owner">The account owner of the repository. The name is not case sensitive.</param>
        /// <param name="repo">The name of the repository without the .git extension. The name is not case sensitive.</param>
        /// <param name="sha">SHA or branch to start listing commits from. Default: the repository's default branch (usually main).</param>
        /// <param name="perPage">The number of results per page (max 100). Default: 30</param>
        /// <param name="page">The page number of the results to fetch. Default: 1</param>
        /// <returns>TResponse</returns>
        [Get("/repos/{owner}/{repo}/commits?sha={sha}&per_page={perPage}&page={page}")]
        Task<TResponse> ListCommits<TResponse>(string owner, string repo, string sha = null, int perPage = 30, int page = 1);

        /// <summary>
        /// Get a single commit
        /// </summary>
        /// <typeparam name="TResponse">Response Type.</typeparam>
        /// <param name="owner">The account owner of the repository. The name is not case sensitive.</param>
        /// <param name="repo">The name of the repository without the .git extension. The name is not case sensitive.</param>
        /// <param name="ref">The commit reference. Can be a commit SHA, branch name, or tag name.</param>
        /// <returns>TResponse</returns>
        [Get("/repos/{owner}/{repo}/commits/{ref}")]
        Task<TResponse> GetCommit<TResponse>(string owner, string repo, string @ref);

        /// <summary>
        /// List branches for a repository
        /// </summary>
        /// <typeparam name="TResponse">Response Type.</typeparam>
        /// <param name="owner">The account owner of the repository. The name is not case sensitive.</param>
        /// <param name="repo">The name of the repository without the .git extension. The name is not case sensitive.</param>
        /// <param name="perPage">The number of results per page (max 100). Default: 30</param>
        /// <param name="page">The page number of the results to fetch. Default: 1</param>
        /// <returns>TResponse</returns>
        [Get("/repos/{owner}/{repo}/branches?per_page={perPage}&page={page}")]
        Task<TResponse> ListBranches<TResponse>(string owner, string repo, int perPage = 30, int page = 1);

        /// <summary>
        /// List releases for a repository
        /// </summary>
        /// <typeparam name="TResponse">Response Type.</typeparam>
        /// <param name="owner">The account owner of the repository. The name is not case sensitive.</param>
        /// <param name="repo">The name of the repository without the .git extension. The name is not case sensitive.</param>
        /// <param name="perPage">The number of results per page (max 100). Default: 30</param>
        /// <param name="page">The page number of the results to fetch. Default: 1</param>
        /// <returns>TResponse</returns>
        [Get("/repos/{owner}/{repo}/releases?per_page={perPage}&page={page}")]
        Task<TResponse> ListReleases<TResponse>(string owner, string repo, int perPage = 30, int page = 1);

        /// <summary>
        /// Get the latest release for a repository
        /// </summary>
        /// <typeparam name="TResponse">Response Type.</typeparam>
        /// <param name="owner">The account owner of the repository. The name is not case sensitive.</param>
        /// <param name="repo">The name of the repository without the .git extension. The name is not case sensitive.</param>
        /// <returns>TResponse</returns>
        [Get("/repos/{owner}/{repo}/releases/latest")]
        Task<TResponse> GetLatestRelease<TResponse>(string owner, string repo);

        /// <summary>
        /// Search repositories
        /// </summary>
        /// <typeparam name="TResponse">Response Type.</typeparam>
        /// <param name="query">The query contains one or more search keywords and qualifiers.</param>
        /// <param name="sort">Sorts the results of your query. Can be stars, forks, help-wanted-issues, or updated. Default: best match</param>
        /// <param name="order">Determines whether the first search result returned is the highest or lowest number of matches. Can be asc or desc. Default: desc</param>
        /// <param name="perPage">The number of results per page (max 100). Default: 30</param>
        /// <param name="page">The page number of the results to fetch. Default: 1</param>
        /// <returns>TResponse</returns>
        [Get("/search/repositories?q={query}&sort={sort}&order={order}&per_page={perPage}&page={page}")]
        Task<TResponse> SearchRepositories<TResponse>(string query, string sort = null, string order = "desc", int perPage = 30, int page = 1);

        /// <summary>
        /// Search users
        /// </summary>
        /// <typeparam name="TResponse">Response Type.</typeparam>
        /// <param name="query">The query contains one or more search keywords and qualifiers.</param>
        /// <param name="sort">Sorts the results. Can be followers, repositories, or joined. Default: best match</param>
        /// <param name="order">Determines whether the first search result returned is the highest or lowest number of matches. Can be asc or desc. Default: desc</param>
        /// <param name="perPage">The number of results per page (max 100). Default: 30</param>
        /// <param name="page">The page number of the results to fetch. Default: 1</param>
        /// <returns>TResponse</returns>
        [Get("/search/users?q={query}&sort={sort}&order={order}&per_page={perPage}&page={page}")]
        Task<TResponse> SearchUsers<TResponse>(string query, string sort = null, string order = "desc", int perPage = 30, int page = 1);
    }
}
