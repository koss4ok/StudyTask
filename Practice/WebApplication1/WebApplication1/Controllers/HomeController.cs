using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private databaseEntities db = new databaseEntities();
        public ActionResult Index() => View();
        public ActionResult Admin_index() => View();
        public ActionResult Auth() => View();
        public ActionResult Register() => View();

        [HttpPost, ActionName("Register")]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterConfirmed([Bind(Include = "Id,Login,Password")] Admin adm)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    //Хранимая процедура "NewAdmin" для регистрации нового администратора
                    var regInfo = db.NewAdmin(adm.Login, adm.Password).ToList();
                    if (regInfo != null && Convert.ToInt32(regInfo[0]) != -1)
                    {
                        db.SaveChanges();
                        return RedirectToAction("Auth");
                    }
                    else
                    {
                        ModelState.AddModelError("Email", "ПОЛЬЗОВАТЕЛЬ С ТАКИМ ИМЕНЕМ (E-MAIL) УЖЕ СУЩЕСТВУЕТ.");
                    }
                }
            }
            catch (Exception ex)
            { }

            return View();
        }

        public ActionResult Exit()
        {
            Account.person = null;
            return RedirectToAction("Auth");
        }

        [HttpPost, ActionName("Auth")]
        [ValidateAntiForgeryToken]
        public ActionResult AutorisationConfirmed([Bind(Include = "Login,Password")] Admin adm)
        {
            
            try
            {
                if (ModelState.IsValid)
                {

                    var regInfo = db.CheckAcc(adm.Login, adm.Password).ToList();
                    if (regInfo.Count != 0)
                    {
                        Account.person = db.Admin.Where(s => s.Login == adm.Login).ToArray()[0];
                        return RedirectToAction("Admin_index", "Komputers");
                    }
                    else
                    {
                        ModelState.AddModelError("Login", "Вы ошиблись");
                        ModelState.AddModelError("Password", "Вы ошиблись");
                    }
                }
            }
            catch (Exception ex)
            { }

            return View(adm);
        }
    }
}