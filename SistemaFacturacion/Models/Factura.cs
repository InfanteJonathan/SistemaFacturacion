using System;
using System.Collections.Generic;

namespace SistemaFacturacion.Models;

public partial class Factura
{
    public int IdFactura { get; set; }

    public string? NumeroFactura { get; set; }

    public string? RucCliente { get; set; }

    public string? RazonSocial { get; set; }

    public decimal? Subtotal { get; set; }

    public decimal? PorcentajeIgv { get; set; }

    public decimal? Igv { get; set; }

    public decimal? Total { get; set; }

    public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; } = new List<DetalleFactura>();
}
