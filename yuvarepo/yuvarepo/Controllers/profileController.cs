using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using yuvarepo.Models;
using System.IO;

namespace yuvarepo.Controllers
{
    public class profileController : Controller
    {
        // GET: profile
        public ActionResult Index(profile obj)
        {

            //if (Request.Cookies["bid"] != null)
            //{
            //    var response = profiles.profile_select(obj);
            //    return Json(response, JsonRequestBehavior.AllowGet);
            //}
            //else
            //{
            //    return Json("", JsonRequestBehavior.AllowGet);
            //}
            obj.id = Request.Cookies["bid"].Values.ToString().Substring(4);
            var response = profiles.profile_select(obj);


            return View(response);
        }
        static profile profiles = new profile();
        public ActionResult profile_ins(profile obj)
        {


            var response=0;
            if (Request.Cookies["bid"] != null)
            {

               


                obj.updated_by = Request.Cookies["bid"].Values.ToString().Substring(4);
                obj.id = Request.Cookies["bid"].Values.ToString().Substring(4);
                response = profiles.profile_ins(obj);
                

            }
            ViewBag.profile_ins = "Profile Data Saved.";
            //return Json(response, JsonRequestBehavior.AllowGet);
            return View("index");
        }
        
    }
}