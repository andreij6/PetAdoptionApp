using PetApp.DataModels;
using PetApp.Web.Adapters.DataAdapter;
using PetApp.Web.Adapters.Interfaces;
using PetApp.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetApp.Web.Controllers
{
    public class HomeController : Controller
    {
        IPetAdapter db;

        public HomeController()
        {
            db = new PetAdapter();
        }

        public HomeController(IPetAdapter _db)
        {
            db = _db;
        }

        public ActionResult Index()
        {
            HomeVM model = new HomeVM();

            model.Pets = db.GetPets();

            model.SetFeaturedPet();

            model.Shelters = db.GetShelters();

            return View(model);
        }
    }
}