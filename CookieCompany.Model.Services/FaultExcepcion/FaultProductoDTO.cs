using System.Runtime.Serialization;

namespace CookieCompany.Model.Services.FaultExcepcion
{
    [DataContract(Name = "ServicioError", Namespace = "https://miservicioerror.com")]
    public class ProductoFault
    {
        [DataMember]
        public string Mensaje { get; set; }

        public ProductoFault(string mensaje)
        {
            this.Mensaje = mensaje;
        }
    }
}
