using LibreriaDemo1.Interfaces;
using LibreriaDemo1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace BestPractices.Models
{
    public class ServizioReqRes : IReqResService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private CancellationTokenSource cancellationTokenSource;

        public ServizioReqRes(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public void Cancel()
        {
            cancellationTokenSource.Cancel();
        }

        public async Task<string> Create(ReqResPost nuovoUtente)
        {
            var httpClient = httpClientFactory.CreateClient("reqres");
            using var response = await httpClient.PostAsJsonAsync("users", nuovoUtente);
            return response.StatusCode.ToString();
        }

        public async Task<DatiEsterni> GetData()
        {
            var httpClient = httpClientFactory.CreateClient("reqres");
            cancellationTokenSource = new CancellationTokenSource();

            using var response = await httpClient.GetAsync
                ("users", HttpCompletionOption.ResponseHeadersRead, cancellationTokenSource.Token);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<DatiEsterni>();
            } else
            {
                return null;
            }
        }
    }
}
