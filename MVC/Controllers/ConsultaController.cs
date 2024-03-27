using Entidades.Models;
using Microsoft.AspNetCore.Mvc;
using Servicios;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MVC.Controllers
{
    public class ConsultaController : Controller
    {
        private IConsultaService _consultaService;
        private IPacienteService _pacienteService;

        public ConsultaController(IConsultaService consultaService, IPacienteService pacienteService)
        {
            _consultaService = consultaService;
            _pacienteService = pacienteService;
        }
        public ActionResult CreateConsultation(int id)
        {
            ViewBag.Paciente = _pacienteService.getPatient(id);
            return View();
        }

        [HttpPost]
        public ActionResult CreateConsultation(Consulta consulta)
        {
            _consultaService.create(consulta);
            string redirect = "/Paciente/viewDetails/" + consulta.PacienteId;
            return Redirect(redirect);
        }

        public ActionResult viewConsultation(int id)
        {
            ViewBag.Consulta = _consultaService.getConsultation(id);
            ViewBag.Paciente = _pacienteService.getPatient((int)_consultaService.getConsultation(id).PacienteId);
            return View();
        }

        public ActionResult editConsultation(int id)
        {
            ViewBag.Consulta = _consultaService.getConsultation(id);
            ViewBag.Paciente = _pacienteService.getPatient((int)_consultaService.getConsultation(id).PacienteId);
            return View();
        }
    }
}
