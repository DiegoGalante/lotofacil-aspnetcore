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
        private readonly IPersonLotteryAppService _PersonLotteryAppService;

        public LotteryController(
            ILotteryAppService lotteryAppService,
            IPersonLotteryAppService PersonLotteryAppService,
            INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _lotteryAppService = lotteryAppService;
            _PersonLotteryAppService = PersonLotteryAppService;
        }

        [HttpGet]
        [Route("")]
        [Route("/")]
        [Route("/principal")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("/load/{concurse:int}")]
        public object Load(int concurse)
        {
            return _PersonLotteryAppService.GetJsonDashboard(concurse);
        }

        [HttpPost]
        [Route("/load")]
        public object Load()
        {
            return _PersonLotteryAppService.GetJsonDashboard();
        }

        [HttpPost]
        [Route("/loadGames")]
        public object LoadGames()
        {
            return _PersonLotteryAppService.GetPersonGame();
        }

        [HttpPost]
        [Route("/loadGames/{concurse:int}")]
        public object LoadGames(int concurse)
        {
            return _PersonLotteryAppService.GetPersonGame(concurse);
        }
    }
}