using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Data;
using System.Text.RegularExpressions;

namespace yuvarepo.Models
{
    public class profile
    {
        public string id { get; set; }
      
        public string fname { get; set; }
        [Required]
        public string mname { get; set; }
        [Required]
        public string lname { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public string dob { get; set; }
        [Required]
        public int mob_no1 { get; set; }
        [Required]
        public int mob_no2{ get; set; }
      
        public string myfield { get; set; }
        public string yk_id { get; set; }
        [Required]
        public string created_on { get; set; }
        public string updated_by { get; set; }
        public string path { get; set; }
        public HttpPostedFileBase img { get; set; }
        private yuva yuva;
        public int profile_ins(profile obj)
        {
            HttpPostedFileBase file1= obj.img;
            string extension = Path.GetExtension(file1.FileName);
            string filename = Regex.Replace(DateTime.Now.ToString(), ":", " ");

            file1.SaveAs(HttpContext.Current.Server.MapPath("~\\pro_pic\\"+ filename + extension));
            path = "\\\\pro_pic\\\\" + filename + extension;
            yuva = new yuva();
            int i = yuva.ins("update profile set fname='" + obj.fname + "',mname='" + obj.mname + "',lname='" + obj.lname + "',address='" + obj.address + "',dob='" + obj.dob + "',mob_no1=" + obj.mob_no1 + ",mob_no2=" + obj.mob_no2 + ",yk_id='" + obj.yk_id + "',updated_by='"+obj.updated_by+"',img='" + path + "' where id='"+obj.id+"' ");
            return i;
        }
        public profile profile_select(profile obj)
        {
            yuva = new yuva();
            fields myfield = new fields();
            profile profile = new profile();
            DataTable dt = yuva.datatables("select * from profile where id='"+obj.id+"'");
            if (dt.Rows.Count > 0)
            {
                profile.id = dt.Rows[0]["id"].ToString();
                profile.fname = dt.Rows[0]["fname"].ToString();
                profile.mname = dt.Rows[0]["mname"].ToString();
                profile.lname = dt.Rows[0]["lname"].ToString();
                profile.address = dt.Rows[0]["address"].ToString();
                profile.dob = dt.Rows[0]["dob"].ToString();
                profile.mob_no1 = Convert.ToInt32( dt.Rows[0]["mob_no1"].ToString());
                profile.mob_no2 = Convert.ToInt32( dt.Rows[0]["mob_no2"].ToString());
                profile.yk_id = dt.Rows[0]["yk_id"].ToString();
                profile.path =  dt.Rows[0]["img"].ToString();
                profile.myfield = myfield.my_field(Convert.ToInt32(dt.Rows[0]["yk_id"].ToString()));
                
                
                
                
            }
            return profile;
        }

        public int apv(int profile_id)
        {
            yuva = new yuva();
            int i=yuva.ins("update profile set isapv='1' where id='"+ profile_id +"' ");
            return i;
        }
        public List<profile> apv_remain()
        {
            yuva = new yuva();
            fields myfield = new fields();
            List<profile> apv_list = new List<profile>();
            DataTable dt;
            dt = yuva.datatables("select * from profile where isapv=0 and fname is not null and fname!=''");
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++) {
                    apv_list.Add(
                        new profile
                        {
                            id = dt.Rows[i]["id"].ToString(),
                            fname = dt.Rows[i]["fname"].ToString(),
                            mname = dt.Rows[i]["mname"].ToString(),
                            lname = dt.Rows[i]["lname"].ToString(),
                            address = dt.Rows[i]["address"].ToString(),
                            dob = dt.Rows[i]["dob"].ToString(),
                            mob_no1 = Convert.ToInt32( dt.Rows[i]["mob_no1"].ToString()),
                            yk_id = dt.Rows[i]["yk_id"].ToString(),
                            myfield= myfield.my_field(Convert.ToInt32(dt.Rows[i]["yk_id"].ToString())),


                }
                        );
                   
                }
            }
            return apv_list;
        }
      
    }
}