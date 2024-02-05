using System;
using System.Collections.Generic;

namespace SistemaFacturacion.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? Codigo { get; set; }

    public string? Nombre { get; set; }

    public int? IdFamilia { get; set; }

    public decimal? Precio { get; set; }

    public int? Stock { get; set; }

    public bool? Activo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; } = new List<DetalleFactura>();

    public virtual FamiliaProducto? IdFamiliaNavigation { get; set; }
}
