using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace SqlFastQuery
{
    class MySqlConnector
    {
        public static bool TestConnect(string conStr)
        {
            using (MySqlConnection con = new MySqlConnection(conStr))
            {
                try
                {
                    con.Open();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "连接数据库错误");
                    return false;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public static DataTable GetData(string conStr,string sql)
        {
            using (MySqlConnection con = new MySqlConnection(conStr))
            {
                DataSet ds = new DataSet();
                try
                {
                    con.Open();
                    MySqlDataAdapter dapt = new MySqlDataAdapter(sql, con);
                    dapt.Fill(ds);
                    return ds.Tables[0];
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }

            }
        }


        public static int ExecuteNonQuery(string conStr,string sql)
        {
            using (MySqlConnection con = new MySqlConnection(conStr))
            {
                DataSet ds = new DataSet();
                try
                {
                    con.Open();
                    var cmd = con.CreateCommand();
                    cmd.CommandText = sql;
                    return cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}
