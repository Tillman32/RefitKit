using Refit;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;

namespace RefitKit.GitHub.Tests
{
    public class IGitHubAPIInterfaceTest
    {
        [Fact(DisplayName = "Interface has expected methods")]
        public void InterfaceHasExpectedMethods()
        {
            var methods = typeof(IGitHubAPI).GetMethods();
            
            Assert.NotEmpty(methods);
            Assert.Contains(methods, m => m.Name == "GetRepository");
            Assert.Contains(methods, m => m.Name == "ListUserRepositories");
            Assert.Contains(methods, m => m.Name == "GetUser");
            Assert.Contains(methods, m => m.Name == "GetAuthenticatedUser");
            Assert.Contains(methods, m => m.Name == "ListIssues");
            Assert.Contains(methods, m => m.Name == "GetIssue");
            Assert.Contains(methods, m => m.Name == "ListPullRequests");
            Assert.Contains(methods, m => m.Name == "GetPullRequest");
            Assert.Contains(methods, m => m.Name == "ListCommits");
            Assert.Contains(methods, m => m.Name == "GetCommit");
            Assert.Contains(methods, m => m.Name == "ListBranches");
            Assert.Contains(methods, m => m.Name == "ListReleases");
            Assert.Contains(methods, m => m.Name == "GetLatestRelease");
            Assert.Contains(methods, m => m.Name == "SearchRepositories");
            Assert.Contains(methods, m => m.Name == "SearchUsers");
        }

        [Fact(DisplayName = "GetRepository method has correct Refit attributes")]
        public void GetRepositoryMethodHasCorrectAttributes()
        {
            var method = typeof(IGitHubAPI).GetMethod("GetRepository");
            Assert.NotNull(method);
            
            var getAttr = method!.GetCustomAttribute<GetAttribute>();
            Assert.NotNull(getAttr);
            Assert.Contains("/repos/", getAttr!.Path);
        }

        [Fact(DisplayName = "ListUserRepositories method has correct Refit attributes")]
        public void ListUserRepositoriesMethodHasCorrectAttributes()
        {
            var method = typeof(IGitHubAPI).GetMethod("ListUserRepositories");
            Assert.NotNull(method);
            
            var getAttr = method!.GetCustomAttribute<GetAttribute>();
            Assert.NotNull(getAttr);
            Assert.Contains("/users/", getAttr!.Path);
            Assert.Contains("/repos", getAttr.Path);
        }

        [Fact(DisplayName = "GetUser method has correct Refit attributes")]
        public void GetUserMethodHasCorrectAttributes()
        {
            var method = typeof(IGitHubAPI).GetMethod("GetUser");
            Assert.NotNull(method);
            
            var getAttr = method!.GetCustomAttribute<GetAttribute>();
            Assert.NotNull(getAttr);
            Assert.Contains("/users/", getAttr!.Path);
        }

        [Fact(DisplayName = "GetAuthenticatedUser method has correct Refit attributes")]
        public void GetAuthenticatedUserMethodHasCorrectAttributes()
        {
            var method = typeof(IGitHubAPI).GetMethod("GetAuthenticatedUser");
            Assert.NotNull(method);
            
            var getAttr = method!.GetCustomAttribute<GetAttribute>();
            Assert.NotNull(getAttr);
            Assert.Contains("/user", getAttr!.Path);
            
            var headersAttr = method.GetCustomAttribute<HeadersAttribute>();
            Assert.NotNull(headersAttr);
        }

        [Fact(DisplayName = "ListIssues method has correct Refit attributes")]
        public void ListIssuesMethodHasCorrectAttributes()
        {
            var method = typeof(IGitHubAPI).GetMethod("ListIssues");
            Assert.NotNull(method);
            
            var getAttr = method!.GetCustomAttribute<GetAttribute>();
            Assert.NotNull(getAttr);
            Assert.Contains("/repos/", getAttr!.Path);
            Assert.Contains("/issues", getAttr.Path);
        }

        [Fact(DisplayName = "GetIssue method has correct Refit attributes")]
        public void GetIssueMethodHasCorrectAttributes()
        {
            var method = typeof(IGitHubAPI).GetMethod("GetIssue");
            Assert.NotNull(method);
            
            var getAttr = method!.GetCustomAttribute<GetAttribute>();
            Assert.NotNull(getAttr);
            Assert.Contains("/repos/", getAttr!.Path);
            Assert.Contains("/issues/", getAttr.Path);
        }

        [Fact(DisplayName = "ListPullRequests method has correct Refit attributes")]
        public void ListPullRequestsMethodHasCorrectAttributes()
        {
            var method = typeof(IGitHubAPI).GetMethod("ListPullRequests");
            Assert.NotNull(method);
            
            var getAttr = method!.GetCustomAttribute<GetAttribute>();
            Assert.NotNull(getAttr);
            Assert.Contains("/repos/", getAttr!.Path);
            Assert.Contains("/pulls", getAttr.Path);
        }

        [Fact(DisplayName = "GetPullRequest method has correct Refit attributes")]
        public void GetPullRequestMethodHasCorrectAttributes()
        {
            var method = typeof(IGitHubAPI).GetMethod("GetPullRequest");
            Assert.NotNull(method);
            
            var getAttr = method!.GetCustomAttribute<GetAttribute>();
            Assert.NotNull(getAttr);
            Assert.Contains("/repos/", getAttr!.Path);
            Assert.Contains("/pulls/", getAttr.Path);
        }

        [Fact(DisplayName = "ListCommits method has correct Refit attributes")]
        public void ListCommitsMethodHasCorrectAttributes()
        {
            var method = typeof(IGitHubAPI).GetMethod("ListCommits");
            Assert.NotNull(method);
            
            var getAttr = method!.GetCustomAttribute<GetAttribute>();
            Assert.NotNull(getAttr);
            Assert.Contains("/repos/", getAttr!.Path);
            Assert.Contains("/commits", getAttr.Path);
        }

        [Fact(DisplayName = "GetCommit method has correct Refit attributes")]
        public void GetCommitMethodHasCorrectAttributes()
        {
            var method = typeof(IGitHubAPI).GetMethod("GetCommit");
            Assert.NotNull(method);
            
            var getAttr = method!.GetCustomAttribute<GetAttribute>();
            Assert.NotNull(getAttr);
            Assert.Contains("/repos/", getAttr!.Path);
            Assert.Contains("/commits/", getAttr.Path);
        }

        [Fact(DisplayName = "ListBranches method has correct Refit attributes")]
        public void ListBranchesMethodHasCorrectAttributes()
        {
            var method = typeof(IGitHubAPI).GetMethod("ListBranches");
            Assert.NotNull(method);
            
            var getAttr = method!.GetCustomAttribute<GetAttribute>();
            Assert.NotNull(getAttr);
            Assert.Contains("/repos/", getAttr!.Path);
            Assert.Contains("/branches", getAttr.Path);
        }

        [Fact(DisplayName = "ListReleases method has correct Refit attributes")]
        public void ListReleasesMethodHasCorrectAttributes()
        {
            var method = typeof(IGitHubAPI).GetMethod("ListReleases");
            Assert.NotNull(method);
            
            var getAttr = method!.GetCustomAttribute<GetAttribute>();
            Assert.NotNull(getAttr);
            Assert.Contains("/repos/", getAttr!.Path);
            Assert.Contains("/releases", getAttr.Path);
        }

        [Fact(DisplayName = "GetLatestRelease method has correct Refit attributes")]
        public void GetLatestReleaseMethodHasCorrectAttributes()
        {
            var method = typeof(IGitHubAPI).GetMethod("GetLatestRelease");
            Assert.NotNull(method);
            
            var getAttr = method!.GetCustomAttribute<GetAttribute>();
            Assert.NotNull(getAttr);
            Assert.Contains("/repos/", getAttr!.Path);
            Assert.Contains("/releases/latest", getAttr.Path);
        }

        [Fact(DisplayName = "SearchRepositories method has correct Refit attributes")]
        public void SearchRepositoriesMethodHasCorrectAttributes()
        {
            var method = typeof(IGitHubAPI).GetMethod("SearchRepositories");
            Assert.NotNull(method);
            
            var getAttr = method!.GetCustomAttribute<GetAttribute>();
            Assert.NotNull(getAttr);
            Assert.Contains("/search/repositories", getAttr!.Path);
        }

        [Fact(DisplayName = "SearchUsers method has correct Refit attributes")]
        public void SearchUsersMethodHasCorrectAttributes()
        {
            var method = typeof(IGitHubAPI).GetMethod("SearchUsers");
            Assert.NotNull(method);
            
            var getAttr = method!.GetCustomAttribute<GetAttribute>();
            Assert.NotNull(getAttr);
            Assert.Contains("/search/users", getAttr!.Path);
        }

        [Fact(DisplayName = "All methods return Task")]
        public void AllMethodsReturnTask()
        {
            var methods = typeof(IGitHubAPI).GetMethods();
            
            foreach (var method in methods)
            {
                Assert.True(method.ReturnType.IsGenericType);
                Assert.Equal(typeof(Task<>), method.ReturnType.GetGenericTypeDefinition());
            }
        }

        [Fact(DisplayName = "Constants class has GitHubAPIBaseURL")]
        public void ConstantsHasGitHubAPIBaseURL()
        {
            Assert.NotNull(Constants.GitHubAPIBaseURL);
            Assert.NotEmpty(Constants.GitHubAPIBaseURL);
            Assert.StartsWith("https://", Constants.GitHubAPIBaseURL);
            Assert.Contains("api.github.com", Constants.GitHubAPIBaseURL);
        }

        [Fact(DisplayName = "Interface has repository endpoints")]
        public void InterfaceHasRepositoryEndpoints()
        {
            var methods = typeof(IGitHubAPI).GetMethods();
            
            Assert.Contains(methods, m => m.Name == "GetRepository");
            Assert.Contains(methods, m => m.Name == "ListUserRepositories");
            Assert.Contains(methods, m => m.Name == "SearchRepositories");
        }

        [Fact(DisplayName = "Interface has user endpoints")]
        public void InterfaceHasUserEndpoints()
        {
            var methods = typeof(IGitHubAPI).GetMethods();
            
            Assert.Contains(methods, m => m.Name == "GetUser");
            Assert.Contains(methods, m => m.Name == "GetAuthenticatedUser");
            Assert.Contains(methods, m => m.Name == "SearchUsers");
        }

        [Fact(DisplayName = "Interface has issue endpoints")]
        public void InterfaceHasIssueEndpoints()
        {
            var methods = typeof(IGitHubAPI).GetMethods();
            
            Assert.Contains(methods, m => m.Name == "ListIssues");
            Assert.Contains(methods, m => m.Name == "GetIssue");
        }

        [Fact(DisplayName = "Interface has pull request endpoints")]
        public void InterfaceHasPullRequestEndpoints()
        {
            var methods = typeof(IGitHubAPI).GetMethods();
            
            Assert.Contains(methods, m => m.Name == "ListPullRequests");
            Assert.Contains(methods, m => m.Name == "GetPullRequest");
        }

        [Fact(DisplayName = "Interface has commit endpoints")]
        public void InterfaceHasCommitEndpoints()
        {
            var methods = typeof(IGitHubAPI).GetMethods();
            
            Assert.Contains(methods, m => m.Name == "ListCommits");
            Assert.Contains(methods, m => m.Name == "GetCommit");
        }

        [Fact(DisplayName = "Interface has branch endpoints")]
        public void InterfaceHasBranchEndpoints()
        {
            var methods = typeof(IGitHubAPI).GetMethods();
            
            Assert.Contains(methods, m => m.Name == "ListBranches");
        }

        [Fact(DisplayName = "Interface has release endpoints")]
        public void InterfaceHasReleaseEndpoints()
        {
            var methods = typeof(IGitHubAPI).GetMethods();
            
            Assert.Contains(methods, m => m.Name == "ListReleases");
            Assert.Contains(methods, m => m.Name == "GetLatestRelease");
        }
    }
}
