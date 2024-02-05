using System;
using System.Collections.Generic;

namespace SistemaFacturacion.Models;

public partial class DetalleFactura
{
    public string IdItem { get; set; } = null!;

    public int? IdFactura { get; set; }

    public string? CodigoProducto { get; set; }

    public string? NombreProducto { get; set; }

    public decimal? Precio { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Subtotal { get; set; }

    public int? IdProducto { get; set; }

    public virtual Factura? IdFacturaNavigation { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }
}
