using System;
using System.Collections.Generic;

namespace BackPTecnica.Models;

public partial class Task
{
    public int IdTarea { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public string? Prioridad { get; set; }

    public int? TaskComplete { get; set; }
}
