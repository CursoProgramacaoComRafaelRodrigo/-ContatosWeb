using _ContatosWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;

namespace _ContatosWeb.Controllers
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
            ContatoModels contatosModels = new ContatoModels();

            return View(contatosModels);
        }
        public IActionResult Novo(string nome, string telefone, string email)
        {
            if (!string.IsNullOrEmpty(nome) && !string.IsNullOrEmpty(telefone) && !string.IsNullOrEmpty(email))
            {
                Contatos c = new Contatos();
                c.Nome = nome;
                c.Telefone = telefone;
                c.Email = email;

                ContatoModels cm = new ContatoModels();
                TempData["res"] = cm.NovoContato(c);

                return View("Index", cm);
            }
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
    }
}
