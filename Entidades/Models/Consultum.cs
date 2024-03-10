using System;
using System.Collections.Generic;

namespace Entidades.Models;

public partial class Consultum
{
    public int Id { get; set; }

    public int? PacienteId { get; set; }

    public string? FechaAtencion { get; set; }

    public string? MotivoConsulta { get; set; }

    public string? EdadConsulta { get; set; }

    public string? DiagnosticoConsulta { get; set; }

    public string? Observacion { get; set; }

    public string? EvalNutric { get; set; }

    public string? EvalSoc { get; set; }

    public string? Fum { get; set; }

    public string? MacActual { get; set; }

    public string? FechaMac { get; set; }

    public DateTime? FechaCreacion { get; set; }
}
