namespace Cirreum.Authorization;

using Cirreum.Authorization.Configuration;
using Cirreum.AuthorizationProvider;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Web;

/// <summary>
/// Registrar for Entra (Azure AD) authorization provider instances.
/// </summary>
public sealed class EntraAuthorizationRegistrar
	: AudienceAuthorizationProviderRegistrar<
		EntraAuthorizationSettings,
		EntraAuthorizationInstanceSettings> {

	public override string ProviderName => "Entra";

	/// <inheritdoc/>
	public override void ValidateSettings(EntraAuthorizationInstanceSettings settings) {

		if (string.IsNullOrWhiteSpace(settings.TenantId)) {
			throw new InvalidOperationException(
				$"Entra provider instance '{settings.Scheme}' requires a TenantId.");
		}

		if (string.IsNullOrWhiteSpace(settings.ClientId)) {
			throw new InvalidOperationException(
				$"Entra provider instance '{settings.Scheme}' requires a ClientId.");
		}

	}

	/// <inheritdoc/>
	public override void AddAuthorizationForWebApi(IConfigurationSection instanceSection,
		EntraAuthorizationInstanceSettings providerSettings,
		AuthenticationBuilder authBuilder) {
		authBuilder.AddMicrosoftIdentityWebApi(
					instanceSection,
					jwtBearerScheme: providerSettings.Scheme);
	}

	/// <inheritdoc/>
	public override void AddAuthorizationForWebApp(IConfigurationSection instanceSection,
		EntraAuthorizationInstanceSettings providerSettings,
		AuthenticationBuilder authBuilder) {
		authBuilder.AddMicrosoftIdentityWebApp(
					instanceSection,
					openIdConnectScheme: providerSettings.Scheme);
	}

}