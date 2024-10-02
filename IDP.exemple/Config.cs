using Duende.IdentityServer.Models;

namespace IDP.exemple
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            [
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new ("roles","All app role(s)",["role"])
            ];

        public static IEnumerable<ApiScope> ApiScopes =>
            [
                new ApiScope{
                    Name = "rewardsApi.read",
                    Description = "Rewards API",
                },
            ];

        public static IEnumerable<Client> Clients =>
            [
                    new Client
                    {
                        ClientId = "client_id_credentials",
                        RequirePkce = true,
                        AccessTokenType = AccessTokenType.Reference,
                        AllowedGrantTypes = GrantTypes.ClientCredentials,
                        AllowedScopes = { "rewardsApi.read" },
                        RedirectUris = { "com.client.credentials://callback" },
                    },
                    new Client
                    {
                        ClientId = "client_id_code",
                        ClientSecrets = { new Secret("client_secret_code".Sha256()) },
                        RequirePkce = true,
                        AccessTokenType = AccessTokenType.Reference,
                        AllowedGrantTypes = GrantTypes.Code,
                        AllowedScopes = { "rewardsApi.read" },
                        RedirectUris = { "https://localhost:7237/callback" },
                        PostLogoutRedirectUris = { "https://localhost:7237/callback" },
                        RequireConsent = true,
                        RequireClientSecret = true
                    }
            ];
    }
}