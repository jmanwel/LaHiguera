using Entidades.Models;
using Microsoft.AspNetCore.Mvc;
using Servicios;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MVC.Controllers
{
    public class GinecologiaController : Controller
    {
        private IGinecologiaService _ginecologiaService;
        private IPacienteService _pacienteService;

        public GinecologiaController(IGinecologiaService ginecologiaService, IPacienteService pacienteService)
        {
            _ginecologiaService = ginecologiaService;
            _pacienteService = pacienteService;

        }

        public ActionResult CreateGinecology(int id)
        {
            ViewBag.Paciente = _pacienteService.getPatient(id);
            return View();
        }

        [HttpPost]
        public ActionResult CreateGinecology(Ginecologia ginecologia)
        {
            try
            {
                _ginecologiaService.create(ginecologia);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            string redirect = "/Paciente/viewDetails/" + ginecologia.PacienteId;
            return Redirect(redirect);
        }

        public ActionResult editGinecology(int id)
        {
            ViewBag.Ginecologia = _ginecologiaService.getGinecology(id);
            ViewBag.Paciente = _pacienteService.getPatient((int)_ginecologiaService.getGinecology(id).PacienteId);
            return View();
        }

        [HttpPost]
        public ActionResult editGinecology(Ginecologia ginecologia)
        {
            try
            {
                _ginecologiaService.edit(ginecologia);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            string redirect = "/Paciente/viewDetails/" + ginecologia.PacienteId;
            return Redirect(redirect);
        }


    }
}
