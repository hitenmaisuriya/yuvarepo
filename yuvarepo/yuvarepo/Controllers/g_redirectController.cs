using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace yuvarepo.Controllers
{
    public class g_redirectController : Controller
    {
        // GET: g_redirect

      
        public ActionResult Index()
        {
            return View();
        }



        [Route("signin-google")]
        public ActionResult sg()
        {
            return View();
        }
    }
}