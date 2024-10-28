using Microsoft.AspNetCore.Mvc;

namespace TrabalhoAspNet.Controllers;

public class ConsultasController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}