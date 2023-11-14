using System;
using System.Collections.Generic;

namespace PostureWebSite.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public int? IdRol { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual Role? IdRolNavigation { get; set; }

    public virtual ICollection<RegistroBotone> RegistroBotones { get; set; } = new List<RegistroBotone>();
}

public class LoginRequest
{
    public string? Username { get; set; }
    public string? Password { get; set; }
}
