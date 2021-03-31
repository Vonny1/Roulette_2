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
    #region save
    //Добавление моделей
    //    using (var db = new RouletteContext())
    //            {
    //                //Title title1 = new Title { Name = "Bad_Title_2", Description = "is bad_2" };
    //                //db.Add(title1);
    //                //db.SaveChanges();

    //            }

    ////Редактирование моделей
    //using (var db = new RouletteContext())
    //{
    //    Title titleBad2 = db.Titles
    //        .Where(c => c.Name == "Bad_Title_2")
    //        .FirstOrDefault();

    //    Tier tierBad = db.Tiers
    //        .Where(c => c.Name == "Bad")
    //        .FirstOrDefault();
    //    tierBad.Titles.Add(titleBad2);

    //    db.SaveChanges();
    //}
    #endregion
    [ApiController]
    [Route("[controller]")]
    public class TitleController : Controller
    {
        [HttpGet]
        public string GetAll()
        {
            string text = "";
            //Вывод моделей
            using (var db = new RouletteContext())
            {
                List<Title> allTitles = db.Titles.ToList();
                foreach (Title i in allTitles)
                {
                    string jsonTitle = JsonSerializer.Serialize<Title>(i);
                    text += jsonTitle;
                }
            }
            return text;
        }
        [HttpGet("{id}")]
        public string GetById(int id)
        {
            using (var db = new RouletteContext())
            {
                Title title = db.Titles.FirstOrDefault(x => x.Id == id);
                string jsonTitle = JsonSerializer.Serialize<Title>(title);
                return jsonTitle;

            }
        }
    }
}
