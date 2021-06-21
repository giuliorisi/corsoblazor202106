using LibreriaDemo1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibreriaDemo1.Interfaces
{
    public interface IDatiEventi
    {
        List<ElementoListaEventi> EstraiEventi();
        Task<List<ElementoListaEventi>> EstraiEventiDaAPI();
        Task CreaEvento(Evento nuovoEvento);
        Task<Evento> EstraiEventoPerID(int id);
        Task ModificaEvento(Evento evento);
        Task EliminaEvento(int id);
    }
}
