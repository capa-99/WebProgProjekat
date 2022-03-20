using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WEB_backend.Models
{
    [Table("Izvedba")]
    public class Izvedba 
    {
        [Key]
        [Column("ID")]
        public int ID {get; set;}

        [JsonIgnore]
        public Predstava Predstava {get; set;}

        [JsonIgnore]
        public Sala Sala { get; set; }

        [Column("Datum")]
        public string Datum { get; set; }

        [Column("Vreme")]
        public string Vreme { get; set; }

        [Column("Karte")]
        public int Karte { get; set; }

    }
}