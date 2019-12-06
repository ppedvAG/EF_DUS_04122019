using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ppedv.Hampelmann.Logic;

namespace ppedv.Hampelmann.UI.Web.Controllers
{
    public class StandController : Controller
    {
        Core core = new Core();
        // GET: Stand
        public ActionResult Index()
        {
            return View(core.UnitOfWork.StandRepository.GetAll());
        }

        // GET: Stand/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Stand/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stand/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Stand/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Stand/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Stand/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Stand/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}