using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.ComponentModel.DataAnnotations;
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
      
      
        public string yk_id { get; set; }
        [Required]
        public string created_on { get; set; }
        public string updated_by { get; set; }
        public string img { get; set; }

        private yuva yuva;
        public int profile_ins(profile obj)
        {
           
          
            yuva = new yuva();
            int i = yuva.ins("update profile set fname='" + obj.fname + "',mname='" + obj.mname + "',lname='" + obj.lname + "',address='" + obj.address + "',dob='" + obj.dob + "',mob_no1=" + obj.mob_no1 + ",mob_no2=" + obj.mob_no2 + ",yk_id='" + obj.yk_id + "',updated_by='"+obj.updated_by+"',img='" + obj.img + "' where id='"+obj.id+"' ");
            return i;
        }
    }
}