using Microsoft.AspNetCore.Mvc;
using System;

namespace Crud.App.WebSite.Controllers
{
    public class ErroController : Controller
    {
        [Route("/erro-de-aplicacao")]
        [Route("/erro-de-aplicacao/{id}")]
        public IActionResult Erros(string id)
        {
            switch (id)
            {
                case "404":
                    return View("NotFound");
                case "403":
                    return View("NotFound");
                default:
                    break;
            }
            throw new ArgumentException($"Não foi possível tratar o evento com Id: {id}");
        }
    }
}
