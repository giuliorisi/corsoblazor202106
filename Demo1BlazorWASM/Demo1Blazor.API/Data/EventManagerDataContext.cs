using System;
using LibreriaDemo1.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo1Blazor.API.Data
{
    public class EventManagerDataContext: DbContext
    {
        public DbSet<Evento> Eventi { get; set; }

        public EventManagerDataContext(DbContextOptions opzioni): base(opzioni)
        {

        }
    }
}
