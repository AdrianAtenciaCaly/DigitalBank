using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ServicioWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IUsuarioServiceWCF
    {
        [OperationContract]
        List<Usuario> ObtenerUsuarios();

        [OperationContract]
        Usuario ObtenerUsuarioPorId(int id);

        [OperationContract]
        void CrearUsuario(Usuario usuario);

        [OperationContract]
        void ActualizarUsuario(Usuario usuario);

        [OperationContract]
        void EliminarUsuario(int id);
    }


    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    [DataContract]
    public class Usuario
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public DateTime FechaNacimiento { get; set; }

        [DataMember]
        public string Sexo { get; set; }
    }
}
