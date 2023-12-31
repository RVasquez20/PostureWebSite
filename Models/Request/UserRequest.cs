﻿using System.ComponentModel.DataAnnotations;

namespace PostureWebSite.Models.Request
{
    public class UserRequest
    {
        public int IdUsuario { get; set; }
        public string? Nombres { get; set; }

        public string? Apellidos { get; set; }

        public string? Email { get; set; }
        [Display(Name ="Rol")]
        public int? IdRol { get; set; }
        [Display(Name = "Peso (Libras)")]
        public int? Peso { get; set; }
        [Display(Name = "Altura (Centimetros)")]
        public int? Altura { get; set; }

        public string? Username { get; set; }

        public string? Password { get; set; }

    }
}
