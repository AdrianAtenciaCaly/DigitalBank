# DigitalBank
# Sistema en N Capas

Este repositorio contiene el código fuente de un sistema en n capas desarrollado utilizando tecnologías como (.NET Framework), WCF (Windows Communication Foundation) y SQL Server.

## Descripción del Sistema

El sistema está diseñado siguiendo una arquitectura en n capas para separar las responsabilidades y mejorar la escalabilidad, mantenibilidad y modularidad. Las principales capas del sistema son:

1. Capa de Presentación (ASP.NET MVC): Contiene la interfaz de usuario y la interacción con el usuario final a través de vistas y controladores.

2. Capa de Negocio (Lógica de Negocio): Contiene la lógica principal de la aplicación, incluyendo reglas de negocio, procesamiento de datos y validaciones.

3. Capa de Acceso a Datos (Data Access Layer): Interactúa con la base de datos SQL Server para realizar operaciones CRUD y consultas.

## Requisitos del Sistema

- Visual Studio 20200  para abrir y compilar el proyecto.
- SQL Server Management Studio (SSMS) para la gestión de la base de datos.

## Estructura del Proyecto

El repositorio se organiza de la siguiente manera:

- `CapaPresentacion`: Contiene el proyecto ASP.NET MVC para la capa de presentación.
- `CapaNegocio`: Contiene la lógica de negocio y los servicios WCF.
- `CapaAccesoDatos`: Contiene las clases para acceder y gestionar la base de datos.

## Instrucciones de Uso

1. Clona el repositorio en tu entorno de desarrollo local.
2. Abre la solución en Visual Studio.
3. Configura la cadena de conexión a la base de datos en el archivo `web.config` de la capa de presentación y en la capa de acceso a datos.
4. Ejecuta la solución para compilar y ejecutar la aplicación.



## Pruebas

Se recomienda realizar pruebas unitarias, pruebas de integración y pruebas de sistema para validar el correcto funcionamiento del sistema en todas las capas.

## Contribuciones

Las contribuciones son bienvenidas. Si deseas contribuir al proyecto, sigue estos pasos:
1. Haz un fork del repositorio.
2. Realiza tus cambios en una nueva rama (branch).
3. Crea un pull request para revisar tus cambios.

## Autor

Autor: Adrian Atencia Caly
Contacto: adrianandres1998@gmail.com
## Licencia

Este proyecto está bajo la licencia MIT. Consulta el archivo LICENSE.md para más detalles.
