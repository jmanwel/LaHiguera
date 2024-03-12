using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public interface IPacienteService
    {
        List<Paciente> getAllPatients();
        void create(Paciente paciente);
        void setDeactivate(int id_patient);

    }
}