using DataRegister.Base;
using DataRegister.Base.Models;
using DataRegister.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataRegister.WebUI.Controllers
{
    public class PlayerManagerController : Controller
    {
        IRepository repository;
        Player player;
        IEnumerable<Player> players;
        public PlayerManagerController()
        {
            
            player = new Player();
            repository = new SqlRepository();
            players = repository.Collection();

        }
        public ActionResult Index()
        {
            return View(players);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Player player)
        {
            if(ModelState.IsValid)
            {
                repository.Insert(player);
                repository.Commit();
                return RedirectToAction("Index");
            }
            else
            {
                return View(player);
            }
            
        }
    }
}