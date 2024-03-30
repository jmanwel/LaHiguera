using Entidades.Models;
using Microsoft.AspNetCore.Mvc;
using Servicios;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MVC.Controllers
{
    public class GinecologiaController : Controller
    {
        private IGinecologiaService _ginecologiaService;
        private IPacienteService _pacienteService;

        public GinecologiaController(IGinecologiaService ginecologiaService, IPacienteService pacienteService)
        {
            _ginecologiaService = ginecologiaService;
            _pacienteService = pacienteService;

        }

        public ActionResult CreateGinecology(int id)
        {
            ViewBag.Paciente = _pacienteService.getPatient(id);
            return View();
        }



    }
}
