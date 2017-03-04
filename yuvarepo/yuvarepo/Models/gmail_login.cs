using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Net.Http;
using Newtonsoft.Json;

namespace yuvarepo.Models
{
    public class gmail_login
    {
        private yuva yuva;
        public string email_id { get; set; }
        public string gmail_id { get; set; }

        
        public int check_mail(gmail_login obj)
        {
            yuva = new yuva();
            DataTable dt;
            dt = yuva.datatables("select * from profile where email='"+ obj.email_id+"'  and gmail_id='"+obj.gmail_id+"'  ");
            if (dt.Rows.Count > 0)
            {

                dt = yuva.datatables("select * from profile where email='" + obj.email_id + "' and  gmail_id='" + obj.gmail_id + "' and yk_id is null ");
                if (dt.Rows.Count > 0)
                {
                    //here bid= blank profile id
                    HttpCookie bid = new HttpCookie("bid");

                    bid.Values["bid"] = dt.Rows[0]["id"].ToString();

                    bid.Expires = DateTime.Now.AddDays(30);

                    HttpContext.Current.Response.Cookies.Add(bid);
                    HttpContext.Current.Response.Redirect("~/profile");

                }
                else
                {
                    dt = yuva.datatables("select * from profile where email='" + obj.email_id + "' and gmail_id='" + obj.gmail_id + "' and isapv=1 ");
                    if (dt.Rows.Count > 0)
                    {
                        //here aid= approval remain id;
                        HttpCookie aid = new HttpCookie("aid");

                        aid.Values["aid"] = dt.Rows[0]["id"].ToString();

                        aid.Expires = DateTime.Now.AddDays(30);

                        HttpContext.Current.Response.Cookies.Add(aid);
                        HttpContext.Current.Response.Redirect("http://localhost:9130");

                    }
                    else
                    {
                        //here id means who has approved by admin
                        HttpCookie id = new HttpCookie("id");

                        id.Values["id"] = dt.Rows[0]["id"].ToString();

                        id.Expires = DateTime.Now.AddDays(30);

                        HttpContext.Current.Response.Cookies.Add(id);
                        HttpContext.Current.Response.Redirect("http://localhost:9130");
                    }
                }

            }
            else
            {
                yuva.ins("insert into profile (email,gmail_id,created_on)values('"+obj.email_id+"','"+obj.gmail_id+"','"+DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss") + "')");
                dt = yuva.datatables("select * from profile where email='" + obj.email_id + "' and gmail_id='" + obj.gmail_id + "' ");
                if (dt.Rows.Count > 0)
                {
                    HttpCookie bid = new HttpCookie("bid");

                    bid.Values["bid"] = dt.Rows[0]["id"].ToString();

                    bid.Expires = DateTime.Now.AddDays(30);

                    HttpContext.Current.Response.Cookies.Add(bid);
                    HttpContext.Current.Response.Redirect("~/profile");
                }
            }
            return 1;
        }


        public class GooglePlusAccessToken
        {
            public string access_token { get; set; }
            public string token_type { get; set; }
            public int    expires_in { get; set; }
            public string id_token { get; set; }
            public string refresh_token { get; set; }
        }

        public async void getgoogleplususerdataSer(string access_token)
        {
            
                HttpClient client = new HttpClient();
                var urlProfile = "https://www.googleapis.com/oauth2/v1/userinfo?access_token=" + access_token;

                client.CancelPendingRequests();
                HttpResponseMessage output = await client.GetAsync(urlProfile);

                if (output.IsSuccessStatusCode)
                {
                    string outputData = await output.Content.ReadAsStringAsync();
                    GoogleUserOutputData serStatus = JsonConvert.DeserializeObject<GoogleUserOutputData>(outputData);

                    if (serStatus != null)
                    {
                        // You will get the user information here.
                    }
                }
           
        }

        public class GoogleUserOutputData
        {
            public string id { get; set; }
            public string name { get; set; }
            public string given_name { get; set; }
            public string email { get; set; }
            public string picture { get; set; }
        }








    }








}