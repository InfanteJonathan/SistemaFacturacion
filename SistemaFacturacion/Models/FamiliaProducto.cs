using System;
using System.Collections.Generic;

namespace SistemaFacturacion.Models;

public partial class FamiliaProducto
{
    public int IdFamilia { get; set; }

    public string? Codigo { get; set; }

    public string? Nombre { get; set; }

    public bool? Activo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
