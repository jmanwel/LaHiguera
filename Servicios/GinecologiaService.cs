﻿using Entidades.Models;

namespace Servicios
{
    public class GinecologiaService : IGinecologiaService
    {
        public LahigueraContext _ctxt { get; set; }
        public GinecologiaService(LahigueraContext ctx) { 
        
            _ctxt = ctx;
        }

        public void create(Ginecologia ginecologia)
        {
            //This method persists Ginecology objects in DDBB
            ginecologia.FechaCreacion = DateTime.Today;
            _ctxt.Ginecologia.Add(ginecologia);
            _ctxt.SaveChanges();
        }

        public List<Ginecologia> getAllGinecologyForAPatient(int id_patient)
        {
            // This Method returns all ginecology for a patient
            return _ctxt.Ginecologia.Where(o => o.PacienteId == id_patient).OrderByDescending(o => o.FechaCreacion).ToList();
        }

        public Ginecologia getGinecology(int id)
        {
            // This Method returns a ginecology object
            return _ctxt.Ginecologia.Find(id);
        }

        public void edit(Ginecologia ginecologia)
        {
            //This method updates Pediatry objects in DDBB
            var ginecologia_updated = _ctxt.Ginecologia.Find(ginecologia.Id);
            if (ginecologia_updated == null)
            {
                Console.WriteLine("Registro no encontrado!");
            }
            else
            {
                ginecologia_updated.PacienteId = ginecologia.PacienteId;
                ginecologia_updated.Gestas = ginecologia.Gestas;
                ginecologia_updated.Para = ginecologia.Para;
                ginecologia_updated.Cesareas = ginecologia.Cesareas;
                ginecologia_updated.Abortos = ginecologia.Abortos;
                ginecologia_updated.Irs = ginecologia.Irs;
                ginecologia_updated.Menarca = ginecologia.Menarca;
                ginecologia_updated.RitmoMenst = ginecologia.RitmoMenst;
                ginecologia_updated.Menopausia = ginecologia.Menopausia;
                ginecologia_updated.TomaPap = ginecologia.TomaPap;
                ginecologia_updated.ResultadoPap = ginecologia.ResultadoPap;
                ginecologia_updated.Colposcopia = ginecologia.Colposcopia;
                ginecologia_updated.EstudiosComp = ginecologia.EstudiosComp;
                _ctxt.SaveChanges();
            }
        }

    }
}