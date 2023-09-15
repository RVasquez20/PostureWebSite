using System;
using System.Collections.Generic;

namespace PostureWebSite.Models;

public partial class RegistroBotone
{
    public int IdRegistroBotones { get; set; }

    public DateTime? FechaHora { get; set; }

    public int? Duracion { get; set; }

    public bool? Boton1 { get; set; }

    public bool? Boton2 { get; set; }

    public bool? Boton3 { get; set; }

    public bool? Boton4 { get; set; }

    public bool? Boton5 { get; set; }

    public bool? Boton6 { get; set; }

    public int? IdUser { get; set; }

    public virtual Usuario? IdUserNavigation { get; set; }
}
