using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Roulette.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace Roulette.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TierController : Controller
    {
        [HttpGet("get")]
        public string GetAll()
        {
            string text = "";
            //Вывод моделей
            using (var db = new RouletteContext())
            {
                List<Tier> allTiers = db.Tiers.Include("Titles").ToList();
                text = JsonConvert.SerializeObject(allTiers, Formatting.Indented, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    MaxDepth = 2
                }); 
            }
            return text;
        }
        [HttpGet("get/{id}")]
        public string GetById(int id)
        {
            using (var db = new RouletteContext())
            {
                Tier tier = db.Tiers.Include("Titles").FirstOrDefault(x => x.Id == id);
                string jsonTier = JsonConvert.SerializeObject(tier, Formatting.Indented, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    MaxDepth = 1
                });
                return jsonTier;
            }
        }
        [HttpPost("post")]
        public async Task<ActionResult<Tier>> Post(Tier tier)
        {
            using (var db = new RouletteContext())
            {
                if (tier == null)
                {
                    return BadRequest();
                }
                db.Tiers.Add(tier);
                await db.SaveChangesAsync();
                return Ok(tier);

            }
        }
        [HttpDelete("delete")]
        public async Task<ActionResult<Tier>> Delete(Tier tier)
        {
            using (var db = new RouletteContext())
            {
                if (tier == null)
                {
                    return BadRequest();
                }
                db.Tiers.Remove(tier);
                await db.SaveChangesAsync();
                return Ok(tier);
            }
        }
    }
}
