# Contributing to RefitKit

Thank you for your interest in contributing to RefitKit! This document provides guidelines and instructions for contributing to the project.

## Getting Started

1. Fork the repository
2. Clone your fork locally
3. Create a new branch for your feature or bug fix
4. Make your changes
5. Submit a pull request

## Development Setup

### Prerequisites
- .NET 10 SDK or later
- Your favorite IDE (Visual Studio, VS Code, Rider, etc.)

### Building the Project

```bash
# Restore dependencies
dotnet restore

# Build the solution
dotnet build RefitKit.sln

# Run tests
dotnet test RefitKit.sln
```

## Coding Guidelines

### Code Style
- Follow standard C# coding conventions
- Use meaningful variable and method names
- Add XML documentation comments for public APIs
- Keep methods focused and concise

### API Interface Design
When adding new API endpoints:

1. **Use Refit Attributes**: All API methods should use appropriate Refit attributes (`[Get]`, `[Post]`, etc.)
2. **Generic Return Types**: Methods should return `Task<TResponse>` to allow flexibility
3. **Default Parameters**: Provide sensible defaults for region and locale parameters
4. **Documentation**: Add XML doc comments explaining what the endpoint does
5. **Namespace Parameters**: Use `@namespace` as the parameter name (escaped keyword)

Example:
```csharp
/// <summary>
/// Returns an achievement by ID.
/// </summary>
[Get("/data/wow/achievement/{achievementId}?namespace={namespace}&locale={locale}")]
Task<TResponse> GetAchievement<TResponse>(int achievementId, string @namespace = "static-us", string locale = "en_US");
```

### Testing
- Add unit tests for new functionality
- Ensure all existing tests still pass
- Test coverage should include:
  - Interface method existence
  - Refit attribute validation
  - Parameter validation (for utility methods)

### Documentation
- Update README files when adding new features
- Keep examples up to date
- Document breaking changes

## Project Structure

```
RefitKit/
├── Interfaces/
│   ├── BattleNet/           # Battle.net OAuth API
│   │   ├── RefitKit.BattleNet/
│   │   └── RefitKit.BattleNet.Tests/
│   └── Blizzard/            # Blizzard Game APIs
│       ├── RefitKit.Blizzard/
│       └── RefitKit.Blizzard.Tests/
└── Shared/                   # Shared utilities
    ├── RefitKit.Shared/
    └── RefitKit.Shared.Tests/
```

## Adding New API Interfaces

To add support for a new API:

1. Create a new interface project under `Interfaces/`
2. Add corresponding test project
3. Update the solution file
4. Add README for the new package
5. Update main README
6. Add unit tests for interface validation

## Submitting Changes

1. Ensure your code builds without warnings
2. Run all tests and ensure they pass
3. Update documentation as needed
4. Commit with a clear message describing your changes
5. Push to your fork and submit a pull request

### Pull Request Guidelines

- Provide a clear description of the changes
- Reference any related issues
- Include test results if applicable
- Keep PRs focused on a single feature or fix

## Reporting Issues

When reporting issues, please include:
- Clear description of the problem
- Steps to reproduce
- Expected vs actual behavior
- .NET version and OS information
- Sample code if applicable

## API Versioning

RefitKit follows semantic versioning:
- **Major**: Breaking changes
- **Minor**: New features (backward compatible)
- **Patch**: Bug fixes

## Questions?

Feel free to open an issue for questions or clarifications about contributing to RefitKit.

## License

By contributing to RefitKit, you agree that your contributions will be licensed under the MIT License.
