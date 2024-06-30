using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AracKiralamaDB.Controllers
{
    public class iletisimController : Controller
    {
        // GET: iletisim
        public ActionResult iletisim()
        {
            return View();
        }
        public ActionResult Musteriiletisim()
        {
            return View();
        }
    }
}