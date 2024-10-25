using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TronGenerateWallet.Models;
using TronGenerateWallet.Services;

namespace TronGenerateWallet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TronWalletGenerateService _tronWalletGenerateService;
        public HomeController(ILogger<HomeController> logger, TronWalletGenerateService tronWalletGenerateService)
        {
            _tronWalletGenerateService = tronWalletGenerateService;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GenerateWallet()
        {
            var walletInfo = await _tronWalletGenerateService.GenerateTronWalletAsync();
            return Content(walletInfo);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
