using LibreriaDemo1.Interfaces;
using LibreriaDemo1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Demo1BlazorWASM.Services
{
    public class DatiEventiStatici : IDatiEventi
    {
        private readonly HttpClient httpClient;
        private string url = "https://localhost:6001/Eventi";

        public DatiEventiStatici(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task CreaEvento(Evento nuovoEvento)
        {
            await httpClient.PostAsJsonAsync<Evento>(url, nuovoEvento);
        }

        public async Task EliminaEvento(int id)
        {
            await httpClient.DeleteAsync(url + "/" + id.ToString());
        }

        public List<ElementoListaEventi> EstraiEventi()
        {
            return new List<ElementoListaEventi>
            {
                new ElementoListaEventi {Id = 1, Nome = "Corso Blazor",
                    Localita = "Remote",  Data = DateTime.Today},
                new ElementoListaEventi {Id = 2, Nome = "Corso Blazor WASm",
                    Localita = "Remote",  Data = DateTime.Today.AddDays(7)},
            };
        }

        public async Task<List<ElementoListaEventi>> EstraiEventiDaAPI()
        {
            var listaEventi = await httpClient.GetFromJsonAsync<List<Evento>>("https://localhost:6001/Eventi");

            return listaEventi.Select(ev => new ElementoListaEventi {
                 Id = ev.Id,
                  Data = ev.Data,
                   Localita = ev.Localita,
                    Nome = ev.Nome
            }).ToList();
        }

        public async Task<Evento> EstraiEventoPerID(int id)
        {
            return await httpClient.GetFromJsonAsync<Evento>(url + "/" + id.ToString());
        }

        public async Task ModificaEvento(Evento evento)
        {
            await httpClient.PutAsJsonAsync<Evento>(url + "/" + evento.Id.ToString(), evento);
        }
    }
}
