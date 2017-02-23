using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using yuvarepo.Models;
namespace yuvarepo.Controllers
{
    public class loginController : Controller
    {
        // GET: login
        public ActionResult Index()
        {
            return View();
        }
        static gmail_login gmail_login=new gmail_login();

        public ActionResult login(gmail_login obj)
        {
            var response = 0;
            if (obj.gmail_id.ToString().Length > 0 && obj.email_id.ToString().Length > 0)
            {
                response= gmail_login.check_mail(obj);
            }
            return Json(response, JsonRequestBehavior.AllowGet);
        }


        public void login_btn()
        {
               string client_id = "775211725291-b2l3icb5fjvlrb444u21gouqbhq5l3qn.apps.googleusercontent.com";    // Replace this with your Client ID
               string client_sceret = "0l5aMk5xlD0r0BJB1vEdKAU6";                                                // Replace this with your Client Secret
               string redirect_url = "http://localhost:9130/g_redirect";                                         // Replace this with your Redirect URL; Your Redirect URL from your developer.google application should match this URL.
               string Parameters;
               var Googleurl = "https://accounts.google.com/o/oauth2/auth?response_type=token&redirect_uri=" + redirect_url + "&scope=https://www.googleapis.com/auth/userinfo.email%20https://www.googleapis.com/auth/userinfo.profile&client_id=" + client_id;
               Response.Redirect(Googleurl);
        }


    }
}