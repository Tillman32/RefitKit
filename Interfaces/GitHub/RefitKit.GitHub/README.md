# RefitKit.GitHub

[![NuGet](https://img.shields.io/nuget/v/RefitKit.GitHub.svg)](https://www.nuget.org/packages/RefitKit.GitHub/)

Prebuilt GitHub REST API v3 interface for [Refit](https://github.com/reactiveui/refit).

## Installation

```bash
dotnet add package RefitKit.GitHub
```

## Usage

### Basic Usage (Public Endpoints)

```csharp
using Refit;
using RefitKit.GitHub;

// Create the API client
var api = RestService.For<IGitHubAPI>(Constants.GitHubAPIBaseURL);

// Get a repository
var repo = await api.GetRepository<YourResponseType>("octocat", "Hello-World");

// Get a user
var user = await api.GetUser<YourResponseType>("octocat");

// List repositories for a user
var repos = await api.ListUserRepositories<YourResponseType>("octocat");

// Search repositories
var searchResults = await api.SearchRepositories<YourResponseType>("language:csharp");
```

### Authenticated Usage

For authenticated requests, provide a GitHub personal access token:

```csharp
using Refit;
using RefitKit.GitHub;

// Create the API client with authentication
var api = RestService.For<IGitHubAPI>(
    Constants.GitHubAPIBaseURL,
    new RefitSettings
    {
        AuthorizationHeaderValueGetter = (_, _) => Task.FromResult(yourGitHubToken)
    });

// Get the authenticated user
var user = await api.GetAuthenticatedUser<YourResponseType>();

// Access private repositories
var repo = await api.GetRepository<YourResponseType>("youruser", "your-private-repo");
```

### Working with Issues

```csharp
// List issues for a repository
var issues = await api.ListIssues<YourResponseType>("owner", "repo");

// Get a specific issue
var issue = await api.GetIssue<YourResponseType>("owner", "repo", 42);

// List issues with filters
var openBugs = await api.ListIssues<YourResponseType>(
    "owner", 
    "repo", 
    state: "open",
    sort: "updated",
    direction: "desc"
);
```

### Working with Pull Requests

```csharp
// List pull requests
var prs = await api.ListPullRequests<YourResponseType>("owner", "repo");

// Get a specific pull request
var pr = await api.GetPullRequest<YourResponseType>("owner", "repo", 123);

// List open pull requests sorted by updated date
var recentPRs = await api.ListPullRequests<YourResponseType>(
    "owner",
    "repo",
    state: "open",
    sort: "updated",
    direction: "desc"
);
```

### Working with Commits

```csharp
// List commits
var commits = await api.ListCommits<YourResponseType>("owner", "repo");

// List commits on a specific branch
var branchCommits = await api.ListCommits<YourResponseType>("owner", "repo", sha: "main");

// Get a specific commit
var commit = await api.GetCommit<YourResponseType>("owner", "repo", "abc123");
```

### Working with Releases

```csharp
// List all releases
var releases = await api.ListReleases<YourResponseType>("owner", "repo");

// Get the latest release
var latestRelease = await api.GetLatestRelease<YourResponseType>("owner", "repo");
```

## Features

- ✅ Repository management (get, list, search)
- ✅ User management (get, search)
- ✅ Issues (list, get)
- ✅ Pull Requests (list, get)
- ✅ Commits (list, get)
- ✅ Branches (list)
- ✅ Releases (list, get latest)
- ✅ Search (repositories, users)
- ✅ Type-safe API interface using Refit
- ✅ Support for both public and authenticated requests

## API Endpoints

### Repositories
- `GetRepository` - Get a repository by owner and name
- `ListUserRepositories` - List repositories for a user
- `SearchRepositories` - Search for repositories

### Users
- `GetUser` - Get a user by username
- `GetAuthenticatedUser` - Get the authenticated user (requires auth)
- `SearchUsers` - Search for users

### Issues
- `ListIssues` - List issues for a repository
- `GetIssue` - Get a single issue

### Pull Requests
- `ListPullRequests` - List pull requests for a repository
- `GetPullRequest` - Get a single pull request

### Commits
- `ListCommits` - List commits on a repository
- `GetCommit` - Get a single commit

### Branches
- `ListBranches` - List branches for a repository

### Releases
- `ListReleases` - List releases for a repository
- `GetLatestRelease` - Get the latest release

## Rate Limiting

GitHub API has rate limits:
- **Unauthenticated requests**: 60 requests per hour per IP
- **Authenticated requests**: 5,000 requests per hour per user

To avoid rate limiting, always use authentication when possible.

## Authentication

To authenticate with GitHub API, create a personal access token:

1. Go to GitHub Settings → Developer settings → Personal access tokens
2. Generate a new token with appropriate scopes
3. Use the token in the `AuthorizationHeaderValueGetter`

## Documentation

For more information about GitHub REST API v3:
- [GitHub REST API Documentation](https://docs.github.com/en/rest)
- [GitHub API Getting Started](https://docs.github.com/en/rest/guides/getting-started-with-the-rest-api)
- [GitHub Authentication](https://docs.github.com/en/rest/overview/authenticating-to-the-rest-api)

## License

MIT License - see [LICENSE.md](https://github.com/Tillman32/RefitKit/blob/master/LICENSE.md)
