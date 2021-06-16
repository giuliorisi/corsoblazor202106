using System;
using System.ComponentModel.DataAnnotations;

namespace LibreriaDemo1.Models
{
    public class Evento
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Il nome è obbligatorio")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "La località è obbligatorio")]
        [StringLength(30, ErrorMessage ="Lunghezza massima di {1} caratteri")]
        public string Localita { get; set; }
        public DateTime Data { get; set; }
        public string Descrizione { get; set; }
        public string Note { get; set; }
    }
}
