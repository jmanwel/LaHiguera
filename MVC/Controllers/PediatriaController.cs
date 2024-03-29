using Entidades.Models;
using Microsoft.AspNetCore.Mvc;
using Servicios;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MVC.Controllers
{
    public class PediatriaController : Controller
    {
        private IPediatriaService _pediatriaService;
        private IPacienteService _pacienteService;

        public PediatriaController(IPediatriaService pediatriaService, IPacienteService pacienteService)
        {
            _pediatriaService = pediatriaService;
            _pacienteService = pacienteService;

        }

        public ActionResult CreatePediatry()
        {
            return View();
        }


    }
}
