using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SistemaFacturacion.DATA.Models;

public partial class Producto
{
    public int IdProducto { get; set; }
    [Required]
    public string? Codigo { get; set; }
    [Required]
    public string? Nombre { get; set; }

    public int? IdFamilia { get; set; }
    [Required]
    public decimal? Precio { get; set; }
    [Required]
    public int? Stock { get; set; }

    public bool? Activo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    [JsonIgnore]
    public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; } = new List<DetalleFactura>();

    public virtual FamiliaProducto? IdFamiliaNavigation { get; set; }
}
