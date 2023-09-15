namespace PostureWebSite.Models
{
    public class ListUsersVM
    {
        public int IdCliente { get; set; }

        public int? IdUsuario { get; set; }

        public string? Nombres { get; set; }

        public string? Apellidos { get; set; }

        public string? Email { get; set; }

        public string? FechaRegistro { get; set; }
        public string? Username { get; set; }
        public string? Rol { get; set; }
    }
}
