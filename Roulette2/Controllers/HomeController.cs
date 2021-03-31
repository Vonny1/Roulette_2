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
    public class HomeController : Controller
    {
        public string Index()
        {
            string text = "";

            //Добавление моделей
            //using (var db = new RouletteContext())
            //{
            //    Tier tier1 = new Tier { Name = "Good", Value = 60 };
            //    Tier tier2 = new Tier { Name = "Normal", Value = 30 };
            //    Tier tier3 = new Tier { Name = "Bad", Value = 10 };

            //    db.Add(tier1);
            //    db.Add(tier2);
            //    db.Add(tier3);
            //    db.SaveChanges();



            //    Title title1 = new Title { Name = "Good_Title", Description = "is good" };
            //    Title title2 = new Title { Name = "Normal_Title", Description = "is normal" };
            //    Title title3 = new Title { Name = "Bad_Title", Description = "is bad" };

            //    Title title4 = new Title { Name = "Good_Title_2", Description = "is good_2" };
            //    db.Add(title1);
            //    db.Add(title2);
            //    db.Add(title3);
            //    db.Add(title4);
            //    db.SaveChanges();

            //}

            //Редактирование моделей
            //using (var db = new RouletteContext())
            //{
            //    Tier good = db.Tiers
            //        .Where(c => c.Name == "Good")
            //        .FirstOrDefault();

            //    List<Title> normalTitles = db.Titles
            //        .Where(c => c.Name == "Normal_Title")
            //        .ToList();

            //    Title title = db.Titles
            //        .Where(c => c.Name == "Good_Title")
            //        .FirstOrDefault();
            //    //foreach (var i in normalTitles)
            //    //{
            //    //    good.Titles.Add(i);
            //    //}

            //    good.Titles.Add(title);
            //    db.SaveChanges();
            //}




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
