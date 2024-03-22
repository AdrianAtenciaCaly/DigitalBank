using DigitalBank.Modelos;
using DigitalBank.Negocio.Service;
using DigitalBank.Presentacion.Models;
using DigitalBank.Presentacion.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DigitalBank.Presentacion.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly IUsuarioService _usuarioService;
        public HomeController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        [HttpGet]
        public async Task <IActionResult> Lista()
        {
            IQueryable<Usuario> usuarios = await _usuarioService.ObtenerTodos();
            List<VMUsuario> listaUsuarios = (List<VMUsuario>)usuarios.Select(x => new VMUsuario()
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Sexo =x.Sexo,
                FechaNacimiento = x.FechaNacimiento,
            }) ;
            return StatusCode(StatusCodes.Status200OK, listaUsuarios);
        }

        [HttpPost]
        public async Task<IActionResult> Insertar([FromBody] VMUsuario vMUsuario)
        {
            Usuario usuario = new Usuario()
            {
                Nombre = vMUsuario.Nombre,
                Sexo = vMUsuario.Sexo,
                FechaNacimiento = vMUsuario.FechaNacimiento
            };
            bool resp = await _usuarioService.Adicionar(usuario);
            return StatusCode(StatusCodes.Status200OK, new {valor = resp});

        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] VMUsuario vMUsuario)
        {
            Usuario usuario = new Usuario()
            {
                Id= vMUsuario.Id,   
                Nombre = vMUsuario.Nombre,
                Sexo = vMUsuario.Sexo,
                FechaNacimiento = vMUsuario.FechaNacimiento
            };
            bool resp = await _usuarioService.Modificar(usuario);
            return StatusCode(StatusCodes.Status200OK, new { valor = resp });

        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
           
            bool resp = await _usuarioService.Eliminar(id);
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
