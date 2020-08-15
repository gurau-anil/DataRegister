using DataRegister.Base;
using DataRegister.Base.Models;
using DataRegister.SQL;
using System;
using System.Collections.Generic;
using System.IO;
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
        public ActionResult Create(Player player,HttpPostedFileBase file)
        {
            if(ModelState.IsValid)
            {
                if (file!=null)
                {
                    //Saving Image file to the device
                    player.Image = player.PlayerId + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//Images//") + player.Image);
                    
                }
                repository.Insert(player);
                repository.Commit();
                return RedirectToAction("Index");
            }
            else
            {
                return View(player);
            }
            
        }

        public ActionResult Edit(string Id)
        {
            if(Id==null)
            {
                return View("Error");
            }
            
            else
            {
                player = repository.Find(Id);
                if (player==null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View(player);
                }
            }
        }
        [HttpPost]
        public ActionResult Edit(Player player, HttpPostedFileBase file) //public ActionResult Edit(Player item,string Id)
        {
            //Player playerToEdit = repository.Find(Id);
            //if (playerToEdit == null)
            //{
            //    return HttpNotFound();
            //}
            //else
            //{
            //    if (!ModelState.IsValid)
            //    {
            //        return View(item);
            //    }
            //    playerToEdit.FirstName = item.FirstName;
            //    playerToEdit.LastName = item.LastName;
            //    playerToEdit.Phone = item.Phone;
            //    playerToEdit.Email = item.Email;
            //    playerToEdit.Image = item.Image;
            //    repository.Update(item);

            //    repository.Commit();
            //    return RedirectToAction("Index");
            //}
            if(ModelState.IsValid)
            {
                if (file!=null)
                {
                    player.Image = player.PlayerId + Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("//Content//Images//") + player.Image);
                }
                repository.Update(player);
                repository.Commit();
                return RedirectToAction("Index");
            }
            else
            {
                return View(player);
            }
        }

        public ActionResult Delete(string Id)
        {
            if(Id==null)
            {
                return View("Error");
            }
            player = repository.Find(Id);
            if(player==null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(player);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            player = repository.Find(Id);
            if (player == null)
            {
                return HttpNotFound();
            }
            else
            {
                repository.Delete(Id);
                repository.Commit();
                return RedirectToAction("Index");
            }

        }
    }
}