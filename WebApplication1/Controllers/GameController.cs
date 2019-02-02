using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Game;
using System.Runtime;
namespace WebApplication1.Controllers
{
    public class GameController : Controller
    {
       
        readonly IGame gameGame;

        //private PerformanceCounter ramCounter;
        public GameController(IGame gameGame) 
        {
            this.gameGame = gameGame;
        }

        // GET: Game
        public ActionResult Index(string sortOrder)
        {
            TimeSpan start = new TimeSpan(DateTime.Now.Ticks);
            TimeSpan end;
            List<GameModel> listgames = gameGame.GetGames();
            ViewBag.IdSortParm = sortOrder == "Id" ? "id_desc" : "Id";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.PuntuationSortParm = sortOrder == "Puntuation" ? "puntuation" : "Puntuation";
            var students = from s in listgames
                           select s;
            switch (sortOrder)
            {
                case "id_desc":
                    students = students.OrderBy(s => s.Id);
                    end = new TimeSpan(DateTime.Now.Ticks);
                    ViewBag.Message = "Time:" + (end.TotalMilliseconds - start.TotalMilliseconds).ToString();
                    break;
                case "name_desc":
                    students = students.OrderByDescending(s => s.Name);
                    end = new TimeSpan(DateTime.Now.Ticks);
                    ViewBag.Message1 = "Time:" + (end.TotalMilliseconds - start.TotalMilliseconds).ToString();
                    break;
                case "Puntuation":
                    students = students.OrderBy(s => s.Puntuation);
                    end = new TimeSpan(DateTime.Now.Ticks);
                    ViewBag.Message2 = "Time:" + (end.TotalMilliseconds - start.TotalMilliseconds).ToString();
                    break;
            }
            return View(students.ToList());
        }
        // GET: Game/Details/5
        public ActionResult Details(int id)
        {
            GameModel game = gameGame.GetGame(id);
            return View(game);  
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                gameGame.AddGame(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            return View();
        }
        public ActionResult EditGame(int ID, string NAME, int PUNTUATION)
        {
            GameModel game = gameGame.GetGame(ID);
            game.Name = NAME;
            game.Puntuation = PUNTUATION;
            return View();
        }
        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}