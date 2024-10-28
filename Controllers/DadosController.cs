using Microsoft.AspNetCore.Mvc;

namespace TrabalhoAspNet.Controllers;

public class DadosController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}