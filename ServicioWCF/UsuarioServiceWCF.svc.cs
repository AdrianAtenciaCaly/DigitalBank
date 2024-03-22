using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServicioWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IUsuarioServiceWCF
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MiConexionBD"].ConnectionString;
        public bool ActualizarUsuario(Usuario usuario)
        {
            bool exito = false;
            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ActualizarUsuarioSP", connection)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", usuario.Id);
                    cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", usuario.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@Sexo", usuario.Sexo);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    exito = true;
                }
            }
            }
            catch (Exception ex)
            {

                exito = false;
            }

            return exito;
        }

        public bool CrearUsuario(Usuario usuario)
        {
            bool exito = false; 

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("CrearUsuarioSP", connection)) 
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", usuario.FechaNacimiento);
                        cmd.Parameters.AddWithValue("@Sexo", usuario.Sexo);
                        connection.Open();
                        cmd.ExecuteNonQuery();

                        
                        exito = true;
                    }
                }
            }
            catch (Exception ex)
            {
              
                exito = false; 
            }

            return exito; 
        }

        public bool EliminarUsuario(int id)
        {
            bool exito = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("EliminarUsuarioSP", connection)) // Reemplaza "EliminarUsuarioSP" con el nombre real de tu stored procedure para eliminar usuarios
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
            catch (Exception ex)
            {
              
                exito = false; 
            }

            return exito; 
        }

        public Usuario ObtenerUsuarioPorId(int id)
        {
            Usuario usuario = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ObtenerUsuarioPorIdSP", connection)) // Reemplaza "ObtenerUsuarioPorIdSP" con el nombre real de tu stored procedure para obtener un usuario por su ID
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        usuario = new Usuario
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nombre = reader["Nombre"].ToString(),
                            FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]),
                            Sexo = reader["Sexo"].ToString()
                        };
                    }
                    reader.Close();
                }
            }
            return usuario;
        }

        public List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ObtenerUsuariosSP", connection)) // Reemplaza "ObtenerUsuariosSP" con el nombre real de tu stored procedure para obtener usuarios
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        usuarios.Add(new Usuario
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nombre = reader["Nombre"].ToString(),
                            FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]),
                            Sexo = reader["Sexo"].ToString()
                        });
                    }
                    reader.Close();
                }
            }
            return usuarios;
        }

        public bool GrabarLog(string Evento)
        {
            bool exito = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("RegistrarEventoLog", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FechaHora ", DateTime.Now);
                        cmd.Parameters.AddWithValue("Evento", Evento);
                     
                        connection.Open();
                        cmd.ExecuteNonQuery();


                        exito = true;
                    }
                }
            }
            catch (Exception ex)
            {

                exito = false;
            }

            return exito;
        }
    }
}
