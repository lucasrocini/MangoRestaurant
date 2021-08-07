using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mango.Services.Identity
{
    public static class SD
    {
        public const string Admin = "Admin";
        public const string Customer = "Customer";

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
            };

            public static IEnumerable<ApiScope> ApiScopes =>
                new List<ApiScope> 
                { 
                    new ApiScope("mango", "Magno Server"), //admin
                    new ApiScope(name: "read", displayName: "Read your data"),
                    new ApiScope(name: "write", displayName: "rite your data"),
                    new ApiScope(name: "delete", displayName: "Delete your data")
                };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                //Example client, not being used into the application
                new Client
                {
                    ClientId = "client",
                    ClientSecrets = {new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "read", "write", "profile"} // profile = builtin scope

                },
                new Client
                {
                    ClientId = "mango",
                    ClientSecrets = {new Secret("secret".Sha256())},
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = { "https://localhost:44321/signin-oidc" }, ///oidc = for open id connect
                    PostLogoutRedirectUris = { "https://localhost:44321/signout-callback-oidc" },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "mango"
                    }

                },
            };
    }
}
