﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK_QLNH
{
    class DataBase
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-7R66M1N\LEDIEPTRI;Initial Catalog=QuanLyNhaHang1;Integrated Security=True");
        public SqlConnection GetConnection
        {
            get
            {
                return con;
            }
        }
        // open the connection
        public void openConnection()
        {
            if ((con.State == ConnectionState.Closed))
            {
                con.Open();
            }
        }
        // close the connection
        public void closeConnection()
        {
            if ((con.State == ConnectionState.Open))
            {
                con.Close();
            }
        }
        public SqlDataReader ThucThiTraVe1Record(string sql) // phuong thuc lay ra 1 record
        {
            openConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            openConnection();
            SqlDataReader a = cmd.ExecuteReader();
            closeConnection();
            cmd.Dispose();
            return a;
        }
    }
}
