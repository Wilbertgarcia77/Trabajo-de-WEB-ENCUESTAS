using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using encuestasgym.Models;

namespace encuestasgym.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

        public IActionResult Index()
        {
            if (TempData["UsuarioId"] == null)
            {
                // Redirigir a login si no está autenticado
                return RedirectToAction("Login", "Account");
            }
            string? nombre = TempData["NombreUsuario"] as string;
            ViewBag.NombreUsuario = nombre ?? "Usuario";
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
