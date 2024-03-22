using DigitalBank.Modelos;
using DigitalBank.Negocio.Service;
using DigitalBank.Presentacion.Models;
using DigitalBank.Presentacion.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ServiceReferenceUsuarioWCF;
using DigitalBank.Negocio.ServiceWFC;
using Microsoft.AspNetCore.Authorization;


namespace DigitalBank.Presentacion.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly ServiceReferenceUsuarioWCF.UsuarioServiceWCFClient _service;

        public HomeController(ServiceReferenceUsuarioWCF.UsuarioServiceWCFClient service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Lista()
        {
           
            var usuariosWCF = await _service.ObtenerUsuariosAsync();

           
            var usuariosModel = new List<VMUsuario>();
            foreach (var usuarioWCF in usuariosWCF)
            {
                usuariosModel.Add(new VMUsuario
                {
                    Id = usuarioWCF.Id,
                    Nombre = usuarioWCF.Nombre,
                    FechaNacimiento = usuarioWCF.FechaNacimiento,
                    Sexo = usuarioWCF.Sexo
                });
            }

            
            return StatusCode(StatusCodes.Status200OK, usuariosModel);
        }

        [HttpPost]
        public async Task<IActionResult> Insertar([FromBody] VMUsuario vMUsuario)
        {

            ServiceReferenceUsuarioWCF.Usuario usuario = new ServiceReferenceUsuarioWCF.Usuario()
            {
                Nombre = vMUsuario.Nombre,
                Sexo = vMUsuario.Sexo,
                FechaNacimiento = vMUsuario.FechaNacimiento
            };


            bool resp = await _service.CrearUsuarioAsync(usuario);

            // Devolver una respuesta con el estado de la operación
            return StatusCode(StatusCodes.Status200OK, new { valor = resp });
        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] VMUsuario vMUsuario)
        {
            
            ServiceReferenceUsuarioWCF.Usuario usuario = new ServiceReferenceUsuarioWCF.Usuario()
            {
                Id = vMUsuario.Id,
                Nombre = vMUsuario.Nombre,
                Sexo = vMUsuario.Sexo,
                FechaNacimiento = vMUsuario.FechaNacimiento
            };

       
            bool resp = await _service.ActualizarUsuarioAsync(usuario);

           
            return StatusCode(StatusCodes.Status200OK, new { valor = resp });
        }

        [HttpDelete]
        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
            
            bool resp = await _service.EliminarUsuarioAsync(id);

       
            return StatusCode(StatusCodes.Status200OK, new { valor = resp });
        }
        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
