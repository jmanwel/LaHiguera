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

        [HttpPost]
        public ActionResult CreateHistory(Historia history)
        {
            try
            {
                _historiaService.create(history);
                string redirect = "/Paciente/viewDetails/" + history.PacienteId;
                return Redirect(redirect);
            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());
                return Redirect("/Home/Error");
            }

        }

        public ActionResult editHistory(int id)
        {
            ViewBag.Paciente = _pacienteService.getPatient((int)_historiaService.getHistory(id).PacienteId);
            ViewBag.Historia = _historiaService.getHistory(id);
            return View();
        }

        [HttpPost]
        public ActionResult editHistory(Historia history)
        {
            _historiaService.edit(history);
            string redirect = "/Paciente/viewDetails/" + history.PacienteId;
            return Redirect(redirect);
        }
    }
}
