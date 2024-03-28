using System;
using System.Collections.Generic;

namespace Entidades.Models;

public partial class Ginecologia
{
    public int Id { get; set; }

    public int? PacienteId { get; set; }

    public int? Gestas { get; set; }

    public int? Para { get; set; }

    public int? Cesareas { get; set; }

    public int? Abortos { get; set; }

    public int? Irs { get; set; }

    public int? Menarca { get; set; }

    public string? RitmoMenst { get; set; }

    public int? Menopausia { get; set; }

    public int? TomaPap { get; set; }

    public string? ResultadoPap { get; set; }

    public int? Colposcopia { get; set; }

    public string? EstudiosComp { get; set; }

    public DateTime? FechaCreacion { get; set; }
}
