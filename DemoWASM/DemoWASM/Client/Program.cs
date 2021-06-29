using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TG.Blazor.IndexedDB;

namespace DemoWASM.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddIndexedDB(database =>
            {
                database.DbName = "DMG2";
                database.Version = 3;

                database.Stores.Add(new StoreSchema
                {
                    Name = "People",
                    PrimaryKey = new IndexSpec { Name="id", Auto = true, KeyPath = "id" },
                    Indexes = new List<IndexSpec>
                    {
                        new IndexSpec { Name = "firstName", Auto = false, KeyPath= "firstName"},
                        new IndexSpec { Name = "lastName", Auto = false, KeyPath= "lastName"},
                        new IndexSpec {Name = "address", Auto=false, KeyPath = "address"}
                    }
                });

                database.Stores.Add(new StoreSchema
                {
                    Name = "Operazioni",
                    PrimaryKey = new IndexSpec { Name = "id", Auto = true, KeyPath = "id" },
                    Indexes = new List<IndexSpec>
                    {
                        new IndexSpec { Name = "timestamp", Auto = false, KeyPath= "timestamp"},
                        new IndexSpec { Name = "categoria", Auto = false, KeyPath= "categoria"},
                        new IndexSpec { Name = "sincro", Auto = false, KeyPath= "sincro"}
                    }
                });



            });

            await builder.Build().RunAsync();
        }
    }
}
