using System;
using System.Collections.Generic;

namespace SistemaFacturacion.DATA.Models;

public partial class Usuario
{
    public int UserId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Contrasenia { get; set; } = null!;
}
