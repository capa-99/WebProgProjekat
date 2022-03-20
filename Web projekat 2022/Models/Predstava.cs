using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WEB_backend.Models
{
    [Table("Predstava")]
    public class Predstava 
    {
        [Key]
        [Column("ID")]
        public int ID {get; set;}

        [Column("Naziv")]
        public string Naziv {get; set;}

        [Column("Opis")]
        public string Opis { get; set; }

        [Column("Ogranicenje")]
        public string Ogranicenje { get; set; }

        [JsonIgnore]
        public Pozoriste Poz { get; set; }

        public virtual List<Izvedba> Izvedbe { get; set; }
    }
}