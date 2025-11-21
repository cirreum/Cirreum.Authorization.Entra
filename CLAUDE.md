# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

This is **Cirreum.Authorization.Entra**, a .NET 10 authorization provider library that integrates Azure Entra ID (formerly Azure Active Directory) authentication for web applications and APIs using Microsoft Identity Web.

## Architecture

### Core Components

- **EntraAuthorizationRegistrar**: Main provider registrar class that extends `AuthorizationProviderRegistrar`
  - Implements both Web API (JWT Bearer) and Web App (OpenID Connect) authentication schemes
  - Integrates with Microsoft Identity Web for Azure Entra ID authentication
  - Uses configuration sections to set up authentication schemes

- **Configuration Classes**: Minimal configuration hierarchy
  - `EntraAuthorizationSettings`: Root settings extending `AuthorizationProviderSettings`
  - `EntraAuthorizationInstanceSettings`: Instance-specific settings (currently no additional properties)

### Key Patterns

1. **Provider Pattern**: Follows the Cirreum provider framework pattern with strongly-typed registrars
2. **Authentication Scheme Management**: Supports multiple authentication schemes per instance
3. **Configuration-Driven Setup**: Uses IConfigurationSection for Microsoft Identity Web integration
4. **Dual Authentication Support**: Handles both Web API (JWT) and Web App (OIDC) scenarios

## Common Development Commands

Since this is a .NET 10 library project, use standard .NET CLI commands:

```bash
# Build the project
dotnet build

# Run tests (if test project exists)
dotnet test

# Pack NuGet package
dotnet pack

# Restore dependencies
dotnet restore
```

## Build Configuration

- **Target Framework**: .NET 10.0
- **Language Version**: Latest C#
- **Nullable Reference Types**: Enabled
- **Implicit Usings**: Enabled
- **Documentation Generation**: Enabled

Key build properties are centralized in:
- `src/Directory.Build.props`: CI/CD detection, versioning, and common imports
- `build/Common.props`: Target framework and language settings
- `build/*.props`: Author info, icons, source linking, and package metadata

## Dependencies

- **Microsoft.Identity.Web**: Microsoft's library for integrating with Azure Entra ID
- **Cirreum.AuthorizationProvider**: Base authorization provider framework

## Development Guidelines

The README emphasizes conservative development practices:
- Minimal new abstractions to maintain API stability
- Limited dependency expansion (foundational, version-stable only)
- Favor additive, non-breaking changes
- Include thorough unit tests
- Document architectural decisions
- Follow .NET conventions from Microsoft.Extensions.*