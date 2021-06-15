using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo1BlazorServer.Data
{
    public class ServizioDati : IServizioDati
    {
        public string EstraiDataEOra()
        {
           return DateTime.Now.ToLongTimeString();
        }
    }
}
