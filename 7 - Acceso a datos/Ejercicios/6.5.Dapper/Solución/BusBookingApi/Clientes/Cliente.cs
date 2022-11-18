namespace BusBookingApi.Clientes;

using BusBookingApi.ValidationAttributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Cliente : IValidatableObject
{
    [Required]
    [Dni]
    public string Dni { get; set; } = string.Empty;

    [Required]
    public string Nombre { get; set; } = string.Empty;

    [Required]
    public string Apellidos { get; set; } = string.Empty;

    [EmailAddress]
    public string? Email { get; set; }

    [Phone]
    public string? Telefono { get; set; }

    public string? Foto { get; set; }

    public Cliente() { }

    public Cliente(Domain.ClienteQueryModel cliente)
    {
        Dni = cliente.Dni;
        Nombre = cliente.Nombre;
        Apellidos = cliente.Apellidos;
        Telefono = cliente.Telefono;
        Email = cliente.Email;
        Foto = cliente.Foto;
    }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrEmpty(Email) && string.IsNullOrEmpty(Telefono))
        {
            yield return new ValidationResult("El email o el telefono debe estar rellenos", new[] { nameof(Email), nameof(Telefono) });
        }
    }
}