﻿using Entidades.Models;

namespace Servicios
{
    public class PacienteService: IPacienteService
    {
        public LahigueraContext _ctxt { get; set; }
        public PacienteService(LahigueraContext ctx) { 
        
            _ctxt = ctx;
        }

        public List<Paciente> getAllPatients() { 
            // This Method returns all patients active
            // return _ctxt.Pacientes.Where(o => o.FlgActivo == 1).ToList();
            return _ctxt.Pacientes.ToList();
        }

        public List<Paciente> getAllInactivePatients() { 
            // This Method returns all patients active
            return _ctxt.Pacientes.Where(o => o.FlgActivo == 0).ToList();
        }

        public void create(Paciente paciente)
        {
            //This method persists Patients objects in DDBB            
            if (_ctxt.Pacientes.Where(o => o.Dni == paciente.Dni) == null || paciente.Dni == null)
            {
                if (paciente.ParajeAtencion != null)
                {
                    paciente.ParajeAtencion = paciente.ParajeAtencion.ToUpper().Replace(" ", "");
                }
                _ctxt.Pacientes.Add(paciente);
                _ctxt.SaveChanges();
            }
            else
            {
                Console.WriteLine("Paciente ya existe");
            }          
        }

        public void setActivate(int id_patient)
        {
            //This method set the field FlgActivo to 1
            var activate_patient = _ctxt.Pacientes.Find(id_patient);
            if (activate_patient is null)
            {
                Console.WriteLine("Patient not found");
            }
            else
            {
                activate_patient.FlgActivo = 1;
                _ctxt.SaveChanges();
            }
            
        }

        public void setDeactivate(int id_patient)
        {
            //This method set the field FlgActivo to 0
            var deactivate_patient = _ctxt.Pacientes.Find(id_patient);
            if (deactivate_patient is null)
            {
                Console.WriteLine("Patient not found");
            }
            else
            {
                deactivate_patient.FlgActivo = 0;
                _ctxt.SaveChanges();
            }
            
        }
        public Paciente getPatient(int id_patient)
        {
            //This method returns a object patient (by the id field)
            return _ctxt.Pacientes.Find(id_patient);
        }
        public void editPatient(Paciente paciente)
        {
            //This method updates Patients objects in DDBB
            var updated_patient = _ctxt.Pacientes.Find(paciente.Id);
            if (updated_patient is null) { Console.WriteLine("Paciente no encontrado"); }
            else
            {
                updated_patient.Nombre = paciente.Nombre;
                updated_patient.Apellido = paciente.Apellido;
                updated_patient.Sexo = paciente.Sexo;
                updated_patient.FlgActivo = paciente.FlgActivo;
                updated_patient.FechaNac = paciente.FechaNac;
                updated_patient.FechaAlta = paciente.FechaAlta;
                if (paciente.ParajeAtencion != null)
                {
                    updated_patient.ParajeAtencion = paciente.ParajeAtencion.ToUpper().Replace(" ", "");
                }
                updated_patient.Dni = paciente.Dni;
                _ctxt.SaveChanges();
            }
            _ctxt.SaveChanges();
        }

    }
}
