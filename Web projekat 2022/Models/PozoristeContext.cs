using Microsoft.EntityFrameworkCore;

namespace WEB_backend.Models
{

    public class PozoristeContext : DbContext
    {
        public DbSet<Pozoriste> Pozorista {get; set;}
        public DbSet<Predstava> Predstave {get; set;}
        public DbSet<Izvedba> Izvedbe {get; set;}
        public DbSet<Sala> Sale {get; set;}

        public PozoristeContext(DbContextOptions options) : base(options) 
        {

        }
    }
}