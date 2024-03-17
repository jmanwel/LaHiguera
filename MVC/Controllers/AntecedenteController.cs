using Entidades.Models;
using Microsoft.AspNetCore.Mvc;
using Servicios;

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
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return Redirect("/Paciente/ListPatient");
        }


    }
}
