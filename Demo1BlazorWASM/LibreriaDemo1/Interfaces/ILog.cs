using LibreriaDemo1.Models;
using System.Collections.Generic;

namespace LibreriaDemo1.Interfaces
{
    public interface ILog
    {
        IEnumerable<Log> Logs();
    }
}
