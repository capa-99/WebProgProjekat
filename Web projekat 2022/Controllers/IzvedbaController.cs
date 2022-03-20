using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WEB_backend.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

namespace WEB_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IzvedbaController : ControllerBase
    {
        public PozoristeContext Context { get; set; }

        public IzvedbaController(PozoristeContext context)
        {
            Context = context;
        }

        [Route("PreuzmiIzvedbe")]
        [HttpGet]
        public async Task<List<Izvedba>> PreuzmiIzvedbe()
        {
            return await Context.Izvedbe.ToListAsync();
        }

        [Route("UpisiIzvedbu/{PozName}/{PrNaz}/{BrS}/{Dat}/{Vr}/{Kart}")]
        [HttpPost]
        public async Task<Izvedba> UpisiIzvedbu(string PozName, string PrNaz, int BrS, string Dat, string Vr, int Kart)
        {
            var poz = await Context.Pozorista.Where(x => x.Name == PozName).FirstOrDefaultAsync();
            var p = await Context.Predstave.Where(x => x.Naziv == PrNaz && x.Poz == poz).FirstOrDefaultAsync();
            var s = await Context.Sale.Where(x => x.Broj == BrS && x.Poz == poz).FirstOrDefaultAsync();
            Izvedba i = new Izvedba
            {
                Datum = Dat,
                Vreme = Vr,
                Karte = Kart
            };
            i.Predstava = p;
            i.Sala = s;
            
            Context.Izvedbe.Add(i);
            await Context.SaveChangesAsync();
            return i;
           
        }

        [Route("IzmeniIzvedbu/{PozName}/{PrNaz}/{BrS}/{Dat}/{Vr}/{Kart}/{IzvID}")]
        [HttpPut]
        public async Task<ActionResult> IzmeniIzvedbu(string PozName, string PrNaz, int BrS, string Dat, string Vr, int Kart, int IzvID)
        {
            var poz = await Context.Pozorista.Where(x => x.Name == PozName).FirstOrDefaultAsync();
            var p = await Context.Predstave.Where(x => x.Naziv == PrNaz && x.Poz == poz).FirstOrDefaultAsync();
            var s = await Context.Sale.Where(x => x.Broj == BrS && x.Poz == poz).FirstOrDefaultAsync();
            var i = await Context.Izvedbe.Where(x => x.ID == IzvID && x.Predstava == p && x.Sala == s).FirstOrDefaultAsync();
            i.Datum = Dat;
            i.Vreme = Vr;
            i.Karte = Kart;
            i.Sala = s;
            Context.Update<Izvedba>(i);
            await Context.SaveChangesAsync();
            return Ok("OK!");
        }

        [Route("IzbrisiIzvedbu/{PozName}/{PrNaz}/{BrS}/{IzvID}")]
        [HttpDelete]
        public async Task<ActionResult> IzbrisiIzvedbu(string PozName, string PrNaz, int BrS, int IzvID)
        {
            var poz = await Context.Pozorista.Where(x => x.Name == PozName).FirstOrDefaultAsync();
            var p = await Context.Predstave.Where(x => x.Naziv == PrNaz && x.Poz == poz).FirstOrDefaultAsync();
            var s = await Context.Sale.Where(x => x.Broj == BrS && x.Poz == poz).FirstOrDefaultAsync();
            var i = await Context.Izvedbe.Where(x => x.ID == IzvID && x.Predstava == p && x.Sala == s).FirstOrDefaultAsync();
            Context.Remove<Izvedba>(i);
            await Context.SaveChangesAsync();
            return Ok("OK!");
        }

        [Route("IzbrisiIzvPrekoID/{id}")]
        [HttpDelete]
        public async Task<ActionResult> IzbrisiIzPrekoID( int id)
        {
            var i = await Context.Izvedbe.Where(x => x.ID == id).FirstOrDefaultAsync();
            Context.Remove<Izvedba>(i);
            await Context.SaveChangesAsync();
            return Ok("OK!");
        }
    }
}
