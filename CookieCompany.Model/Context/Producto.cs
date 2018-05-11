namespace CookieCompany.Model.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Producto")]
    public partial class Producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Producto()
        {
            Inventario = new HashSet<Inventario>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre del articulo")]
        public string Name { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Subir Fotografia")]
        public string Image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inventario> Inventario { get; set; }
    }
}
