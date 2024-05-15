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
    public class LaunchersController : Controller
    {
        private string urlApi;

        public LaunchersController(IConfiguration configuration)
        {
            urlApi = configuration.GetValue("ApiUrlBase", "").ToString() + "/Launchers";
        }

        // GET: LaunchersController
        public ActionResult Index()
        {
            var data = CRUD<Launcher>.Read(urlApi);
            return View(data);
        }

        // GET: LaunchersController/Details/5
        public ActionResult Details(int id)
        {
            var data = CRUD<Launcher>.Read_ById(urlApi, id);
            return View(data);
        }

        // GET: LaunchersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LaunchersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Launcher data)
        {
            try
            {
                var newData = CRUD<Launcher>.Create(urlApi, data);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: LaunchersController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = CRUD<Launcher>.Read_ById(urlApi, id);
            return View(data);
        }

        // POST: LaunchersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Launcher data)
        {
            try
            {
                CRUD<Launcher>.Update(urlApi, id, data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: LaunchersController/Delete/5    
        public ActionResult Delete(int id)
        {
            var data = CRUD<Launcher>.Read_ById(urlApi, id);
            return View(data);
        }

        // POST: LaunchersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Launcher data)
        {
            try
            {
                CRUD<Launcher>.Delete(urlApi, id);
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
