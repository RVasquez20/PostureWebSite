using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

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

public class DataRecived
{
    [JsonPropertyName("BUTTON1")]
    public bool BUTTON1 { get; set; }

    [JsonPropertyName("BUTTON2")]
    public bool BUTTON2 { get; set; }

    [JsonPropertyName("BUTTON3")]
    public bool BUTTON3 { get; set; }

    [JsonPropertyName("BUTTON4")]
    public bool BUTTON4 { get; set; }

    [JsonPropertyName("BUTTON5")]
    public bool BUTTON5 { get; set; }

    [JsonPropertyName("BUTTON6")]
    public bool BUTTON6 { get; set; }
}
