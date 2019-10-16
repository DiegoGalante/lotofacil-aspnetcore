using LoteriaFacil.Application.Interfaces;
using LoteriaFacil.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Load(int concurse)
        {
            return new ObjectResult(await _PersonLotteryAppService.GetJsonDashboard(concurse));
        }

        [HttpPost]
        [Route("/load")]
        public async Task<IActionResult> Load()
        {
            return new ObjectResult(await _PersonLotteryAppService.GetJsonDashboard());
        }

        [HttpPost]
        [Route("/loadGames")]
        public async Task<IActionResult> LoadGames()
        {
            return new ObjectResult(await _PersonLotteryAppService.GetPersonGame());
        }

        [HttpPost]
        [Route("/loadGames/{concurse:int}")]
        public async Task<IActionResult> LoadGames(int concurse)
        {
            return new ObjectResult(await _PersonLotteryAppService.GetPersonGame(concurse));
        }


        [HttpPost]
        [Route("/sendEmail")]
        public IActionResult SendEmail()
        {
            return new ObjectResult(_PersonLotteryAppService.SendEmail());
        }

        [HttpPost]
        [Route("/sendEmail/{concurse:int}")]
        public IActionResult SendEmail(int concurse)
        {
            return new ObjectResult(_PersonLotteryAppService.SendEmail(concurse));
        }
    }
}