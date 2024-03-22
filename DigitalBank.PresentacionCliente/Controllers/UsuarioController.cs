using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DigitalBank.PresentacionCliente.ServiceReferenceUsuarioWCF;
using Newtonsoft.Json;
using OfficeOpenXml;
using FirebaseAdmin;
namespace DigitalBank.PresentacionCliente.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        ServiceReferenceUsuarioWCF.UsuarioServiceWCFClient UsuarioServiceWCFClient = new ServiceReferenceUsuarioWCF.UsuarioServiceWCFClient();
        public ActionResult Index()
        {
            return View(UsuarioServiceWCFClient.ObtenerUsuarios());
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            var usuario = UsuarioServiceWCFClient.ObtenerUsuarioPorId(id);

            return View(usuario);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create([Bind(Include ="Nombre,Sexo,FechaNacimiento")] Usuario usuario)
        {
            try
            {
                // TODO: Add insert logic here

                bool usuarioCreado = UsuarioServiceWCFClient.CrearUsuario(usuario);
                if (usuarioCreado)
                {
                    GrabarLog("Se grabo el usuario {Nombre: " + usuario.Nombre + ", FechaNacimiento: " + usuario.FechaNacimiento + ",Sexo: " + usuario.Sexo + "}");

                    return RedirectToAction("Index");
                }
                else
                {
                   
                    ModelState.AddModelError("", "No se pudo crear el usuario. Por favor, inténtalo de nuevo.");
                    GrabarLog("Error al grabar el usuario {Nombre: " + usuario.Nombre + ", FechaNacimiento: " + usuario.FechaNacimiento + ",Sexo: " + usuario.Sexo + "}");

                    return View(usuario);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            var usuario = UsuarioServiceWCFClient.ObtenerUsuarioPorId(id);

            return View(usuario);
     
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Sexo,FechaNacimiento")] Usuario usuario)
        {
            try
            {
                // TODO: Add update logic here
                bool usuarioEditado = UsuarioServiceWCFClient.ActualizarUsuario(usuario);

                if (usuarioEditado)
                {
                    GrabarLog("Se actualizo el usuario {Nombre: " + usuario.Nombre + ", FechaNacimiento: " + usuario.FechaNacimiento + ",Sexo: " + usuario.Sexo + "}");

                    return RedirectToAction("Index");
                }
                else
                {

                    ModelState.AddModelError("", "No se pudo actualizar el usuario. Por favor, inténtalo de nuevo.");
                    GrabarLog("Error al actualizar el usuario {Nombre: " + usuario.Nombre + ", FechaNacimiento: " + usuario.FechaNacimiento + ",Sexo: " + usuario.Sexo + "}");

                    return RedirectToAction("Index");
                }
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {

            return View();
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                bool usuarioEliminado = UsuarioServiceWCFClient.EliminarUsuario(id);

                if (usuarioEliminado)
                {
                    var usuario = UsuarioServiceWCFClient.ObtenerUsuarioPorId(id);
                    GrabarLog("Se elimino el usuario correctamente ");

                    return RedirectToAction("Index");
                }
                else
                {

                    ModelState.AddModelError("", "No se pudo actualizar el usuario. Por favor, inténtalo de nuevo.");
                    GrabarLog("Error al eliminar el usuario");

                    return RedirectToAction("Index");
                }
               
            }
            catch
            {
                return View();
            }
        }
        public ActionResult ExportToExcel()
        {
            IEnumerable<Usuario> usuarios = UsuarioServiceWCFClient.ObtenerUsuarios(); // Obtener datos de la consulta

            // Crear el archivo Excel
            ExcelPackage excelPackage = new ExcelPackage();
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Usuarios");

            // Escribir los encabezados
            worksheet.Cells[1, 1].Value = "Fecha de Nacimiento";
            worksheet.Cells[1, 2].Value = "Nombre";
            worksheet.Cells[1, 3].Value = "Sexo";

            // Escribir los datos de los usuarios en el archivo Excel
            int row = 2;
            foreach (var usuario in usuarios)
            {
                worksheet.Cells[row, 1].Value = usuario.FechaNacimiento.ToString("dd/MM/yyyy");
                worksheet.Cells[row, 2].Value = usuario.Nombre;
                worksheet.Cells[row, 3].Value = usuario.Sexo;
                row++;
            }

            // Guardar el archivo Excel en la respuesta HTTP
            byte[] excelFile = excelPackage.GetAsByteArray();
            return File(excelFile, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Usuarios.xlsx");
        }
      public void GrabarLog(string evento)
        {
            UsuarioServiceWCFClient.GrabarLog(evento);
        }
    }
}
