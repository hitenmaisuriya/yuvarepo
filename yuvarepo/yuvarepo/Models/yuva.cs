using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

namespace yuvarepo.Models
{



    public class yuva
    {

        MySqlConnection c;
        MySqlCommand cmd;
        MySqlDataAdapter da;
        MySqlDataReader dr;
        DataSet ds;
        DataTable dt;
        public yuva()
        {
            c = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["yuva"].ConnectionString);
        }
        public void ins(string qt)
        {
            if (c.State == ConnectionState.Closed)
            {
                c.Open();

                cmd = new MySqlCommand(qt, c);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                c.Close();
            }
            else
            {

                cmd = new MySqlCommand(qt, c);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                c.Close();

            }


        }
        public DataTable datatables(string qt)
        {
            c.Open();
            da = new MySqlDataAdapter(qt, c);
            dt = new DataTable();
            da.Fill(dt);
            c.Close();
            return dt;






        }


        public DataSet datasets(string qt)
        {
            if (c.State == ConnectionState.Closed)
            {
                c.Open();
                da = new MySqlDataAdapter(qt, c);
                ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            else
            {
                da = new MySqlDataAdapter(qt, c);
                ds = new DataSet();
                da.Fill(ds);
                return ds;

            }
        }
        public MySqlDataReader datareader(string qt)
        {
            if (c.State == ConnectionState.Closed)
            {
                c.Open();
                cmd = new MySqlCommand(qt, c);
                dr = cmd.ExecuteReader();
                return dr;

            }
            else
            {
                cmd = new MySqlCommand(qt, c);
                dr = cmd.ExecuteReader();
                return dr;

            }
        }
    }
    
}
