using LoteriaFacil.Application.Interfaces;
using LoteriaFacil.Application.ViewModels;
using LoteriaFacil.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace LoteriaFacil.UI.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class TypeLotteryController : BaseController
    {
        private readonly ITypeLotteryAppService _TypeLotteryAppService;

        public TypeLotteryController(ITypeLotteryAppService TypeLotteryAppService,
                                      INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _TypeLotteryAppService = TypeLotteryAppService;
        }

        [HttpGet]
        [Route("/tpl")]
        public IActionResult Index()
        {
           return View();
        }

        [HttpPost]
        [Route("/saveTypeLottery")]
        public IActionResult Index([FromBody]object TypeLottery)
        {
            TypeLotteryViewModel TypeLotteryViewModel = JsonConvert.DeserializeObject<TypeLotteryViewModel>(TypeLottery.ToString());

            if (!ModelState.IsValid) return View(TypeLotteryViewModel);

            if (!TypeLotteryViewModel.Id.Equals(Guid.Empty))
                _TypeLotteryAppService.Update(TypeLotteryViewModel);
            else
                _TypeLotteryAppService.Register(TypeLotteryViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Atualizado com sucesso!";

            return View();
        }

        [HttpPost]
        [Route("/loadTypeLottery/list-all")]
        public ObjectResult CarregaConfig()
        {
            return new ObjectResult(_TypeLotteryAppService.GetAll());
        }

        [HttpPost]
        [Route("/loadTypeLottery/{id:guid}")]
        public ObjectResult CarregaConfig(Guid? id)
        {
            if (!id.Equals(Guid.Empty))
                return new ObjectResult(_TypeLotteryAppService.GetById((Guid)id));
            else
                return null;
        }
    }
}