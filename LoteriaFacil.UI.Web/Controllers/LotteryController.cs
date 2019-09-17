using LoteriaFacil.Application.Interfaces;
using LoteriaFacil.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LoteriaFacil.UI.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class LotteryController : BaseController
    {
        private readonly ILotteryAppService _lotteryAppService;

        public LotteryController(
            ILotteryAppService lotteryAppService,
            INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _lotteryAppService = lotteryAppService;
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


    }
}