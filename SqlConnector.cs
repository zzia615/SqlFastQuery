using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
namespace SqlFastQuery
{
    class SqlConnector
    {
        public static bool TestConnect(string conStr)
        {
            using (SqlConnection con = new SqlConnection(conStr))
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
            using (SqlConnection con = new SqlConnection(conStr))
            {
                DataSet ds = new DataSet();
                try
                {
                    con.Open();
                    SqlDataAdapter dapt = new SqlDataAdapter(sql, con);
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
            using (SqlConnection con = new SqlConnection(conStr))
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
