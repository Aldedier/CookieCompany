using CookieCompany.Model.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using CookieCompany.Model.Services.FaultExcepcion;

namespace CookieCompany.Domain.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProductsService" in both code and config file together.
    [ServiceContract]
    public interface IProductsService
    {
        [OperationContract]
        IEnumerable<string> GetProducts();

        [OperationContract]
        [FaultContract(typeof(ProductoFault), Action = "http://demoswcf/Producto/ProductoIdFault")]
        string GetProductsById(int id);

        [OperationContract]
        IEnumerable<ProductoDTO> Productos();

        [OperationContract]
        [FaultContract(typeof(ProductoFault), Action = "http://demoswcf/Producto/ProductoFault")]
        void AddProduct(ProductoDTO producto);
    }
}
