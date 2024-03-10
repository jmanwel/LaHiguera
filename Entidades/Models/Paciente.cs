using System;
using System.Collections.Generic;

namespace Entidades.Models;

public partial class Paciente
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public int? Dni { get; set; }

    public DateOnly? FechaNac { get; set; }

    public string? Sexo { get; set; }

    public string? ParajeAtencion { get; set; }

    public int? FlgActivo { get; set; }

    public DateTime? FechaAlta { get; set; }
}
