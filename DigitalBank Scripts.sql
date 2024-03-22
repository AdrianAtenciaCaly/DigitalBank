IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'DigitalBank')
BEGIN
    CREATE DATABASE DigitalBank;
END;
 
use DigitalBank
-- Crear una nueva tabla llamada 'Usuarios'
CREATE TABLE Usuarios (
    Id INT IDENTITY(1,1) PRIMARY KEY, -- Columna de ID autoincremental
    Nombre NVARCHAR(100), -- Columna para el nombre (texto con longitud 100)
    FechaNacimiento DATE, -- Columna para la fecha de nacimiento
    Sexo CHAR(1) -- Columna para el sexo (texto fijo con longitud 1)
);

-- Insertar 5 registros de prueba en la tabla Usuarios
INSERT INTO Usuarios (Nombre, FechaNacimiento, Sexo) VALUES
('Juan Pérez', '1990-05-15', 'M'),
('María González', '1985-09-20', 'F'),
('Pedro Martinez', '1992-11-10', 'M'),
('Ana López', '1988-03-25', 'F'),
('Carlos Rodríguez', '1995-07-08', 'M');

-- Sp para crear un nuevo usuario 
CREATE PROCEDURE InsertarUsuario
    @Nombre NVARCHAR(50),
    @Sexo CHAR(1),
    @FechaNacimiento DATE
AS
BEGIN
    INSERT INTO Usuarios (Nombre, Sexo, FechaNacimiento)
    VALUES (@Nombre, @Sexo, @FechaNacimiento);
END;

-- Sp para actualizar un usuario existente
CREATE PROCEDURE ActualizarUsuario
    @Id INT,
    @Nombre NVARCHAR(50),
    @Sexo CHAR(1),
    @FechaNacimiento DATE
AS
BEGIN
    UPDATE Usuarios
    SET Nombre = @Nombre,
        Sexo = @Sexo,
        FechaNacimiento = @FechaNacimiento
    WHERE Id = @Id;
END;

-- Sp para eliminar un usuario 
CREATE PROCEDURE EliminarUsuario
    @Id INT
AS
BEGIN
    DELETE FROM Usuarios
    WHERE Id = @Id;
END;
-- Sp para  obtener la lista de los usuarios
CREATE PROCEDURE ObtenerUsuarios
AS
BEGIN
    SELECT Id, Nombre, Sexo, FechaNacimiento
    FROM Usuarios;
END;
-- Sp para obtener un usuario por Id 
CREATE PROCEDURE ObtenerUsuarioPorId
    @Id INT
AS
BEGIN
    SELECT Id, Nombre, Sexo, FechaNacimiento
    FROM Usuarios
    WHERE Id = @Id;
END;
