using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PostureWebSite.Models;

public partial class RegistroBotone
{
    public int IdRegistroBotones { get; set; }
    [Display(Name ="Fecha y Hora")]
    public DateTime? FechaHora { get; set; }

    public int? Duracion { get; set; }
    [Display(Name = "Boton 1")]
    public bool? Boton1 { get; set; }
    [Display(Name = "Boton 2")]
    public bool? Boton2 { get; set; }
    [Display(Name = "Boton 3")]
    public bool? Boton3 { get; set; }
    [Display(Name = "Boton 4")]
    public bool? Boton4 { get; set; }
    [Display(Name = "Boton 5")]
    public bool? Boton5 { get; set; }
    [Display(Name = "Boton 6")]
    public bool? Boton6 { get; set; }

    public int? IdUser { get; set; }

    public virtual Usuario? IdUserNavigation { get; set; }
}
