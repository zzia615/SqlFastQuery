using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Text;
using System.Windows.Forms;
namespace SqlFastQuery
{
    class OracleConnector
    {
        public static bool TestConnect(string conStr)
        {
            using (OracleConnection con = new OracleConnection(conStr))
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
            using (OracleConnection con = new OracleConnection(conStr))
            {
                DataSet ds = new DataSet();
                try
                {
                    con.Open();
                    OracleDataAdapter dapt = new OracleDataAdapter(sql, con);
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
            using (OracleConnection con = new OracleConnection(conStr))
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
