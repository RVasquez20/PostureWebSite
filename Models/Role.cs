using System;
using System.Collections.Generic;

namespace PostureWebSite.Models;

public partial class Role
{
    public int IdRol { get; set; }

    public string? Rol { get; set; }

    public virtual ICollection<Autorizacion> Autorizacions { get; set; } = new List<Autorizacion>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
