using ConversorMetro.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ConversorMetro.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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

        public IActionResult Converter(float valorMetros, int conversao)
        {
            ViewBag.valorMetros = valorMetros;
            ViewBag.conversao = conversao;
            float resultado;
            switch (conversao)
            {
                case 0:
                    resultado = valorMetros * 100;
                    break;
                case 1:
                    resultado = valorMetros * 1000;
                    break;
                case 2:
                    resultado = valorMetros / 1000;
                    break;
                case 3:
                    resultado = valorMetros * 3.281f;
                    break;
                case 4:
                    resultado = valorMetros * 0.000621371f;
                    break;

                default:
                    resultado = 0;
                    break;
            }
            return View("index", resultado);

        }
    }
}
