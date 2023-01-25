using Microsoft.AspNetCore.Mvc;
using Portafolio.Models;
using System.Diagnostics;

namespace Portafolio.Controllers
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
            var proyectos = ObtenerProyectos().Take(3).ToList();
            var modelo = new HomeIndexViewModel() { Proyectos= proyectos };
            return View(modelo);
        }

        private List<Proyecto> ObtenerProyectos()
        {
            return new List<Proyecto>()
            {
                new Proyecto
                {

                Titulo = "Amazon",
                Descripcion = "ejemplo1",
                Link = "https://amazon.com",
                ImagenURL = "/img/lobo the witcher.jpg"
                },
                new Proyecto
                {

                Titulo = "Amazon",
                Descripcion = "ejemplo2",
                Link = "https://amazon.com",
                ImagenURL = "/img/lobo the witcher.jpg"
                },
                new Proyecto
                {

                Titulo = "Amazon",
                Descripcion = "ejemplo3",
                Link = "https://amazon.com",
                ImagenURL = "/img/lobo the witcher.jpg"
                },
                new Proyecto
                {

                Titulo = "Amazon",
                Descripcion = "ejemplo4",
                Link = "https://amazon.com",
                ImagenURL = "/img/lobo the witcher.jpg"
                }
            };
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