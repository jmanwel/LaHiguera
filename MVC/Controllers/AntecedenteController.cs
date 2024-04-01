using Entidades.Models;
using Microsoft.AspNetCore.Mvc;
using Servicios;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MVC.Controllers
{
    public class AntecedenteController : Controller
    {
        private IAntecedenteService _antecedenteService;
        private IPacienteService _pacienteService;

        public AntecedenteController(IAntecedenteService antecedenteService, IPacienteService pacienteService)
        {
            _antecedenteService = antecedenteService;
            _pacienteService = pacienteService;

        }
        public ActionResult CreateAntecedent(int id)
        {
            ViewBag.Paciente = _pacienteService.getPatient(id);
            return View();
        }


        [HttpPost]
        public ActionResult CreateAntecedent(Antecedente antecedente)
        {
            try
            {
                _antecedenteService.create(antecedente);
                string redirect = "/Paciente/viewDetails/" + antecedente.PacienteId;
                return Redirect(redirect);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return Redirect("/Home/Error");
            }

        }

        public ActionResult viewAntecedent(int id)
        {
            ViewBag.Antecedente = _antecedenteService.getAntecedent(id);
            return View();
        }

        public ActionResult editAntecedent(int id)
        {
            try
            {
                ViewBag.Paciente = _pacienteService.getPatient((int)_antecedenteService.getAntecedent(id).PacienteId);
                ViewBag.Antecedente = _antecedenteService.getAntecedent(id);
                return View();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return Redirect("/Home/Error");
            }
        }

        [HttpPost]
        public ActionResult editAntecedent(Antecedente antecedente)
        {
            try
            {
                _antecedenteService.editAntecedent(antecedente);
                string redirect = "/Paciente/viewDetails/" + antecedente.PacienteId;
                return Redirect(redirect);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return Redirect("/Home/Error");
            }

        }

        public ActionResult deleteAntecedent(int id)
        {
            ViewBag.Antecedente = _antecedenteService.getAntecedent(id);
            return View();
        }

    }
}
