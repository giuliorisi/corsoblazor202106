using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LibreriaDemo1.Models
{
    public class Persona
    {
        public int Id { get; set; }
        public string Email { get; set; }
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }
        public string avatar { get; set; }
    }

    public class Support
    {
        public string url { get; set; }
        public string text { get; set; }
    }

    public class DatiEsterni
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public List<Persona> data { get; set; } = new List<Persona>();
        public Support support { get; set; } = new Support();
    }


    public class ReqResPost
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Job { get; set; }
    }
}
