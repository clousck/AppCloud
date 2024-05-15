using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppCloud.Entidades;
using AppEmpresa.ConsumeAPI;

namespace AppCloud.MVC3.Controllers
{
    public class GamesController : Controller
    {
        private string urlApi, urlBase;

        public GamesController(IConfiguration configuration)
        {
            urlApi = configuration.GetValue("ApiUrlBase", "").ToString() + "/Games";
            urlBase = configuration.GetValue("ApiUrlBase", "").ToString();
        }

        public Launcher[] GetLaunchers()
        {
            return CRUD<Launcher>.Read(urlBase + "/Launchers");
        }

        // GET: GamesController
        public ActionResult Index()
        {
            var data = CRUD<Game>.Read(urlApi);
            return View(data);
        }

        // GET: GamesController/Details/5
        public ActionResult Details(int id)
        {
            var data = CRUD<Game>.Read_ById(urlApi, id);
            return View(data);
        }

        // GET: GamesController/Create
        public ActionResult Create()
        {
            ViewBag.Launcher = GetLaunchers().Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Name.ToString()
            }).ToList();

            return View();
        }

        // POST: GamesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Game data)
        {
            try
            {
                var newData = CRUD<Game>.Create(urlApi, data);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: GamesController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = CRUD<Game>.Read_ById(urlApi, id);

            ViewBag.Launcher = GetLaunchers().Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Name.ToString()
            }).ToList();

            return View(data);
        }

        // POST: GamesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Game data)
        {
            try
            {
                CRUD<Game>.Update(urlApi, id, data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: GamesController/Delete/5    
        public ActionResult Delete(int id)
        {
            var data = CRUD<Game>.Read_ById(urlApi, id);
            return View(data);
        }

        // POST: GamesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Game data)
        {
            try
            {
                CRUD<Game>.Delete(urlApi, id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }
    }
}

