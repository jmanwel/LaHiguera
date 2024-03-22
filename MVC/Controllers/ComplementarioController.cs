﻿using Entidades.Models;
using Microsoft.AspNetCore.Mvc;
using Servicios;

namespace MVC.Controllers
{
    public class ComplementarioController : Controller
    {
        private IComplementarioService _complementarioService;
        public ComplementarioController(IComplementarioService complementarioService)
        {
            _complementarioService = complementarioService;
        }
        public ActionResult create(int id)
        {
            ViewBag.PacienteID = id;
            return View();
        }

        [HttpPost]
        public ActionResult create(Complementario complementario)
        {
            try
            {
                if (!_complementarioService.hasComplementary(Convert.ToInt32(complementario.PacienteId)))
                {
                    _complementarioService.create(complementario);
                    Console.WriteLine("Registro creado OK!");
                }
                else
                {
                    Console.WriteLine("Paciente ya posee datos complementarios");
                }
            }
            catch (Exception e)
            {
                    Console.WriteLine("Error " + e);
            }
            string redirect = "/Paciente/viewDetails/" + complementario.PacienteId;
            return Redirect(redirect);
        }
    }
}
