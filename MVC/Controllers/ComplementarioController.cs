using Entidades.Models;
using Microsoft.AspNetCore.Mvc;
using Servicios;

namespace MVC.Controllers
{
    public class ComplementarioController : Controller
    {
        private IComplementarioService _complementarioService;
        private IPacienteService _pacienteService;
        private IEstadoCivilService _estadoCivilService;
        private IEscolaridadService _escolaridadService;
        public ComplementarioController(IComplementarioService complementarioService, IPacienteService pacienteService, IEstadoCivilService estadoCivilService, IEscolaridadService escolaridadService)
        {
            _complementarioService = complementarioService;
            _pacienteService = pacienteService;
            _estadoCivilService = estadoCivilService;
            _escolaridadService = escolaridadService;
        }
        public ActionResult create(int id)
        {
            ViewBag.PacienteID = id;
            ViewBag.Paciente = _pacienteService.getPatient(id);
            ViewBag.EstadoCivil = _estadoCivilService.getAll();
            ViewBag.Escolaridad = _escolaridadService.getAll();
            return View();
        }

        public ActionResult editComplementary(int id)
        {
            ViewBag.Complementario = _complementarioService.getComplementaryData(id);
            var pid = _complementarioService.getComplementaryData(id)[0].PacienteId;
            var ecid = _complementarioService.getComplementaryData(id)[0].EstadoCivilId;
            var eid = _complementarioService.getComplementaryData(id)[0].EscolaridadId;
            ViewBag.Paciente = _pacienteService.getPatient(Convert.ToInt32(pid));
            ViewBag.EstadoCivil = _estadoCivilService.getById(Convert.ToInt32(ecid));
            ViewBag.EstadoCivilFiltered = _estadoCivilService.getAllButId(Convert.ToInt32(ecid));
            ViewBag.Escolaridad = _escolaridadService.getById(Convert.ToInt32(ecid));
            ViewBag.EscolaridadFiltered = _escolaridadService.getAllButId(Convert.ToInt32(eid));
            return View();
        }
        
        [HttpPost]
        public ActionResult editComplementary(Complementario complementario)
        {
            try
            {                
                _complementarioService.editComplementary(complementario);
                Console.WriteLine("Registro modificado OK!");
                string redirect = "/Paciente/viewDetails/" + complementario.PacienteId;
                return Redirect(redirect);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.ToString());
                return Redirect("/Home/Error");
            }

        }

        [HttpPost]
        public ActionResult create(Complementario complementario)
        {
            try
            {
                if (_complementarioService.getComplementaryData(Convert.ToInt32(complementario.PacienteId)).Count() == 0)
                {                    
                    _complementarioService.create(complementario);
                    Console.WriteLine("Registro creado OK!");
                }
                else
                {
                    Console.WriteLine("Paciente ya posee datos complementarios");
                }
                string redirect = "/Paciente/viewDetails/" + complementario.PacienteId;
                return Redirect(redirect);
            }
            catch (Exception e)
            {
                    Console.WriteLine("Error " + e.ToString());
                    return Redirect("/Home/Error");

            }

        }
    }
}
