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
    public class PredstavaController : ControllerBase
    {
        public PozoristeContext Context { get; set; }

        public PredstavaController(PozoristeContext context)
        {
            Context = context;
        }

        [Route("PreuzmiPredstave")]
        [HttpGet]
        public async Task<List<Predstava>> PreuzmiPredstave()
        {
            return await Context.Predstave.Include(x => x.Izvedbe).ToListAsync();
        }

        [Route("UpisiPredstavu/{PozName}/{Naz}/{Op}/{Ogr}")]
        [HttpPost]
        public async Task<ActionResult> UpisiPredstavu(string PozName, string Naz, string Op, string Ogr)
        {
            var poz = await Context.Pozorista.Where(x => x.Name == PozName).ToListAsync();
            if(Naz.Length > 50)
            {
                return BadRequest("Naziv predstave je predugacak");
            }
            if(Op.Length > 1000)
            {
                return BadRequest("Opis predstave je predugacak");
            }
            Predstava p = new Predstava
            {
                Naziv = Naz,
                Opis = Op,
                Ogranicenje = Ogr
            };
            foreach (Pozoriste x in poz)
            {
                p.Poz = x;
            }
            
            Context.Predstave.Add(p);
            await Context.SaveChangesAsync();
            return Ok("OKKK!!!!");
        }

        [Route("IzmeniPredstavu/{PozName}/{PrName}/{Naz}/{Op}/{Ogr}")]
        [HttpPut]
        public async Task<ActionResult> IzmeniPredstavu(string PozName, string PrName, string Naz, string Op, string Ogr)
        {
            if(Naz.Length > 50)
            {
                return BadRequest("Naziv predstave je predugacak");
            }
            if(Op.Length > 1000)
            {
                return BadRequest("Opis predstave je predugacak");
            }
            var poz = await Context.Pozorista.Where(x => x.Name == PozName).FirstOrDefaultAsync();
            var p = await Context.Predstave.Where(x => x.Naziv == PrName && x.Poz == poz).FirstOrDefaultAsync();
            p.Naziv = Naz;
            p.Opis = Op;
            p.Ogranicenje = Ogr;
            Context.Update<Predstava>(p);
            await Context.SaveChangesAsync();
            return Ok("OK!");
        }

        [Route("IzbrisiPredstavu/{PozName}/{PrName}")]
        [HttpDelete]
        public async Task<ActionResult> IzbrisiPredstavu(string PozName, string PrName)
        {
            var poz = await Context.Pozorista.Where(x => x.Name == PozName).FirstOrDefaultAsync();
            var p = await Context.Predstave.Where(x => x.Naziv == PrName && x.Poz == poz).FirstOrDefaultAsync();
            Context.Remove<Predstava>(p);
            await Context.SaveChangesAsync();
            return Ok("OK!");
        }

        [Route("IzbrisiPredPrekoID/{id}")]
        [HttpDelete]
        public async Task<ActionResult> IzbrisiPredPrekoID(int id)
        {
            var p = await Context.Predstave.Where(x => x.ID == id).FirstOrDefaultAsync();
            Context.Remove<Predstava>(p);
            await Context.SaveChangesAsync();
            return Ok("OK!");
        }
    }
}
