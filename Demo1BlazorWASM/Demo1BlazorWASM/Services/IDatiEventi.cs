using Demo1BlazorWASM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo1BlazorWASM.Services
{
    public interface IDatiEventi
    {
        List<ElementoListaEventi> EstraiEventi();
    }
}
