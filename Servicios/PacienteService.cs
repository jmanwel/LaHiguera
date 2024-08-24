using Entidades.Models;
using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;

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

        public int create(Paciente paciente)
        {
            //Creo una variable para saber si debo guardar o no un paciente, por defecto en false
            bool guardaPaciente = false;

            //Chequeo si el dni es null
            if(paciente.Dni != null) 
            {
                //No es núlo ovacio así que chequeo que el dni no este duplicado
                bool existePaciente = _ctxt.Pacientes.Any(o => o.Dni == paciente.Dni);

                if (!existePaciente)
                {
                    // No hay dni duplicado, guardo el paciente
                    guardaPaciente = true;
                }

            }else{
                //Si el dni es nulo, guardo el paciente
                guardaPaciente = true;
            }

            if (guardaPaciente)
            {
                if (paciente.ParajeAtencion != null)
                {
                    paciente.ParajeAtencion = paciente.ParajeAtencion.ToUpper();
                }
                //Paso a uppercase los campos de texto antes de guardarlo
                paciente.Nombre = paciente.Nombre.ToUpper();
                paciente.Apellido = paciente.Apellido.ToUpper();
                paciente.Sexo = paciente.Sexo.ToUpper();
                paciente.LugarNac = paciente.LugarNac?.ToUpper() ?? "";
                paciente.FechaCreacion = DateTime.Now;
                paciente.LastUpdate = DateTime.Now;
                //Create an uniq Id based on: nombre, apellido, DNI y fecha de nacimiento
                string string_to_hash = paciente.Nombre + paciente.Apellido + paciente.FechaNac + paciente.Dni;
                SHA512 sha512 = SHA512.Create();
                byte[] bytes = Encoding.UTF8.GetBytes(string_to_hash);
                byte[] hash = sha512.ComputeHash(bytes);
                int hashed_id = BitConverter.ToInt32(hash, 0);
                if (hashed_id < 0)
                {
                    hashed_id = hashed_id * -1;
                }
                paciente.Id = hashed_id;
                _ctxt.Pacientes.Add(paciente);
                _ctxt.SaveChanges();
                return 0;
            }
            else
            {
                Console.WriteLine("Paciente ya existe");
                return 1;
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
                activate_patient.LastUpdate = DateTime.Now;
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
                deactivate_patient.LastUpdate = DateTime.Now;
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
                updated_patient.Nombre = paciente.Nombre.ToUpper();
                updated_patient.Apellido = paciente.Apellido.ToUpper();
                updated_patient.Sexo = paciente.Sexo.ToUpper();
                updated_patient.FlgActivo = paciente.FlgActivo;
                updated_patient.FechaNac = paciente.FechaNac;
                updated_patient.FechaAlta = paciente.FechaAlta;
                updated_patient.LastUpdate = DateTime.Now;           
                updated_patient.LugarNac = paciente.LugarNac?.ToUpper() ?? "";
                if (paciente.ParajeAtencion != null)
                {
                    updated_patient.ParajeAtencion = paciente.ParajeAtencion.ToUpper();
                }            
                if (checkPatient(paciente.Dni) == false)
                {
                    updated_patient.Dni = paciente.Dni;
                }
                _ctxt.SaveChanges();
            }
            _ctxt.SaveChanges();
        }

        public bool checkPatient(String dni)
        {
            if (dni != null)
            {
                return _ctxt.Pacientes.Any(o => o.Dni == dni);
            }
            return false;
        }

    }
}
