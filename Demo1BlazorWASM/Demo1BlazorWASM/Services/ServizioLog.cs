using LibreriaDemo1.Interfaces;
using LibreriaDemo1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo1BlazorWASM.Services
{
    public class ServizioLog : ILog
    {
        public IEnumerable<Log> Logs()
        {
            return new List<Log>
            {
                new Log
                {
                    Id = Guid.NewGuid().ToString(),
                    Description = "Evento 1",
                    Severity = "Warning",
                    TimeStamp = DateTime.UtcNow.ToString()
                },
                                new Log
                {
                    Id = Guid.NewGuid().ToString(),
                    Description = "Evento 2",
                    Severity = "Error",
                    TimeStamp = DateTime.UtcNow.ToString()
                },
                                                new Log
                {
                    Id = Guid.NewGuid().ToString(),
                    Description = "Evento 3",
                    Severity = "Info",
                    TimeStamp = DateTime.UtcNow.ToString()
                }


            };
        }
    }
}
