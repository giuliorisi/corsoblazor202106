using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWASM.Client.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string CF { get; set; }
    }

    public class Operazione
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public bool Sincro { get; set; }
        public string Categoria { get; set; }

    }
}
