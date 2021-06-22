using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaDemo1.Models
{
    public class HelloHelper
    {
        public HelloHelper(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        [JSInvokable]
        public string SayHello()
        {
            return $"Ciao, {Name}, {new Random().NextDouble()}";
        }

    }
}
