using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieCompany.Model.Fluent
{
    public class SingOn
    {
        [Required(ErrorMessage = "El usuario es requerido")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "La constraseña es requerido")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
