using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CookieCompany.Model.Services.Data
{
    [DataContract(Name ="MiServicio", Namespace = "https://miservicio.com")]
    public class ProductoDTO
    {
        [DataMember(Order = 3)]
        public int Id { get; set; }

        [DataMember(Order = 1)]
        public string Name { get; set; }

        [DataMember(Order = 1)]
        public string Image { get; set; }
    }
}
