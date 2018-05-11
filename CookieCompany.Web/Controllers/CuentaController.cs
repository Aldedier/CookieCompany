using CookieCompany.Model.Fluent;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace CookieCompany.Web.Controllers
{
    public class CuentaController : Controller
    {
        // GET: Cuenta
        public ActionResult LogIn()
        {
            return View(new SingOn());
        }

        [HttpPost]
        public ActionResult LogIn(SingOn singOn)
        {
            if (ModelState.IsValid)
            {
                while(singOn.UserName != "Aldedier" && singOn.Password != "123")
                {
                    ModelState.AddModelError("UserName", "Credenciales invalidas");
                    return View(singOn);
                }

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, singOn.UserName),
                    new Claim("ip", Request.ServerVariables["REMOTE_ADDR"])
                };

                ClaimsIdentity identity = new ClaimsIdentity(claims, "ApplicationCookie");

                Request.GetOwinContext().Authentication.SignIn(identity);
                return RedirectToAction("Index", "Producto");
            }
            return View(singOn);
        }


        public ActionResult LogOut()
        {
            Request.GetOwinContext().Authentication.SignOut("ApplicationCookie");
            return RedirectToAction("LogIn", "Cuenta");
        }
    }
}