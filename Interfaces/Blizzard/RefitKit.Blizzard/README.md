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

### IWorldOfWarcraftCommunityAPI (Legacy API)
- Achievements
- Auction House data
- Boss information and lists
- Challenge Mode leaderboards (realm and region)
- Character profiles with various fields (achievements, appearance, feed, guild)
- Realm status

### IWorldOfWarcraftGameDataAPI (Modern Game Data API)
Complete implementation of the modern World of Warcraft Game Data API with 40+ endpoints:

#### Achievement API
- Achievement index and individual achievements
- Achievement categories

#### Auction House API
- Connected realm auctions
- Commodity auctions

#### Connected Realm API
- Connected realm index and details

#### Creature API
- Creature families, types, and individual creatures

#### Guild Crest API
- Guild crest media

#### Item API
- Item classes, individual items, and item media

#### Mount API
- Mount index and individual mounts

#### Mythic Keystone API
- Dungeon index and details
- Period index and details
- Season index and details
- Leaderboards by realm and dungeon

#### Pet API
- Pet index and individual pets

#### Playable Class API
- Class index, details, and media

#### Playable Race API
- Race index and details

#### Realm API
- Realm index and individual realm details

#### Region API
- Region index and details

#### Spell API
- Individual spells and spell media

#### Title API
- Title index and individual titles

#### WoW Token API
- Current WoW Token price

## Documentation

For more information about Blizzard APIs, visit:
- [Blizzard API Documentation](https://develop.battle.net/documentation)
- [World of Warcraft API](https://develop.battle.net/documentation/world-of-warcraft)

## License

MIT License - see [LICENSE.md](https://github.com/Tillman32/RefitKit/blob/master/LICENSE.md)
