using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using CookieCompany.Model.Context;

namespace CookieCompany.Web.Controllers
{
    [Authorize]
    public class ProductoController : Controller
    {
        private CookieCompanyModel db = new CookieCompanyModel();

        //public IQueryable<Inventario> Inventario
        //{
        //    get {
        //        if (HttpContext.Cache["_inventario"] != null)
        //            return (IQueryable<Inventario>) HttpContext.Cache["_inventario"];
        //        return null;
        //    }

        //    set {
        //        HttpContext.Cache.Add("_inventario",
        //            value, null, DateTime.Now.AddSeconds(10), TimeSpan.FromSeconds(10),
        //            System.Web.Caching.CacheItemPriority.Normal, null);

        //    }
        //}
        
        public PartialViewResult ObtenerInventario(int id)
        {
            //Response.Cache.SetCacheability(HttpCacheability.Server);
            //Inventario = db.Inventario.Where(x => x.ProductoId == id);

            var Inventario = System.Runtime.Caching.MemoryCache.Default.AddOrGetExisting("_inventario", 
                db.Inventario.Where(x => x.ProductoId == id), DateTime.Now.AddMinutes(1));

            return PartialView(Inventario);
        }

        public PartialViewResult VerImagen(int id)
        {
            return PartialView("VerImagen", "../../Imagenes/" + db.Producto.FirstOrDefault(x => x.Id == id) ? .Image);
        }

        [OutputCache(Duration = 60, /*CacheProfile = "ProductoHome", SqlDependency = ".",*/ Location = System.Web.UI.OutputCacheLocation.Client)]
        // GET: Producto
        public ActionResult Index()
        {
            return View(db.Producto.ToList());
        }

        [OutputCache(Duration = 60, Location = System.Web.UI.OutputCacheLocation.Client/*, VaryByParam = "id"*/)]
        // GET: Producto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        [OutputCache(Duration = 60)]
        // GET: Producto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Producto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    HttpPostedFileBase file = Request.Files[0];
                    var fileInfo = new System.IO.FileInfo(file.FileName);
                    file.SaveAs(Server.MapPath("~/Imagenes/") + fileInfo.Name);
                    producto.Image = fileInfo.Name;
                }
                
                // no permite numeros
                Regex regex = new Regex(@"^\d");
                if (regex.Match(producto.Name).Success)
                {
                    ModelState.AddModelError("Name", "No puede ser númerico");
                    return View(producto);
                }

                db.Producto.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(producto);
        }

        [OutputCache(Duration = 60)]
        // GET: Producto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Producto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Producto producto)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    HttpPostedFileBase file = Request.Files[0];
                    var fileInfo = new System.IO.FileInfo(file.FileName);
                    file.SaveAs(Server.MapPath("~/Imagenes/") + fileInfo.Name);
                    producto.Image = fileInfo.Name;
                }

                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(producto);
        }

        // GET: Producto/Delete/5
        [OutputCache(Duration = 60)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = db.Producto.Find(id);

            if (producto.Inventario.Any(x => x.Id.ToString().Length > 0))
            {
                ModelState.AddModelError("Name", "El producto tiene asociado un valor en Inventario");
                return View();
            }

            db.Producto.Remove(producto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
