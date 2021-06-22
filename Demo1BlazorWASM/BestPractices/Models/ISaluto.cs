using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BestPractices.Models
{
    public interface ISaluto
    {
        public string Saluta();
    }


    public class SalutoItaliano : ISaluto
    {
        public string Saluta()
        {
            return "Ciao";
        }
    }

    public class SalutoSpagnolo : ISaluto
    {
        public string Saluta()
        {
            return "Ciao";
        }
    }

}
