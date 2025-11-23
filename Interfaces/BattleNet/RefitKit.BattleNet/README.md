# RefitKit.BattleNet

[![NuGet](https://img.shields.io/nuget/v/RefitKit.BattleNet.svg)](https://www.nuget.org/packages/RefitKit.BattleNet/)

Prebuilt Battle.net OAuth API interface for [Refit](https://github.com/reactiveui/refit).

## Installation

```bash
dotnet add package RefitKit.BattleNet
```

## Usage

```csharp
using Refit;
using RefitKit.BattleNet;

// Create the API client
var api = RestService.For<IBattleNetAPI>(
    Constants.BNetAPIBaseURL,
    new RefitSettings
    {
        AuthorizationHeaderValueGetter = () => Task.FromResult(yourAuthToken)
    });

// Authorize application with client credentials flow
var response = await api.AuthorizeApplication<YourResponseType>();

// Validate an access token
var validation = await api.ValidateToken<YourResponseType>(token);
```

## Features

- Battle.net OAuth 2.0 authentication flow support
- User authorization with authorization code flow
- Application authorization with client credentials flow
- Token validation
- Type-safe API interface using Refit

## API Endpoints

- `AuthorizeUser` - Initialize OAuth authorization code flow
- `GetAccessToken` - Exchange authorization code for access token
- `AuthorizeApplication` - Client credentials flow for application-only authentication
- `ValidateToken` - Verify and get metadata about access tokens

## Documentation

For more information about Battle.net OAuth API, visit:
- [Battle.net OAuth Documentation](https://develop.battle.net/documentation/guides/using-oauth)

## License

MIT License - see [LICENSE.md](https://github.com/Tillman32/RefitKit/blob/master/LICENSE.md)
