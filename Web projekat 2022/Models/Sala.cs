using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WEB_backend.Models
{
    [Table("Sala")]
    public class Sala
    {
        [Key]
        [Column("ID")]
        public int ID {get; set;}

        [Column("Broj")]
        public int Broj {get; set;}

        [JsonIgnore]
        public Pozoriste Poz { get; set; }

        [Column("Kapacitet")]
        public int Kapacitet { get; set; }

        public virtual List<Izvedba> Izvedbe { get; set; }

    }
}