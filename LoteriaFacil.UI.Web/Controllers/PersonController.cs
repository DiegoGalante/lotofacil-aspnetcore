﻿using LoteriaFacil.Application.Interfaces;
using LoteriaFacil.Application.ViewModels;
using LoteriaFacil.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

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
        //[AllowAnonymous]
        //[Route("person-management/list-all")]
        [Route("/jogadores")]
        [Route("/players")]
        public IActionResult Index()
        {
            return View();

            //_personAppService.GetAll();
        }

        [HttpGet]
        [Route("/Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        [Route("/Create")]
        public IActionResult Create(PersonViewModel personViewModel)
        {
            if (!ModelState.IsValid)
                return View(personViewModel);

            _personAppService.Register(personViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Cadastro realizado com sucesso!";

            return View();
        }

        [HttpPost]
        //[Authorize(Policy = "CanWritePersonData")] ?
        //[Route("customer-management/edit-customer/{id:guid}")]
        [Route("saveplayer")]
        public IActionResult Index([FromBody]object player)
        {
            PersonViewModel personViewModel = JsonConvert.DeserializeObject<PersonViewModel>(player.ToString());

            if (!ModelState.IsValid) return View(personViewModel);

            if (personViewModel.Id.Equals(Guid.Empty))
                _personAppService.Register(personViewModel);
            else
                _personAppService.Update(personViewModel);


            if (IsValidOperation())
                ViewBag.Sucesso = "Atualizado com sucesso!";

            return View();
        }

        [HttpPost]
        public System.Collections.Generic.IEnumerable<PersonViewModel> ListAll()
        {
            return _personAppService.GetAll();
        }

    }
}
