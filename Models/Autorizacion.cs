using System;
using System.Collections.Generic;

namespace PostureWebSite.Models;

public partial class Autorizacion
{
    public int IdAutorizacion { get; set; }

    public int? IdRol { get; set; }

    public string? Opcion { get; set; }

    public string? Url { get; set; }

    public virtual Role? IdRolNavigation { get; set; }
}
