using Refit;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace RefitKit.GitHub.Tests
{
    /// <summary>
    /// Integration tests for GitHub API using public endpoints
    /// These tests make real API calls to GitHub's public API
    /// Note: These tests may be skipped if rate limited by GitHub's API
    /// </summary>
    public class IGitHubAPITest
    {
        private readonly IGitHubAPI _gitHubApi;

        public IGitHubAPITest()
        {
            _gitHubApi = RestService.For<IGitHubAPI>(
                Constants.GitHubAPIBaseURL,
                new RefitSettings
                {
                    HttpMessageHandlerFactory = () => new HttpClientHandler()
                });
        }

        [Fact(DisplayName = "Get Repository - octocat/Hello-World", Skip = "Skipped: Requires public API access (may be rate limited in CI environment)")]
        public async Task GetRepository()
        {
            var response = await _gitHubApi.GetRepository<HttpResponseMessage>("octocat", "Hello-World");
            
            Assert.NotNull(response);
            Assert.Equal("OK", response.StatusCode.ToString());
        }

        [Fact(DisplayName = "Get User - octocat", Skip = "Skipped: Requires public API access (may be rate limited in CI environment)")]
        public async Task GetUser()
        {
            var response = await _gitHubApi.GetUser<HttpResponseMessage>("octocat");
            
            Assert.NotNull(response);
            Assert.Equal("OK", response.StatusCode.ToString());
        }

        [Fact(DisplayName = "List User Repositories - octocat", Skip = "Skipped: Requires public API access (may be rate limited in CI environment)")]
        public async Task ListUserRepositories()
        {
            var response = await _gitHubApi.ListUserRepositories<HttpResponseMessage>("octocat");
            
            Assert.NotNull(response);
            Assert.Equal("OK", response.StatusCode.ToString());
        }

        [Fact(DisplayName = "List Issues - microsoft/vscode", Skip = "Skipped: Requires public API access (may be rate limited in CI environment)")]
        public async Task ListIssues()
        {
            var response = await _gitHubApi.ListIssues<HttpResponseMessage>("microsoft", "vscode", state: "all", perPage: 5);
            
            Assert.NotNull(response);
            Assert.Equal("OK", response.StatusCode.ToString());
        }

        [Fact(DisplayName = "List Pull Requests - microsoft/vscode", Skip = "Skipped: Requires public API access (may be rate limited in CI environment)")]
        public async Task ListPullRequests()
        {
            var response = await _gitHubApi.ListPullRequests<HttpResponseMessage>("microsoft", "vscode", state: "all", perPage: 5);
            
            Assert.NotNull(response);
            Assert.Equal("OK", response.StatusCode.ToString());
        }

        [Fact(DisplayName = "List Commits - octocat/Hello-World", Skip = "Skipped: Requires public API access (may be rate limited in CI environment)")]
        public async Task ListCommits()
        {
            var response = await _gitHubApi.ListCommits<HttpResponseMessage>("octocat", "Hello-World", perPage: 5);
            
            Assert.NotNull(response);
            Assert.Equal("OK", response.StatusCode.ToString());
        }

        [Fact(DisplayName = "Get Commit - octocat/Hello-World", Skip = "Skipped: Requires public API access (may be rate limited in CI environment)")]
        public async Task GetCommit()
        {
            var response = await _gitHubApi.GetCommit<HttpResponseMessage>("octocat", "Hello-World", "main");
            
            Assert.NotNull(response);
            Assert.Equal("OK", response.StatusCode.ToString());
        }

        [Fact(DisplayName = "List Branches - octocat/Hello-World", Skip = "Skipped: Requires public API access (may be rate limited in CI environment)")]
        public async Task ListBranches()
        {
            var response = await _gitHubApi.ListBranches<HttpResponseMessage>("octocat", "Hello-World");
            
            Assert.NotNull(response);
            Assert.Equal("OK", response.StatusCode.ToString());
        }

        [Fact(DisplayName = "List Releases - microsoft/vscode", Skip = "Skipped: Requires public API access (may be rate limited in CI environment)")]
        public async Task ListReleases()
        {
            var response = await _gitHubApi.ListReleases<HttpResponseMessage>("microsoft", "vscode", perPage: 5);
            
            Assert.NotNull(response);
            Assert.Equal("OK", response.StatusCode.ToString());
        }

        [Fact(DisplayName = "Get Latest Release - microsoft/vscode", Skip = "Skipped: Requires public API access (may be rate limited in CI environment)")]
        public async Task GetLatestRelease()
        {
            var response = await _gitHubApi.GetLatestRelease<HttpResponseMessage>("microsoft", "vscode");
            
            Assert.NotNull(response);
            Assert.Equal("OK", response.StatusCode.ToString());
        }

        [Fact(DisplayName = "Search Repositories - language:csharp", Skip = "Skipped: Requires public API access (may be rate limited in CI environment)")]
        public async Task SearchRepositories()
        {
            var response = await _gitHubApi.SearchRepositories<HttpResponseMessage>("language:csharp", perPage: 5);
            
            Assert.NotNull(response);
            Assert.Equal("OK", response.StatusCode.ToString());
        }

        [Fact(DisplayName = "Search Users - location:seattle", Skip = "Skipped: Requires public API access (may be rate limited in CI environment)")]
        public async Task SearchUsers()
        {
            var response = await _gitHubApi.SearchUsers<HttpResponseMessage>("location:seattle", perPage: 5);
            
            Assert.NotNull(response);
            Assert.Equal("OK", response.StatusCode.ToString());
        }
    }
}
