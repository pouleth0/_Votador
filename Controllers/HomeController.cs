using AlterdataVotador.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AlterdataVotador.Controllers
{
    public class HomeController : Controller
    {
        /*pode ser utilizado diretament o Methodo diretamente ViewResult.. deixei um como exemplo e os outros para Interface padão:*/
        public ViewResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Projeto Termindo 13/12/2020.";
            ViewData["Email"] = "paulo@paulohendrix.com";

            return View();
        }
             [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
