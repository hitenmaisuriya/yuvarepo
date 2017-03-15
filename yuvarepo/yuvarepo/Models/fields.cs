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
        public int f_id { get; set; }
        public string name { get; set; }
        [Required]
        public string type { get; set; }
        [Required]
        public string yuvakendra { get; set; }
       
        public string group { get; set; }
        public string videokendra { get; set; }
        public string sector { get; set; }
       
      
        public int sec_id { get; set; }
        public int vk_id { get; set; }
        public int grp_id { get; set; }
        public int yk_id { get; set; }
        public List<fields> inner_field { get; set; }
        
        



        private yuva yuva;
        public int field_ins(fields obj)
        {
            yuva = new yuva();
            int i= yuva.ins("insert into field (name,type,sec_id,vk_id,grp_id,yk_id)values('" + obj.name + "','"+obj.type+"','"+obj.sec_id+"','"+obj.vk_id+"','"+obj.grp_id+"','"+obj.yk_id+"')");
            return i;
        }
       
        public fields yk(int yk_id)
        {
            yuva = new yuva();
            DataTable dt;
            fields field_list = new fields();

            dt = yuva.datatables("SELECT s.name as sector ,s.f_id,v.name as video_kendra,v.f_id,g.name  as grp ,g.f_id,yk.name as yuva_kendra,yk.f_id from field_master s,field_master v,field_master g,field_master yk where s.f_id=v.parent and v.f_id=g.parent and g.f_id=yk.parent and yk.f_id='"+yk_id+"'");

            field_list.yuvakendra = dt.Rows[0]["yuva_kendra"].ToString();
            field_list.group = dt.Rows[0]["grp"].ToString();
            field_list.videokendra = dt.Rows[0]["video_kendra"].ToString();
            field_list.sector = dt.Rows[0]["sector"].ToString();

            return field_list;

        }

        public string my_field(int yk_id)
        {
            yuva = new yuva();
            DataTable dt;
            fields field_list = new fields();

            dt = yuva.datatables("SELECT s.name as sector ,s.f_id,v.name as video_kendra,v.f_id,g.name  as grp ,g.f_id,yk.name as yuva_kendra,yk.f_id from field_master s,field_master v,field_master g,field_master yk where s.f_id=v.parent and v.f_id=g.parent and g.f_id=yk.parent and yk.f_id='" + yk_id + "'");

            string my_field = dt.Rows[0]["sector"].ToString() +" | "+ dt.Rows[0]["video_kendra"].ToString() + " | " + dt.Rows[0]["grp"].ToString() + " | " + dt.Rows[0]["yuva_kendra"].ToString();
            return my_field;
            
            

           

        }

        public List<fields> all_field()
        {
            yuva = new yuva();
            DataTable dt;
            List<fields> field_list = new List<fields>();

            dt = yuva.datatables("select * from field_master where parent is null or parent='' ");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                field_list.Add(
                    new fields
                    {
                        sec_id = Convert.ToInt32(dt.Rows[i]["f_id"].ToString()),
                        f_id = Convert.ToInt32(dt.Rows[i]["f_id"].ToString()),
                        name = dt.Rows[i]["name"].ToString(),
                        type = "sector",
                        sector= dt.Rows[i]["name"].ToString(),
                        inner_field = all_vk(Convert.ToInt32(dt.Rows[i]["f_id"].ToString()), dt.Rows[i]["name"].ToString()),
                    }
                    );
            }
            return field_list;

        }

        public List<fields> all_vk(int sec_id,string sector_name)
        {
            yuva = new yuva();
            DataTable dt;
            List<fields> field_list = new List<fields>();

            dt = yuva.datatables("select * from field_master where parent='" + sec_id + "' ");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                field_list.Add(
                    new fields
                    {
                        sec_id = Convert.ToInt32(dt.Rows[i]["parent"].ToString()),
                        vk_id = Convert.ToInt32(dt.Rows[i]["f_id"].ToString()),
                        f_id = Convert.ToInt32(dt.Rows[i]["f_id"].ToString()),
                        name = dt.Rows[i]["name"].ToString(),
                        type = "video kendra",
                        videokendra= dt.Rows[i]["name"].ToString(),
                        sector=sector_name,
                        inner_field = all_grp(Convert.ToInt32(dt.Rows[i]["parent"].ToString()), Convert.ToInt32(dt.Rows[i]["f_id"].ToString()), dt.Rows[i]["name"].ToString(),sector_name),
                    }
                    );
            }
            return field_list;

        }

        public List<fields> all_grp(int sec_id,int vk_id,string video_kendra,string sector_name)
        {
            yuva = new yuva();
            DataTable dt;
            List<fields> field_list = new List<fields>();

            dt = yuva.datatables("select * from field_master where parent='" + vk_id + "' ");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                field_list.Add(
                    new fields
                    {
                        sec_id = sec_id,
                        vk_id = Convert.ToInt32(dt.Rows[i]["parent"].ToString()),
                        grp_id = Convert.ToInt32(dt.Rows[i]["f_id"].ToString()),
                        f_id = Convert.ToInt32(dt.Rows[i]["f_id"].ToString()),
                        name = dt.Rows[i]["name"].ToString(),
                        type = "Group",
                        group = dt.Rows[i]["name"].ToString(),
                        videokendra = video_kendra,
                        sector=sector_name,
                        inner_field = all_yk(sec_id, Convert.ToInt32(dt.Rows[i]["parent"].ToString()), Convert.ToInt32(dt.Rows[i]["f_id"].ToString()), dt.Rows[i]["name"].ToString(),video_kendra,sector_name),
                    }
                    );
            }
            return field_list;

        }

        public List<fields> all_yk(int sec_id, int vk_id,int grp_id,string grp_name,string video_kendra,string sector_name)
        {
            yuva = new yuva();
            DataTable dt;
            List<fields> field_list = new List<fields>();

            dt = yuva.datatables("select * from field_master where parent='" + grp_id + "' ");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                field_list.Add(
                    new fields
                    {
                        sec_id = sec_id,
                        vk_id = vk_id,
                        grp_id = Convert.ToInt32(dt.Rows[i]["parent"].ToString()),
                        yk_id = Convert.ToInt32(dt.Rows[i]["f_id"].ToString()),
                        f_id = Convert.ToInt32(dt.Rows[i]["f_id"].ToString()),

                        name = dt.Rows[i]["name"].ToString(),
                        type = "Yuva Kendra",
                        yuvakendra= dt.Rows[i]["name"].ToString(),
                        group = grp_name,
                        videokendra = video_kendra,
                        sector = sector_name,

                    }
                    );
            }

            return field_list;
        }
    }
    
}