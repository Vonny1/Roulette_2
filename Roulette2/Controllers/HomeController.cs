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
    [Route("[home]")]
    public class HomeController : Controller
    {
        public string Index()
        {
            string text = "";

            //Добавление моделей
            using (var db = new RouletteContext())
            {
                //Title title1 = new Title { Name = "Bad_Title_2", Description = "is bad_2" };
                //db.Add(title1);
                //db.SaveChanges();

            }

            //Редактирование моделей
            using (var db = new RouletteContext())
            {
                Title titleBad2 = db.Titles
                    .Where(c => c.Name == "Bad_Title_2")
                    .FirstOrDefault();

                Tier tierBad = db.Tiers
                    .Where(c => c.Name == "Bad")
                    .FirstOrDefault();
                tierBad.Titles.Add(titleBad2);

                db.SaveChanges();
            }




            //Вывод моделей
            using (var db = new RouletteContext())
            {
                List<Title> allTitles = db.Titles.ToList();
                foreach (Title i in allTitles)
                {
                    string jsonTitle = JsonSerializer.Serialize<Title>(i);
                    text += jsonTitle + "\n";
                }





            }
            return text;
        }
    }
}
