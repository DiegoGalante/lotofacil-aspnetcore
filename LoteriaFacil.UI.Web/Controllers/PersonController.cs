using LoteriaFacil.Application.Interfaces;
using LoteriaFacil.Application.ViewModels;
using LoteriaFacil.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace LoteriaFacil.UI.Web.Controllers
{
    [Produces("application/json")]
    public class PersonController : BaseController
    {
        private readonly IPersonAppService _personAppService;

        public PersonController(IPersonAppService personAppService,
                                INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _personAppService = personAppService;
        }

        [HttpGet]
        [Route("/jogadores")]
        [Route("/players")]
        public IActionResult Index()
        {
            return View(_personAppService.GetAll());
        }

        [HttpGet]
        [Route("/register-new")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("/register-new")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PersonViewModel personViewModel)
        {
            if (!ModelState.IsValid)
                return View(personViewModel);

            _personAppService.Register(personViewModel);
            if (IsValidOperation())
                ViewBag.Sucesso = "Cadastro realizado com sucesso!";

            return View(personViewModel);
        }

        [HttpGet]
        [Route("edit-person/{id:guid}")]
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personViewModel = _personAppService.GetById(id.Value);

            if (personViewModel == null)
            {
                return NotFound();
            }

            return View(personViewModel);
        }

        [HttpPost]
        [Route("edit-person/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PersonViewModel personViewModel)
        {
            if (!ModelState.IsValid) return View(personViewModel);

            _personAppService.Update(personViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Atualizado com sucesso!";

            return View(personViewModel);
        }

        [HttpGet]
        [Route("remove-person/{id:guid}")]
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personViewModel = _personAppService.GetById(id.Value);

            if (personViewModel == null)
            {
                return NotFound();
            }

            return View(personViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [Route("remove-person/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _personAppService.Remove(id);

            if (!IsValidOperation()) return View(_personAppService.GetById(id));

            ViewBag.Sucesso = "Dados removido com sucesso!!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ListAll()
        {
            return PartialView("_TabelaPessoasPartial", _personAppService.GetAll());
        }

    }
}
