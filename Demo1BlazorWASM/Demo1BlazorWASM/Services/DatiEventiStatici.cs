using LibreriaDemo1.Interfaces;
using LibreriaDemo1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo1BlazorWASM.Services
{
    public class DatiEventiStatici : IDatiEventi
    {
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
    }
}
