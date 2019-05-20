using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.PubSub.V1;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using PaymentGateway.Domain;

namespace PaymentGateway
{
    public class Program
    {
        public static async Task Main(string[] args)
        {

            Domain.Subscriber.PullMessageAsync("pts6-bijbaan", "paypal-generic", true);
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
