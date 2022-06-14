using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AplicativoSponsor.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //if (Session["id_logado"] != null) { 
                return View(); 
            //}
            //else { 
                //return RedirectToAction("Login", "Login"); 
            //}

        }

    }
}