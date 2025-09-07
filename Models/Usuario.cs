using System.ComponentModel.DataAnnotations;

namespace encuestasgym.Models
{
    public class Usuario
    {
    public int Id { get; set; }

    [Required]
    public required string Nombre { get; set; }

    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public required string Password { get; set; }

    // Rol: "administrador" o "cliente"
    [Required]
    public required string Rol { get; set; }
    }
}
