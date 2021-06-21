using System;
using System.Threading.Tasks;
using Demo1Blazor.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibreriaDemo1.Models;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Demo1Blazor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventiController : ControllerBase
    {
        private readonly EventManagerDataContext database;
        private readonly ILogger<EventiController> logger;

        public EventiController(EventManagerDataContext database, ILogger<EventiController> logger)
        {
            this.database = database;
            this.logger = logger;
        }

        [HttpGet]
        [Produces(typeof(List<Evento>))]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetEventi()
        {
            try
            {
                var eventi = await database.Eventi.ToListAsync();

                if (eventi.Count == 0)
                {
                    //database.Eventi.Add(new Evento
                    //{
                    //    Data = DateTime.Today,
                    //    Descrizione = "Descrizione 1",
                    //    Localita = "Napoli",
                    //    Nome = "Asp.NET Core API",
                    //    Note = "Bla bla"
                    //});


               
                    //await database.SaveChangesAsync();
                    //eventi = await database.Eventi.ToListAsync();

                    return NotFound();
                }


                return Ok(eventi);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetEventoById(int id)
        {
            try
            {
                var eventi = await database.Eventi.ToListAsync();
                var evento = await database.Eventi.FirstOrDefaultAsync(b => b.Id == id);
                if (evento == null) return NotFound();
                return Ok(evento);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }


        }


        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> PostEvent([FromBody] Evento nuovoEvento) 
        {
            try
            {
                logger.LogInformation(nuovoEvento.Data.ToLongDateString());

                if (nuovoEvento == null) return BadRequest();
                database.Eventi.Add(nuovoEvento);
                await database.SaveChangesAsync();
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex.Message);
                return StatusCode(500, ex.Message);
               
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> PutEvent(int id, [FromBody] Evento evento)
        {
            try
            {
                if(evento == null ||  (evento != null && evento.Id != id ))
                {
                    return BadRequest();
                }

                var eventoSuDatabase = await database.Eventi.FindAsync(id);
                if (eventoSuDatabase == null) return NotFound();

               // database.Entry(eventoSuDatabase).

                eventoSuDatabase.Data = evento.Data;
                eventoSuDatabase.Descrizione = evento.Descrizione;
                eventoSuDatabase.Localita = evento.Localita;
                eventoSuDatabase.Nome = evento.Nome;
                eventoSuDatabase.Note = evento.Note;

                await database.SaveChangesAsync();
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            if (id <= 0) return BadRequest();
            try
            {
                var bigliettoDatabase = await database.Eventi.FindAsync(id);
                if (bigliettoDatabase == null) return NotFound();
                database.Eventi.Remove(bigliettoDatabase);
                await database.SaveChangesAsync();
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
