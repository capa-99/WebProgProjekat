using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WEB_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace WEB_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PozoristeController : ControllerBase
    {
        public PozoristeContext Context { get; set; }

        public PozoristeController(PozoristeContext context)
        {
            Context = context;
        }

        [Route("PreuzmiPozorista")]
        [HttpGet]
        public async Task<List<Pozoriste>> PreuzmiPozorista()
        {
            return await Context.Pozorista.Include("Predstave.Izvedbe")
                                          .Include("Sale.Izvedbe").ToListAsync();
        }

        [Route("UpisiPozorista")]
        [HttpPost]
        public async Task UpisiPozorista([FromBody] Pozoriste p)
        {
            Context.Pozorista.Add(p);
            await Context.SaveChangesAsync();
        }

        [Route("IzmeniPozorista")]
        [HttpPut]
        public async Task IzmeniPozorista([FromBody] Pozoriste p)
        {
            Context.Update<Pozoriste>(p);
            await Context.SaveChangesAsync();
        }

        [Route("IzbrisiPozorista/{id}")]
        [HttpDelete]
        public async Task IzbrisiPozorista(int id)
        {
            var p = await Context.FindAsync<Pozoriste>(id);
            Context.Remove(p);
            await Context.SaveChangesAsync();
        }
    }
}
