using BestPractices.Models;
using LibreriaDemo1;
using LibreriaDemo1.Interfaces;
using LibreriaDemo1.Models;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Polly;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BestPractices
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped<ISaluto, SalutoItaliano>();

            builder.Services.AddSingleton(provider =>
            {
                var config = provider.GetService<IConfiguration>();
                var mySettingsSection = config.GetSection(nameof(MySettings));
                var settings = mySettingsSection.Get<MySettings>();
                return settings;
            });

            builder.Services.AddHttpClient("reqres", client =>
            {
                client.BaseAddress = new Uri("https://reqres.in/api/");
            })
            .AddTransientHttpErrorPolicy( x => 
                x.WaitAndRetryAsync(new[] { TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(20)}));

            builder.Services.AddScoped<IReqResService, ServizioReqRes>();

            await builder.Build().RunAsync();
        }
    }
}
