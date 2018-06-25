namespace CookieCompany.Domain.Services
{
    using CookieCompany.Model.Services.Data;
    using CookieCompany.Model.Services.FaultExcepcion;
    using System.Collections.Generic;
    using System.ServiceModel;

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
        ProductoDTO GetProductoById(int id);

        [OperationContract]
        [FaultContract(typeof(ProductoFault), Action = "http://demoswcf/Producto/ProductoFault")]
        void AddProduct(ProductoDTO producto);
    }
}
