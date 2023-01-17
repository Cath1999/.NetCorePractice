using System;
using System.Collections.Generic;

namespace DBENTITY.Models;

public partial class Cargo
{
    public int IdCargo { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Empleado> Empleados { get; } = new List<Empleado>();
}
