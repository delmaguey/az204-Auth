using System;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace az204_auth
{
    class Program
    {
        private const string _clientId = "<ClientID>";
        private const string _tenantId = "<TenantID>";

        public static async Task Main(string[] args)
        {
            IPublicClientApplication app = PublicClientApplicationBuilder
                        .Create(_clientId)
                        .WithAuthority(AzureCloudInstance.AzurePublic, _tenantId)
                        .WithRedirectUri("http://localhost")
                        .Build();

            string[] scopes = { "user.read" };
            AuthenticationResult result = await app.AcquireTokenInteractive(scopes).ExecuteAsync();

            Console.WriteLine($"Token:\t{result.AccessToken}");


        }
    }
}
