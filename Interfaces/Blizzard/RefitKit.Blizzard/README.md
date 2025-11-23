# RefitKit.Blizzard

[![NuGet](https://img.shields.io/nuget/v/RefitKit.Blizzard.svg)](https://www.nuget.org/packages/RefitKit.Blizzard/)

Prebuilt Blizzard Game Data API interfaces for [Refit](https://github.com/reactiveui/refit), including World of Warcraft Community and Game Data APIs.

## Installation

```bash
dotnet add package RefitKit.Blizzard
```

## Usage

```csharp
using Refit;
using RefitKit.Blizzard;

// Create the API client for WoW Community API
var wowApi = RestService.For<IWorldOfWarcraftCommunityAPI>(
    Constants.BlizzardAPIBaseURL,
    new RefitSettings
    {
        AuthorizationHeaderValueGetter = () => Task.FromResult(accessToken)
    });

// Get achievement data
var achievement = await wowApi.GetAchievement<YourResponseType>(2144);

// Get realm status
var realmStatus = await wowApi.GetRealmStatus<YourResponseType>("Illidan,Stormreaver");

// Get auction data
var auctions = await wowApi.GetAuctionData<YourResponseType>("Illidan");
```

## Features

- World of Warcraft Community API support
- World of Warcraft Game Data API support
- Achievement, Auction, Boss, Character, Realm endpoints
- Challenge Mode leaderboards
- Type-safe API interface using Refit
- Support for multiple regions and locales

## API Interfaces

### IWorldOfWarcraftCommunityAPI
- Achievements
- Auction House data
- Boss information and lists
- Challenge Mode leaderboards (realm and region)
- Character profiles with various fields (achievements, appearance, feed, guild)
- Realm status

### IWorldOfWarcraftGameDataAPI
- (Ready for Game Data API endpoint implementations)

## Documentation

For more information about Blizzard APIs, visit:
- [Blizzard API Documentation](https://develop.battle.net/documentation)
- [World of Warcraft API](https://develop.battle.net/documentation/world-of-warcraft)

## License

MIT License - see [LICENSE.md](https://github.com/Tillman32/RefitKit/blob/master/LICENSE.md)
