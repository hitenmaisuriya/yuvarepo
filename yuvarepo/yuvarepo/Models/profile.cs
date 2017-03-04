using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
namespace yuvarepo.Models
{
    public class profile
    {
        public string id { get; set; }
        public string fname { get; set; }
        public string mname { get; set; }
        public string lname { get; set; }
        public string address { get; set; }
        public string dob { get; set; }
        public string mob_no1 { get; set; }
        public string mob_no2{ get; set; }
      
      
        public string yk_id { get; set; }
        public string created_on { get; set; }
        public string updated_by { get; set; }
        public string img { get; set; }

        private yuva yuva;
        public int profile_ins(profile obj)
        {
            string dates = obj.dob;
            string year = dates.Substring(6, 4);

            string month = dates.Substring(0, 2);
            string days = dates.Substring(3, 2);
            string dob = year + "/" + month + "/" + days;
            yuva = new yuva();
            int i = yuva.ins("update profile set fname='" + obj.fname + "',mname='" + obj.mname + "',lname='" + obj.lname + "',address='" + obj.address + "',dob='" + dob + "',mob_no1='" + obj.mob_no1 + "',mob_no2='" + obj.mob_no2 + "',yk_id='" + obj.yk_id + "',updated_by='"+obj.updated_by+"',img='" + obj.img + "' where id='"+obj.id+"' ");
            return i;
        }
    }
}