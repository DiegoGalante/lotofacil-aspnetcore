using LoteriaFacil.Application.Interfaces;
using LoteriaFacil.Application.ViewModels;
using LoteriaFacil.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace LoteriaFacil.UI.Web.Controllers
{
    public class ConfigurationController : BaseController
    {
        private readonly IConfigurationAppService _configurationAppService;

        public ConfigurationController(IConfigurationAppService configurationAppService,
                                       INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _configurationAppService = configurationAppService;
        }


        [HttpPost]
        [Route("/saveConfiguration")]
        public IActionResult Index([FromBody]object config)
        {
            ConfigurationViewModel configurationViewModel = JsonConvert.DeserializeObject<ConfigurationViewModel>(config.ToString());

            if (!ModelState.IsValid) return View(configurationViewModel);

            if (!configurationViewModel.Id.Equals(Guid.Empty))
                _configurationAppService.Update(configurationViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Atualizado com sucesso!";

            HttpContext.Response.StatusCode = 200;

            return View();
        }

        [HttpPost]
        [Route("/loadConfiguration")]
        public ObjectResult CarregaConfig()
        {
            return new ObjectResult(_configurationAppService.GetAll());
        }
    }
}