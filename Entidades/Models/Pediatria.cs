using System;
using System.Collections.Generic;

namespace Entidades.Models;

public partial class Pediatria
{
    public int Id { get; set; }

    public int? PacienteId { get; set; }

    public double? Peso { get; set; }

    public double? PercentilPeso { get; set; }

    public double? PzPeso { get; set; }

    public double? Talla { get; set; }

    public double? PercentilTalla { get; set; }

    public double? PzTalla { get; set; }

    public double? Imc { get; set; }

    public double? PercentilImc { get; set; }

    public double? PzImc { get; set; }

    public double? Pc { get; set; }

    public double? PercentilPc { get; set; }

    public double? PzPc { get; set; }

    public string? AgudezaDer { get; set; }

    public string? AgudezaIzq { get; set; }

    public DateTime? FechaCreacion { get; set; }
}
