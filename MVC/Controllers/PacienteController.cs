using Entidades.Models;
using Microsoft.AspNetCore.Mvc;
using Servicios;

namespace MVC.Controllers
{
    public class PacienteController : Controller
    {
        private IPacienteService _pacienteService;
        private IAntecedenteService _antecedenteService;
        private IComplementarioService _complementarioService;
        private IConsultaService _consultaService;
        private IHistoriaService _historiaService;
        public PacienteController(IPacienteService pacienteService, IAntecedenteService antecedenteService, IComplementarioService complementarioService, IConsultaService consultaService, IHistoriaService historiaService)
        {
            _pacienteService = pacienteService;
            _antecedenteService = antecedenteService;
            _complementarioService = complementarioService;
            _consultaService = consultaService;
            _historiaService = historiaService;
        }
        public ActionResult CreatePatient()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CreatePatient(Paciente paciente)
        {
            try
            {
                _pacienteService.create(paciente);
                return View();
            }
            catch (Exception e)
            {
                return View();
            }
        }

        public ActionResult ListPatient()
        {
            ViewBag.Pacientes = _pacienteService.getAllPatients();
            return View();
        }

        public ActionResult setDeactivate(int id)
        {
            _pacienteService.setDeactivate(id);
            return Redirect("/Paciente/ListPatient");
        }

        public ActionResult createConsultation(Paciente paciente)
        {
            return View();
        }

        public ActionResult editPatient(int id)
        {
            ViewBag.Paciente = _pacienteService.getPatient(id);
            return View();
        }

        [HttpPost]
        public ActionResult editPatient(Paciente paciente)
        {
            _pacienteService.editPatient(paciente);
            string redirect = "/Paciente/viewDetails/" + paciente.Id;
            return Redirect(redirect);
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        public ActionResult viewDetails(int id)
        {
            ViewBag.Paciente = _pacienteService.getPatient(id);
            ViewBag.Antecedente = _antecedenteService.getAllAntecedentForAPatient(id);
            ViewBag.Complementario = _complementarioService.getComplementaryData(id);
            ViewBag.Consulta = _consultaService.getAllConsultationFromIdPatient(id);
            ViewBag.Historia = _historiaService.getAllHistoryForAPatient(id);
            return View();
        }

    }
}
