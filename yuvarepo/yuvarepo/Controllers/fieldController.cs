using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using yuvarepo.Models;


namespace yuvarepo.Controllers
{
    public class fieldController : Controller
    {
        // GET: field
        public ActionResult Index()
        {
            return View();
        }
        static fields fieldes_model = new fields();
        public ActionResult fields_ins(fields obj)
        {
            var response = fieldes_model.field_ins(obj);
            return Json(response,JsonRequestBehavior.AllowGet);
        }
        public ActionResult all_fields(fields obj)
        {
            var response = fieldes_model.all_field();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
      
    }
}