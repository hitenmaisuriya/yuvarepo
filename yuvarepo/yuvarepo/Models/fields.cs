using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace yuvarepo.Models
{
    public class fields
    {
        public string f_id { get; set; }
        public string name { get; set; }
        [Required]
        public string type { get; set; }
        [Required]
        public int sec_id { get; set; }
        public int vk_id { get; set; }
        public int grp_id { get; set; }
        public int yk_id { get; set; }
        public List<fields> vk_list { get; set; }
        public List<fields> grp_list { get; set; }
        public List<fields> yk_list { get; set; }



        private yuva yuva;
        public int field_ins(fields obj)
        {
            yuva = new yuva();
            int i= yuva.ins("insert into field (name,type,sec_id,vk_id,grp_id,yk_id)values('" + obj.name + "','"+obj.type+"','"+obj.sec_id+"','"+obj.vk_id+"','"+obj.grp_id+"','"+obj.yk_id+"')");
            return i;
        }
       
        public List<fields> all_field()
        {
            yuva = new yuva();
            DataTable dt;
            List<fields> field_list = new List<fields>();

            dt = yuva.datatables("select id,name,type from field where type='sectore'");
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                field_list.Add(
                    new fields
                    {
                        sec_id = Convert.ToInt32(dt.Rows[i]["id"].ToString()),
                        name = dt.Rows[i]["name"].ToString(),
                        type = dt.Rows[i]["type"].ToString(),
                        vk_list = vk_lists(Convert.ToInt32(dt.Rows[i]["id"].ToString())),
                    }
                    );
            }
            return field_list;

        }
        public List<fields> vk_lists (int sec_id)
        {
            yuva = new yuva();
            DataTable dt;
            List<fields> field_list = new List<fields>();

            dt = yuva.datatables("select id,name,type,sec_id from field where type='vk' and sec_id='"+sec_id+"' ");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                field_list.Add(
                    new fields
                    {
                        sec_id = Convert.ToInt32(dt.Rows[i]["sec_id"].ToString()),
                        vk_id = Convert.ToInt32(dt.Rows[i]["id"].ToString()),
                        name = dt.Rows[i]["name"].ToString(),
                        type = dt.Rows[i]["type"].ToString(),
                        grp_list = grp_lists(Convert.ToInt32(dt.Rows[i]["id"].ToString())),
                    }
                    );
            }
            return field_list;

        }
        public List<fields> grp_lists(int vk_id)
        {
            yuva = new yuva();
            DataTable dt;
            List<fields> field_list = new List<fields>();

            dt = yuva.datatables("select id,name,type,sec_id,vk_id from field where type='grp' and vk_id='" + vk_id + "' ");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                field_list.Add(
                    new fields
                    {
                        sec_id = Convert.ToInt32(dt.Rows[i]["sec_id"].ToString()),
                        vk_id = Convert.ToInt32(dt.Rows[i]["vk_id"].ToString()),
                        grp_id = Convert.ToInt32(dt.Rows[i]["id"].ToString()),
                        name = dt.Rows[i]["name"].ToString(),
                        type = dt.Rows[i]["type"].ToString(),
                        grp_list =yk_lists(Convert.ToInt32(dt.Rows[i]["id"].ToString())),
                    }
                    );
            }
            return field_list;

        }
        public List<fields> yk_lists(int grp_id)
        {
            yuva = new yuva();
            DataTable dt;
            List<fields> field_list = new List<fields>();

            dt = yuva.datatables("select id,name,type,sec_id,vk_id,grp_id from field where type='yk' and grp_id='" + grp_id + "' ");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                field_list.Add(
                    new fields
                    {
                        sec_id = Convert.ToInt32(dt.Rows[i]["id"].ToString()),
                        name = dt.Rows[i]["name"].ToString(),
                        type = dt.Rows[i]["type"].ToString(),
                        
                    }
                    );
            }

            return field_list;
        }
    }
    
}