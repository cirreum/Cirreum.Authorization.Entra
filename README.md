# Cirreum Authorization Entra

[![NuGet Version](https://img.shields.io/nuget/v/Cirreum.Authorization.Entra.svg?style=flat-square&labelColor=1F1F1F&color=003D8F)](https://www.nuget.org/packages/Cirreum.Authorization.Entra/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Cirreum.Authorization.Entra.svg?style=flat-square&labelColor=1F1F1F&color=003D8F)](https://www.nuget.org/packages/Cirreum.Authorization.Entra/)
[![GitHub Release](https://img.shields.io/github/v/release/cirreum/Cirreum.Authorization.Entra?style=flat-square&labelColor=1F1F1F&color=FF3B2E)](https://github.com/cirreum/Cirreum.Authorization.Entra/releases)
[![License](https://img.shields.io/github/license/cirreum/Cirreum.Authorization.Entra?style=flat-square&labelColor=1F1F1F&color=F2F2F2)](https://github.com/cirreum/Cirreum.Authorization.Entra/blob/main/LICENSE)
[![.NET](https://img.shields.io/badge/.NET-10.0-003D8F?style=flat-square&labelColor=1F1F1F)](https://dotnet.microsoft.com/)

**Azure Entra ID authorization provider for the Cirreum framework**

## Overview

**Cirreum.Authorization.Entra** is a .NET 10 authorization provider that seamlessly integrates Azure Entra ID (formerly Azure Active Directory) authentication into applications built with the Cirreum framework. It provides a unified configuration approach for both Web API (JWT Bearer) and Web App (OpenID Connect) authentication scenarios.

## Features

- **Dual Authentication Support**: Handles both Web API (JWT Bearer tokens) and Web App (OpenID Connect) authentication flows
- **Microsoft Identity Web Integration**: Built on top of Microsoft's official Identity Web library for robust Azure Entra ID support
- **Configuration-Driven**: Uses strongly-typed configuration classes that integrate with .NET's configuration system
- **Multi-Instance Support**: Configure multiple authentication schemes within a single application
- **Cirreum Provider Framework**: Follows established patterns from the Cirreum ecosystem for consistency and reliability

## Usage

### Registration

Register the Entra authorization provider in your application's startup:

```csharp
using Cirreum.Authorization;

// Register the provider
services.AddCirreumAuthorization<EntraAuthorizationRegistrar, EntraAuthorizationSettings>();
```

### Configuration

Configure Azure Entra ID settings in your `appsettings.json`:

```json
{
  "Authorization": {
    "Entra": {
      "Instances": {
        "Default": {
          "Scheme": "Bearer",
          "Instance": "https://login.microsoftonline.com/",
          "TenantId": "your-tenant-id",
          "ClientId": "your-client-id"
        }
      }
    }
  }
}
```

## Architecture

The provider follows the Cirreum authorization framework pattern with these key components:

- **EntraAuthorizationRegistrar**: Main registrar implementing Web API and Web App authentication setup
- **EntraAuthorizationSettings**: Root configuration settings
- **EntraAuthorizationInstanceSettings**: Per-instance configuration (extends base authorization settings)

## Contribution Guidelines

1. **Be conservative with new abstractions**  
   The API surface must remain stable and meaningful.

2. **Limit dependency expansion**  
   Only add foundational, version-stable dependencies.

3. **Favor additive, non-breaking changes**  
   Breaking changes ripple through the entire ecosystem.

4. **Include thorough unit tests**  
   All primitives and patterns should be independently testable.

5. **Document architectural decisions**  
   Context and reasoning should be clear for future maintainers.

6. **Follow .NET conventions**  
   Use established patterns from Microsoft.Extensions.* libraries.

## Versioning

Cirreum.Authorization.Entra follows [Semantic Versioning](https://semver.org/):

- **Major** - Breaking API changes
- **Minor** - New features, backward compatible
- **Patch** - Bug fixes, backward compatible

Given its role as an authorization provider, major version bumps are rare and carefully considered.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

**Cirreum Foundation Framework**  
*Layered simplicity for modern .NET*