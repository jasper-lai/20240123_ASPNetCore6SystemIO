namespace ASPNetCore6SystemIO.Controllers
{
    using ASPNetCore6SystemIO.Services;
    using ASPNetCore6SystemIO.Wrapper;
    using Microsoft.AspNetCore.Mvc;

    public class LottoController : Controller
    {
        private readonly ILottoService _lottoService;

        public LottoController(ILottoService lottoService)
        {
            _lottoService = lottoService;
        }

        public IActionResult Index()
        {
            var result = _lottoService.Lottoing(0, 10);
            return View(result);
        }
    }
}
