using LoteriaFacil.Application.Interfaces;
using LoteriaFacil.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace LoteriaFacil.UI.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class LotteryController : BaseController
    {
        private readonly ILotteryAppService _lotteryAppService;
        private readonly IPerson_LotteryAppService _person_lotteryAppService;

        public LotteryController(
            ILotteryAppService lotteryAppService,
            IPerson_LotteryAppService person_lotteryAppService,
            INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _lotteryAppService = lotteryAppService;
            _person_lotteryAppService = person_lotteryAppService;
        }

        [HttpGet]
        [Route("")]
        [Route("/")]
        [Route("/principal")]
        public IActionResult Index()
        {

            //_lotteryAppService.POPULAEBANCOPRIMEIROACESSO();

            return View();
        }

        [HttpPost]
        [Route("/load/{id:guid}")]
        public ObjectResult Load(Guid? id)
        {

            return null;
        }

        [HttpPost]
        [Route("/load")]
        public object Load()
        {
            return _person_lotteryAppService.GetJsonDashboard();
        }

        [HttpPost]
        [Route("/loadGames")]
        public object LoadGames()
        {
            return _person_lotteryAppService.GetPersonGame();
        }

        [HttpPost]
        [Route("/loadGames/{concurse:int}")]
        public object LoadGames(int concurse)
        {
            return _person_lotteryAppService.GetPersonGame(concurse);
        }
    }
}