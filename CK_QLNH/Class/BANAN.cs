﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK_QLNH
{
    class BANAN
    {
        DataBase db = new DataBase();

        // create a function to insert BanAn
        public bool insertBanAn(string Id, string tenban, int soluong, int tinhtrang)
        {
            SqlCommand command = new SqlCommand(" INSERT INTO QLBanAn (Id, tenban, soluong, tinhtrang) " +
                " VALUES (@id, @tenb, @sl, @tt) ", db.GetConnection);

            command.Parameters.Add("@id", SqlDbType.VarChar).Value = Id;
            command.Parameters.Add("@tenb", SqlDbType.VarChar).Value = tenban;
            command.Parameters.Add("@sl", SqlDbType.Int).Value = soluong;
            command.Parameters.Add("@tt", SqlDbType.Int).Value = tinhtrang;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }

        // check name
        public bool checkTenBanAn(string Id)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM QLBanAn WHERE Id = @id", db.GetConnection);
            command.Parameters.Add("@id", SqlDbType.VarChar).Value = Id;          
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                db.closeConnection();
                return false;
            }
            else
            {
                db.closeConnection();
                return true;
            }
        }

        public bool deleteBanAn(string id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM QLBanAn WHERE id=@id", db.GetConnection);
            command.Parameters.Add("id", SqlDbType.VarChar).Value = id;
            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;

            }
            else
            {
                db.closeConnection();
                return false;
            }
        }

        public bool updateBanAn(string id, string tenban, int soluong, int tinhtrang)
        {
            SqlCommand command = new SqlCommand(" UPDATE QLBanAn SET soluong=@sl, tinhtrang=@tt, tenban=@tenb WHERE id= @id", db.GetConnection);

            command.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
            command.Parameters.Add("@tenb", SqlDbType.VarChar).Value = tenban;
            command.Parameters.Add("@sl", SqlDbType.Int).Value = soluong;
            command.Parameters.Add("@tt", SqlDbType.Int).Value = tinhtrang;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }
        public bool updateBanAnTrong(string Id, int tinhtrang)
        {
            SqlCommand command = new SqlCommand("UPDATE QLBanAn SET tinhtrang=@tt  WHERE id=@Id", db.GetConnection);
            command.Parameters.Add("@id", SqlDbType.VarChar).Value = Id;
            command.Parameters.Add("@tt", SqlDbType.Int).Value = tinhtrang;

            db.openConnection();
            if ((command.ExecuteNonQuery() == 1))
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }
        public bool updateBanAnDaDat(string Id, int tinhtrang, string thoigian)
        {
            SqlCommand command = new SqlCommand("UPDATE QLBanAn SET tinhtrang=@tt, thoigian=@datban  WHERE id=@Id", db.GetConnection);
            command.Parameters.Add("@id", SqlDbType.VarChar).Value = Id;
            command.Parameters.Add("@tt", SqlDbType.Int).Value = tinhtrang;
            command.Parameters.Add("@datban", SqlDbType.NVarChar).Value = thoigian;

            db.openConnection();
            if ((command.ExecuteNonQuery() == 1))
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }

        public bool updateBanAnDaDat(string Id, int tinhtrang, DateTime thoigian)
        {
            SqlCommand command = new SqlCommand("UPDATE QLBanAn SET tinhtrang=@tt, thoigian=@datban  WHERE id=@Id", db.GetConnection);
            command.Parameters.Add("@id", SqlDbType.VarChar).Value = Id;
            command.Parameters.Add("@tt", SqlDbType.Int).Value = tinhtrang;
            command.Parameters.Add("@datban", SqlDbType.DateTime).Value = thoigian;

            db.openConnection();
            if ((command.ExecuteNonQuery() == 1))
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }
        public bool updateDatBan(string Id, DateTime thoigian)
        {
            SqlCommand command = new SqlCommand("UPDATE QLBanAn SET thoigian=@thoigian WHERE id=@Id", db.GetConnection);
            command.Parameters.Add("@id", SqlDbType.VarChar).Value = Id;
            command.Parameters.Add("@thoigian", SqlDbType.DateTime).Value = thoigian;

            db.openConnection();
            if ((command.ExecuteNonQuery() == 1))
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }
        public DataTable getBanAn(SqlCommand command)
        {
            command.Connection = db.GetConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable getBanTrong()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM QLBanAn WHERE tinhtrang = 0", db.GetConnection);
            command.Connection = db.GetConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public bool insertDoanhThuBan(string idban, int giatien, DateTime date)
        {
            SqlCommand command = new SqlCommand(" INSERT INTO DoanhThuBan (idban, sotien, date) " +
                " VALUES ( @tenb, @sl,@dt) ", db.GetConnection);

            command.Parameters.Add("@tenb", SqlDbType.VarChar).Value = idban;
            command.Parameters.Add("@sl", SqlDbType.Int).Value = giatien;
            command.Parameters.Add("@dt", SqlDbType.DateTime).Value = date;
            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }
    }
}
