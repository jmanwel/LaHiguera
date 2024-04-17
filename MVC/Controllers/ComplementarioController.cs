using Entidades.Models;
using Microsoft.AspNetCore.Mvc;
using Servicios;

namespace MVC.Controllers
{
    public class ComplementarioController : Controller
    {
        private IComplementarioService _complementarioService;
        private IPacienteService _pacienteService;
        public ComplementarioController(IComplementarioService complementarioService, IPacienteService pacienteService)
        {
            _complementarioService = complementarioService;
            _pacienteService = pacienteService;
        }
        public ActionResult create(int id)
        {
            ViewBag.PacienteID = id;
            ViewBag.Paciente = _pacienteService.getPatient(id);
            return View();
        }

        public ActionResult editComplementary(int id)
        {
            ViewBag.Complementario = _complementarioService.getComplementaryData(id);
            var pid = _complementarioService.getComplementaryData(id)[0].PacienteId;
            ViewBag.Paciente = _pacienteService.getPatient(Convert.ToInt32(pid));
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
