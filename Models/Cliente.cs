using System;
using System.Collections.Generic;

namespace PostureWebSite.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public int? IdUsuario { get; set; }

    public string? Nombres { get; set; }

    public string? Apellidos { get; set; }

    public string? Email { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
