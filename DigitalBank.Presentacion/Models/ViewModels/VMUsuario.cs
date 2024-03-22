﻿namespace DigitalBank.Presentacion.Models.ViewModels
{
    public class VMUsuario
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public DateOnly? FechaNacimiento { get; set; }

        public string? Sexo { get; set; }
    }
}
