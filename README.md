# RefitKit

A comprehensive collection of [Refit](https://github.com/reactiveui/refit) interfaces for popular gaming APIs. RefitKit provides type-safe, easy-to-use interfaces for Battle.net and Blizzard game APIs, eliminating the need to write boilerplate HTTP client code.

## Features

- 🎮 **Battle.net OAuth API** - Complete OAuth 2.0 authentication flow support
- 🐉 **World of Warcraft APIs** - Community and Game Data API interfaces
- 🔒 **Type-Safe** - Strongly-typed interfaces using Refit
- ⚡ **Modern** - Built on .NET 10 with latest dependencies
- 📦 **Easy to Use** - Just add the package and start making API calls

## Packages

| Package | Version | Description |
|---------|---------|-------------|
| [RefitKit.BattleNet](https://www.nuget.org/packages/RefitKit.BattleNet/) | [![NuGet](https://img.shields.io/nuget/v/RefitKit.BattleNet.svg)](https://www.nuget.org/packages/RefitKit.BattleNet/) | Battle.net OAuth API interface |
| [RefitKit.Blizzard](https://www.nuget.org/packages/RefitKit.Blizzard/) | [![NuGet](https://img.shields.io/nuget/v/RefitKit.Blizzard.svg)](https://www.nuget.org/packages/RefitKit.Blizzard/) | Blizzard Game Data API interfaces |

## Installation

Install via NuGet Package Manager:

```bash
# Battle.net OAuth API
dotnet add package RefitKit.BattleNet

# Blizzard Game APIs (World of Warcraft)
dotnet add package RefitKit.Blizzard
```

## Quick Start

### Battle.net Authentication

```csharp
using Refit;
using RefitKit.BattleNet;

// Create API client
var api = RestService.For<IBattleNetAPI>(Constants.BNetAPIBaseURL);

// Application authentication (client credentials flow)
var authResponse = await api.AuthorizeApplication<AuthResponse>();
```

### World of Warcraft API

```csharp
using Refit;
using RefitKit.Blizzard;

// Create API client with access token
var wowApi = RestService.For<IWorldOfWarcraftCommunityAPI>(
    Constants.BlizzardAPIBaseURL,
    new RefitSettings
    {
        AuthorizationHeaderValueGetter = () => Task.FromResult(accessToken)
    });

// Get achievement data
var achievement = await wowApi.GetAchievement<AchievementResponse>(2144);

// Get realm status
var realms = await wowApi.GetRealmStatus<RealmStatusResponse>("Illidan,Stormreaver");
```

### World of Warcraft Profile API

```csharp
using Refit;
using RefitKit.Blizzard;

// Create API client with access token
var profileApi = RestService.For<IWorldOfWarcraftProfileAPI>(
    Constants.BlizzardAPIBaseURL,
    new RefitSettings
    {
        AuthorizationHeaderValueGetter = (_, _) => Task.FromResult(accessToken)
    });

// Get character profile
var character = await profileApi.GetCharacterProfileSummary<CharacterResponse>("tichondrius", "playername");

// Get character mythic keystone profile
var mythicProfile = await profileApi.GetCharacterMythicKeystoneProfile<MythicProfileResponse>("tichondrius", "playername");
```

### World of Warcraft Game Data API

```csharp
using Refit;
using RefitKit.Blizzard;

// Create API client with access token
var gameDataApi = RestService.For<IWorldOfWarcraftGameDataAPI>(
    Constants.BlizzardAPIBaseURL,
    new RefitSettings
    {
        AuthorizationHeaderValueGetter = (_, _) => Task.FromResult(accessToken)
    });

// Get current WoW Token price
var tokenPrice = await gameDataApi.GetWoWTokenIndex<TokenResponse>();

// Get connected realm auctions
var auctions = await gameDataApi.GetAuctions<AuctionResponse>(3676); // Connected realm ID

// Get mythic keystone leaderboard
var leaderboard = await gameDataApi.GetMythicKeystoneLeaderboard<LeaderboardResponse>(3676, 200, 641);
```

## Documentation

Each package includes detailed documentation and examples:

- [RefitKit.BattleNet Documentation](./Interfaces/BattleNet/RefitKit.BattleNet/README.md)
- [RefitKit.Blizzard Documentation](./Interfaces/Blizzard/RefitKit.Blizzard/README.md)

For more information about the underlying APIs:
- [Blizzard Developer Portal](https://develop.battle.net/)
- [Battle.net OAuth Documentation](https://develop.battle.net/documentation/guides/using-oauth)
- [World of Warcraft API](https://develop.battle.net/documentation/world-of-warcraft)

## Requirements

- .NET 10 or later
- Valid Battle.net API credentials (client ID and secret)

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## Build Status
[![Build status](https://dev.azure.com/tillmandev/RefitKit/_apis/build/status/RefitKit-CI?branchName=master)](https://dev.azure.com/tillmandev/RefitKit/_build/latest?definitionId=5?branchName=master) 

### License 
MIT License

Copyright (c) 2019 RefitKit

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.