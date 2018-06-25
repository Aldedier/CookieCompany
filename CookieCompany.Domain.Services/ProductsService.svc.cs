using CookieCompany.Model.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace CookieCompany.Domain.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProductsService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ProductsService.svc or ProductsService.svc.cs at the Solution Explorer and start debugging.
    public class ProductsService : IProductsService
    {
        readonly Model.Context.CookieCompanyModel model;

        public ProductsService()
        {
            model = new Model.Context.CookieCompanyModel();
        }

        public IEnumerable<string> GetProducts()
        {
            return model.Producto.Select(x => x.Name);
        }

        public string GetProductsById(int id) => model.Producto.Find(id).Name;


        // Funciones por servicios y DTO
        public IEnumerable<ProductoDTO> Productos()
        {
            return model.Producto.Select(x => new ProductoDTO { Id = x.Id, Name = x.Name, Image = x.Image });
        }

        public ProductoDTO GetProductoById(int id)
        {
            var producto = model.Producto.FirstOrDefault(x => x.Id == id);
            if (producto == null)
                throw new Exception("Producto no encontrado");

            return new ProductoDTO
            {
                Name = producto.Name,
                Image = producto.Image
            };
        }


        public void AddProduct(ProductoDTO producto)
        {
            if (producto == null)
                throw new ArgumentNullException("producto");

            if (producto.Name == string.Empty && producto.Image == string.Empty)
            {
                throw new ArgumentNullException("producto");
                throw new FaultException<Model.Services.FaultExcepcion.ProductoFault>(new Model.Services.FaultExcepcion.ProductoFault("Faltó diligenciar un campo"));
            }

            if (!Uri.TryCreate(producto.Image, UriKind.Absolute, out Uri urlImage))
                throw new ArgumentNullException("URL Invalid Image");

            model.Producto.Add(new Model.Context.Producto
            {
                Name = producto.Name,
                Image = producto.Image
            });
            model.SaveChanges();

        }
    }
}
