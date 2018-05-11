using CookieCompany.Model.Context;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CookieCompany.Web.Controllers
{
    [Authorize]
    public class UtilsController : Controller
    {
        // GET: Utils




        private CookieCompanyModel db = new CookieCompanyModel();

        public ActionResult ObtenerProductosId(int id)
        => Json(db.Producto.Find(id), JsonRequestBehavior.AllowGet);

        public JsonResult ObtenerProductos()
            => Json(db.Producto, JsonRequestBehavior.AllowGet);

        // Estudiar TPL - Action - Invoke - Anonymous Invoke - Func => Linq
        // Solcitudes JSON Asincronas - Async Await
        public async Task<JsonResult> ObtenerProductosAsync(int id)
        {
            return Json(await db.Producto.FindAsync(id));
        }
    }
}