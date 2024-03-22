using System;
using System.Collections.Generic;

namespace DigitalBank.Modelos;

public partial class Usuario
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public string? Sexo { get; set; }
}
