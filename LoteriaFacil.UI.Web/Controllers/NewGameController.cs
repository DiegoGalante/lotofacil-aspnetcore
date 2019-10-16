﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoteriaFacil.UI.Web.Controllers
{
    public class NewGameController : Controller
    {
        // GET: NewGame
        [HttpGet]
        [Route("/novo-jogo")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: NewGame/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NewGame/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewGame/Create
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

        // GET: NewGame/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NewGame/Edit/5
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

        // GET: NewGame/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NewGame/Delete/5
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