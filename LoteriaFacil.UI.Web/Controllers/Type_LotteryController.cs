using LoteriaFacil.Application.Interfaces;
using LoteriaFacil.Application.ViewModels;
using LoteriaFacil.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace LoteriaFacil.UI.Web.Controllers
{
    public class Type_LotteryController : BaseController
    {
        private readonly IType_LotteryAppService _type_LotteryAppService;

        public Type_LotteryController(IType_LotteryAppService type_LotteryAppService,
                                      INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _type_LotteryAppService = type_LotteryAppService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("/saveTypeLottery")]
        public IActionResult Index([FromBody]object type_Lottery)
        {
            Type_LotteryViewModel type_LotteryViewModel = JsonConvert.DeserializeObject<Type_LotteryViewModel>(type_Lottery.ToString());

            if (!ModelState.IsValid) return View(type_LotteryViewModel);

            if (!type_LotteryViewModel.Id.Equals(Guid.Empty))
                _type_LotteryAppService.Update(type_LotteryViewModel);
            else
                _type_LotteryAppService.Register(type_LotteryViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Atualizado com sucesso!";

            return View();
        }

        [HttpPost]
        [Route("/loadTypeLottery/list-all")]
        public ObjectResult CarregaConfig()
        {
            return new ObjectResult(_type_LotteryAppService.GetAll());
        }

        [HttpPost]
        [Route("/loadTypeLottery/{id:guid}")]
        public ObjectResult CarregaConfig(Guid? id)
        {
            if (!id.Equals(Guid.Empty))
                return new ObjectResult(_type_LotteryAppService.GetById((Guid)id));
            else
                return null;
        }
    }
}