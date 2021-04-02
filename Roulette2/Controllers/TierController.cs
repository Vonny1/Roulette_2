using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Roulette.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Roulette.DataAccess.Context;
using System.Text.Json;
using Roulette.DataAccess.Context.Models;


namespace Roulette.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TierController : Controller
    {
        [HttpGet]
        public string GetAll()
        {
            string text = "";
            //Вывод моделей
            using (var db = new RouletteContext())
            {
                List<Tier> allTiers = db.Tiers.ToList();
                foreach (Tier i in allTiers)
                {
                    string jsonTier = JsonSerializer.Serialize<Tier>(i);
                    text += jsonTier;
                }
            }
            return text;
        }
        [HttpGet("get/{id}")]
        public string GetById(int id)
        {
            using (var db = new RouletteContext())
            {
                Tier tier = db.Tiers.FirstOrDefault(x => x.Id == id);
                string jsonTier = JsonSerializer.Serialize<Tier>(tier);
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
