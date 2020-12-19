using Microsoft.AspNetCore.Mvc;
using AlterdataVotador.Services;

namespace AlterdataVotador.Controllers
{
    public class OpenHomeController : Controller
    {
        //Instanciando aenas o caminho da Seleção de serviços
        private readonly SelecaoServicos _services;

        public OpenHomeController(SelecaoServicos selecaoServicos)
        {
            _services = selecaoServicos;
        }
        // fim do instanciamento
        public IActionResult Index()
        {
            //aplicando a dinamica do MVC. par entregar na tela de Index a lista de Serviços levando assim o Index já pré poluado com dados a serem usados
            var list = _services.FindAll();
            return View(list);
        }

      
    }
}
