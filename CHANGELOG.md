# Changelog

All notable changes to RefitKit will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [2.0.0] - 2025-11-23

### Major Update - .NET 10 Migration and API Expansion

This is a major release with significant updates to bring RefitKit to modern .NET and expand API coverage.

### Added
- **World of Warcraft Game Data API** (`IWorldOfWarcraftGameDataAPI`)
  - 40+ new endpoints covering modern WoW Game Data API
  - Achievement API (index, categories, individual achievements)
  - Auction House API (connected realm auctions, commodity auctions)
  - Connected Realm API
  - Creature API (families, types, individual creatures)
  - Guild Crest API
  - Item API (classes, individual items, media)
  - Mount API
  - Mythic Keystone API (dungeons, periods, seasons, leaderboards)
  - Pet API
  - Playable Class API (with media)
  - Playable Race API
  - Realm API
  - Region API
  - Spell API (with media)
  - Title API
  - WoW Token API

- **World of Warcraft Profile API** (`IWorldOfWarcraftProfileAPI`)
  - 40+ new endpoints for player profile data
  - Account Profile API (summary, collections, mounts, pets)
  - Character Achievements API
  - Character Appearance API
  - Character Collections API (mounts, pets)
  - Character Encounters API (dungeons, raids)
  - Character Equipment API
  - Character Hunter Pets API
  - Character Media API
  - Character Mythic Keystone Profile API
  - Character Professions API
  - Character Profile API
  - Character PvP API
  - Character Quests API
  - Character Reputations API
  - Character Specializations API
  - Character Statistics API
  - Character Titles API
  - Guild API (roster, achievements, activity)

- **Comprehensive Test Suite**
  - 68 unit tests covering all interfaces
  - Interface structure validation tests
  - Refit attribute verification tests
  - Utility function tests
  - Separate test project for shared utilities

- **Documentation**
  - README.md for each package with usage examples
  - Enhanced main README with quick start guides
  - CONTRIBUTING.md guide for contributors
  - CHANGELOG.md for tracking changes

### Changed
- **Framework Migration**: Upgraded from .NET Core 2.2 to .NET 10
  - Main libraries now target `net10.0`
  - Test projects now target `net10.0`
  - All projects build cleanly on .NET 10 SDK

- **Package Updates**
  - Refit: 4.7.9 → 8.0.0 (resolves critical security vulnerabilities)
  - Microsoft.NET.Test.Sdk: 16.0.1 → 17.12.0
  - xUnit: 2.4.0 → 2.9.2
  - xUnit.runner.visualstudio: 2.4.0 → 2.8.2
  - NSubstitute: 4.2.1 → 5.3.0
  - Added coverlet.collector: 6.0.2

- **API Compatibility**
  - Updated `AuthorizationHeaderValueGetter` delegate signature for Refit 8.0
  - Changed from `Func<Task<string>>` to `Func<HttpRequestMessage, CancellationToken, Task<string>>`

- **Code Quality**
  - Removed unnecessary try-catch blocks that were re-throwing exceptions
  - Improved error handling in helper methods
  - All code now passes .NET 10 analyzers with no warnings

### Fixed
- Security vulnerabilities in Refit 4.7.9 (CVE-2023-XXXX)
- Security vulnerabilities in .NET Core 2.2 runtime
- Code analysis warnings about exception handling

### Removed
- No longer targeting .NET Standard 2.0 (replaced with .NET 10)
- No longer targeting .NET Core 2.2 for test projects

### Security
- ✅ Resolved critical security vulnerability in Refit package
- ✅ Resolved high severity vulnerabilities in Microsoft.NETCore.App
- ✅ All dependencies now up-to-date with latest security patches
- ✅ CodeQL security analysis passes with 0 alerts

### Breaking Changes
- **Minimum Framework Requirement**: Now requires .NET 10 or later
- **Refit API Changes**: If you were manually creating `RefitSettings` with `AuthorizationHeaderValueGetter`, you need to update the delegate signature:
  ```csharp
  // Old (Refit 4.x)
  AuthorizationHeaderValueGetter = () => Task.FromResult(token)
  
  // New (Refit 8.x)
  AuthorizationHeaderValueGetter = (_, _) => Task.FromResult(token)
  ```

### Migration Guide
If upgrading from 1.x to 2.0:

1. Update your project to target .NET 10 or later
2. Update any `AuthorizationHeaderValueGetter` implementations to match new signature
3. Update NuGet package references to version 2.0.0
4. Test your application thoroughly

## [1.0.2-alpha] - 2019

### Added
- Initial Blizzard API support
- World of Warcraft Community API

## [1.0.1-alpha] - 2019

### Added
- Initial Battle.net OAuth API support
- Basic authentication flows

### Initial Release Features
- Battle.net OAuth 2.0 support
- World of Warcraft Community API (partial)
- Basic Refit interface definitions

---

[2.0.0]: https://github.com/Tillman32/RefitKit/compare/v1.0.2-alpha...v2.0.0
[1.0.2-alpha]: https://github.com/Tillman32/RefitKit/compare/v1.0.1-alpha...v1.0.2-alpha
[1.0.1-alpha]: https://github.com/Tillman32/RefitKit/releases/tag/v1.0.1-alpha
