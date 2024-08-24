using Entidades.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using PdfSharp.Snippets;
using Servicios;
using System.Dynamic;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MVC.Controllers
{
    public class PacienteController : Controller
    {
        private IPacienteService _pacienteService;
        private IAntecedenteService _antecedenteService;
        private IComplementarioService _complementarioService;
        private IConsultaService _consultaService;
        private IEstadoCivilService _estadoCivilService;
        private IEscolaridadService _escolaridadService;
        private IEtniaService _etniaService;
        
        public PacienteController(IPacienteService pacienteService, IAntecedenteService antecedenteService, IComplementarioService complementarioService, IConsultaService consultaService, IEstadoCivilService estadoCivilService, IEscolaridadService escolaridadService, IEtniaService etniaService)
        {
            _pacienteService = pacienteService;
            _antecedenteService = antecedenteService;
            _complementarioService = complementarioService;
            _consultaService = consultaService;
            _estadoCivilService = estadoCivilService;
            _escolaridadService = escolaridadService;
            _etniaService = etniaService;
        }
        public ActionResult CreatePatient()
        {
            ViewBag.Etnia = _etniaService.getAll();
            return View();
        }


        [HttpPost]
        public ActionResult CreatePatient(Paciente paciente)
        {
            try
            {
                var result = _pacienteService.create(paciente);
                if (result == 0)
                {
                    TempData["msg"] = "Paciente creado OK";
                    return Redirect("/Paciente/ListPatient");
                }
                else
                {
                    ViewBag.msg = "Ya existe un paciente registrado con ese DNI";
                    ViewBag.Etnia = _etniaService.getAll();
                    return View();
                }
                //return Redirect("/Paciente/ListPatient");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                TempData["error"] = e.ToString();
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
            ViewBag.Etnia = _etniaService.getById(Convert.ToInt32(_pacienteService.getPatient(id).EtniaId));
            ViewBag.EtniaFiltered = _etniaService.getAllButId(Convert.ToInt32(_pacienteService.getPatient(id).EtniaId));
            return View();
        }

        [HttpPost]
        public ActionResult editPatient(Paciente paciente)
        {
            TempData["msg"] = "Paciente editado OK";
            if (_pacienteService.checkPatient(paciente.Dni) != false)
            {            
                TempData["msg"] = "Paciente editado OK, excepto el DNI -ya existe en la base de datos-";
            }
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
            ViewBag.Etnia = _etniaService.getById(Convert.ToInt32(_pacienteService.getPatient(id).EtniaId));
            if (ViewBag.Complementario != null)
            {                
                ViewBag.EstadoCivil = ViewBag.Complementario.EstadoCivilId != null ? _estadoCivilService.getById(ViewBag.Complementario.EstadoCivilId) : null;
                ViewBag.Escolaridad = ViewBag.Complementario.EscolaridadId != null ? _escolaridadService.getById(ViewBag.Complementario.EscolaridadId): null;
            }

            return View();
        }

        public ActionResult ExportDataToPdf(int id)
        {

            Paciente patient = _pacienteService.getPatient(id);

            byte[] response = PacientePdfService.GeneratePdfHistory(patient);

            string fileName = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-historia-clinica-paciente-" + patient.Apellido + "-" + patient.Nombre + ".pdf";
            
            return File(response, "application/pdf", fileName);
        }

    }
}
