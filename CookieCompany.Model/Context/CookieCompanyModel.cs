namespace CookieCompany.Model.Context
{
    using System.Data.Entity;

    public partial class CookieCompanyModel : DbContext
    {
        public CookieCompanyModel()
            : base("name=CookieCompanyModel")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Inventario> Inventario { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Producto>()
                .HasMany(e => e.Inventario)
                .WithRequired(e => e.Producto)
                .WillCascadeOnDelete(false);
        }
    }
}
