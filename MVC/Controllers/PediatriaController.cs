using Entidades.Models;
using Microsoft.AspNetCore.Mvc;
using Servicios;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MVC.Controllers
{
    public class PediatriaController : Controller
    {
        private IPediatriaService _pediatriaService;
        private IPacienteService _pacienteService;

        public PediatriaController(IPediatriaService pediatriaService, IPacienteService pacienteService)
        {
            _pediatriaService = pediatriaService;
            _pacienteService = pacienteService;

        }

        public ActionResult CreatePediatry(int id)
        {
            ViewBag.Paciente = _pacienteService.getPatient(id);
            return View();
        }

        [HttpPost]
        public ActionResult CreatePediatry(Pediatria pediatria)
        {
            try
            {
                _pediatriaService.create(pediatria);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            string redirect = "/Paciente/viewDetails/" + pediatria.PacienteId;
            return Redirect(redirect);
        }

        public ActionResult editPediatry(int id)
        {
            ViewBag.Pediatria = _pediatriaService.getPediatryForAPatient(id);
            ViewBag.Paciente = _pacienteService.getPatient(ViewBag.Pediatria.PacienteId);
            return View();
        }

        [HttpPost]
        public ActionResult editPediatry(Pediatria pediatria)
        {
            try
            {
                _pediatriaService.edit(pediatria);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            string redirect = "/Paciente/viewDetails/" + pediatria.PacienteId;
            return Redirect(redirect);
        }


    }
}
