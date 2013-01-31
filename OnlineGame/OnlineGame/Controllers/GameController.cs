using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineGame.Filters;
using Models.Helpers;
using Models.Pages;
using Models.GameObjects;

namespace OnlineGame.Controllers
{
    public class GameController : Controller
    {
        
        public ActionResult Index()
        {
            var map = CreateMapHelper.CreateMap(1);
            var mapObject = new MapObject(map);

            return View(new GameViewModel(mapObject));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
