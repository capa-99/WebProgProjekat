using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEB_backend.Models
{
    [Table("Pozoriste")]
    public class Pozoriste 
    {
        [Key]
        [Column("ID")]
        public int ID {get; set;}

        [Column("Name")]
        public string Name {get; set;}

        public virtual List<Predstava> Predstave { get; set; }

        public virtual List<Sala> Sale { get; set; }

    }
}