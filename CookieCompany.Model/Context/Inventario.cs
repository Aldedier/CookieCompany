namespace CookieCompany.Model.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Inventario")]
    public partial class Inventario
    {

        public int Id { get; set; }

        [Display(Name = "Fecha inventario")]
        public DateTime Fecha { get; set; }

        [Display(Name = "Cantidad inventario")]
        public int Cantidad { get; set; }

        [Display(Name = "Seleccione el producto")]
        public int ProductoId { get; set; }

        public virtual Producto Producto { get; set; }
    }
}
