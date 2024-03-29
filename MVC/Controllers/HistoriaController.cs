using Entidades.Models;
using Microsoft.AspNetCore.Mvc;
using Servicios;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MVC.Controllers
{
    public class HistoriaController : Controller
    {
        private IHistoriaService _historiaService;
        private IPacienteService _pacienteService;

        public HistoriaController(IHistoriaService historiaService, IPacienteService pacienteService)
        {
            _historiaService = historiaService;
            _pacienteService = pacienteService;

        }
        public ActionResult CreateHistory(int id)
        {
            ViewBag.Paciente = _pacienteService.getPatient(id);
            return View();
        }
    }
}
