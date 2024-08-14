using Entidades.Models;
using Microsoft.AspNetCore.Mvc;
using Servicios;
using System.Dynamic;

namespace MVC.Controllers
{
    public class PacienteController : Controller
    {
        private IPacienteService _pacienteService;
        private IAntecedenteService _antecedenteService;
        private IComplementarioService _complementarioService;
        private IConsultaService _consultaService;
        private IHistoriaService _historiaService;
        private IPediatriaService _pediatriaService;
        private IGinecologiaService _ginecologiaService;
        public PacienteController(IPacienteService pacienteService, IAntecedenteService antecedenteService, IComplementarioService complementarioService, IConsultaService consultaService, IHistoriaService historiaService, IPediatriaService pediatriaService, IGinecologiaService ginecologiaService)
        {
            _pacienteService = pacienteService;
            _antecedenteService = antecedenteService;
            _complementarioService = complementarioService;
            _consultaService = consultaService;
            _historiaService = historiaService;
            _pediatriaService = pediatriaService;
            _ginecologiaService = ginecologiaService;
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
                return Redirect("/Paciente/ListPatient");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return Redirect("/Home/Error");
            }
        }

        public ActionResult ListPatient()
        {
            ViewBag.Pacientes = _pacienteService.getAllPatients();
            return View();
        }

        public ActionResult ListInactivePatient()
        {
            ViewBag.Pacientes = _pacienteService.getAllInactivePatients();
            return View();
        }

        public ActionResult setActivate(int id)
        {
            _pacienteService.setActivate(id);
            return Redirect("/Paciente/ListPatient");
        }

        public ActionResult setDeactivate(int id)
        {
            _pacienteService.setDeactivate(id);
            return Redirect("/Paciente/ListPatient");
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

        public ActionResult viewDetails(int id)
        {
            ViewBag.Paciente = _pacienteService.getPatient(id);
            ViewBag.Disable = "";
            if(ViewBag.Paciente.FlgActivo == 0){
                ViewBag.Disable = "disabled";
            }
            ViewBag.Antecedente = _antecedenteService.getAllAntecedentForAPatient(id);
            ViewBag.Complementario = _complementarioService.getComplementaryData(id);
            ViewBag.Consulta = _consultaService.getAllConsultationFromIdPatient(id);
            ViewBag.Historia = _historiaService.getAllHistoryForAPatient(id);
            ViewBag.Pediatria = _pediatriaService.getAllPediatryForAPatient(id);
            ViewBag.Ginecologia = _ginecologiaService.getAllGinecologyForAPatient(id);
            return View();
        }

        public ActionResult ExportDataToPdf(int id)
        {

            dynamic patient = this.getPatientInformation(id);

            var response = PacientePdfService.GeneratePdfHistory(patient);

            string fileName = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-historia-clinica-paciente-" + patient.information.Apellido + "-" + patient.information.Nombre + ".pdf";
            
            return File(response, "application/pdf", fileName);
        }

        private dynamic getPatientInformation(int patientId)
        {
            dynamic patient = new ExpandoObject();

            var complementary = _complementarioService.getComplementaryData(patientId);

            patient.information = _pacienteService.getPatient(patientId);
            patient.complementary = complementary.Count > 0 ? complementary.Last(): null;
            patient.consultations = _consultaService.getAllConsultationFromIdPatient(patientId);
            patient.history = _historiaService.getAllHistoryForAPatient(patientId);
            patient.background = _antecedenteService.getAllAntecedentForAPatient(patientId);
            patient.ginecology = _ginecologiaService.getAllGinecologyForAPatient(patientId);
            patient.pediatry = _pediatriaService.getAllPediatryForAPatient(patientId);

            return patient;

        }
    }
}
