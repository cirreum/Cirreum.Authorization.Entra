namespace Cirreum.Authorization;

using Cirreum.Authorization.Configuration;
using Cirreum.AuthorizationProvider;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Web;

public sealed class EntraAuthorizationRegistrar
	: AuthorizationProviderRegistrar<
		EntraAuthorizationSettings,
		EntraAuthorizationInstanceSettings> {

	public override ProviderType ProviderType => ProviderType.Authorization;

	public override string ProviderName => "Entra";

	public override void AddAuthorizationForWebApi(IConfigurationSection instanceSection,
		EntraAuthorizationInstanceSettings providerSettings,
		AuthenticationBuilder authBuilder) {
		authBuilder.AddMicrosoftIdentityWebApi(
					instanceSection,
					jwtBearerScheme: providerSettings.Scheme);
	}
	public override void AddAuthorizationForWebApp(IConfigurationSection instanceSection,
		EntraAuthorizationInstanceSettings providerSettings,
		AuthenticationBuilder authBuilder) {
		authBuilder.AddMicrosoftIdentityWebApp(
					instanceSection,
					openIdConnectScheme: providerSettings.Scheme);
	}

}