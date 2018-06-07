using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CookieCompany.Model.Services.Data;

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

        public IEnumerable<ProductoDTO> Productos()
        {
            return model.Producto.Select(x => new ProductoDTO { Id = x.Id , Name = x.Name, Image = x.Image});
        }
    }
}
