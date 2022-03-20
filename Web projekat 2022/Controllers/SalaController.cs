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
    public class SalaController : ControllerBase
    {
        public PozoristeContext Context { get; set; }

        public SalaController(PozoristeContext context)
        {
            Context = context;
        }

        [Route("PreuzmiSale")]
        [HttpGet]
        public async Task<List<Sala>> PreuzmiSale()
        {
            return await Context.Sale.Include(x => x.Izvedbe).ToListAsync();
        }

        [Route("UpisiSalu/{PozName}/{Br}/{Kap}")]
        [HttpPost]
        public async Task<ActionResult> UpisiSalu(string PozName, int Br, int Kap)
        {
            if(Kap > 10000)
            {
                return BadRequest("Kapacitet sale je prevelik");
            }
            if(Br > 100)
            {
                return BadRequest("Broj sale je prevelik");
            }
            var poz = await Context.Pozorista.Where(x => x.Name == PozName).ToListAsync();
            Sala p = new Sala
            {
                Broj = Br,
                Kapacitet = Kap
            };
            foreach (Pozoriste x in poz)
            {
                p.Poz = x;
            }
            
            Context.Sale.Add(p);
            await Context.SaveChangesAsync();
            return Ok("OKKK!!!!");
        }

        [Route("IzmeniSalu")]
        [HttpPut]
        public async Task IzmeniSalu([FromBody] Sala p)
        {
            Context.Update<Sala>(p);
            await Context.SaveChangesAsync();
        }

        [Route("IzbrisiSalu/{id}")]
        [HttpDelete]
        public async Task IzbrisiSAlu(int id)
        {
            var p = await Context.FindAsync<Sala>(id);
            Context.Remove(p);
            await Context.SaveChangesAsync();
        }
    }
}
