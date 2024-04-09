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

    }
}
