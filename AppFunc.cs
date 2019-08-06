using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SqlFastQuery
{
    class AppFunc
    {
        public static string GetSql(DbConStrInfo conStr, int type,string table_name="")
        {
            if (type == 1)
            {
                if (conStr.ProviderType ==  ProviderType.MySql)
                {
                    return string.Format("select * from information_schema.tables where table_schema='{0}'", conStr.Database);
                }
                if (conStr.ProviderType == ProviderType.SqlServer)
                {
                    return string.Format("select name as table_name from sys.objects where type='U' order by name");
                }
                if (conStr.ProviderType == ProviderType.Oracle)
                {
                    return "select table_name from user_tables";
                }
            }

            if (type == 2)
            {
                if (conStr.ProviderType == ProviderType.MySql)
                {
                    return string.Format("select * from information_schema.views where table_schema='{0}'", conStr.Database);
                }
                if (conStr.ProviderType == ProviderType.SqlServer)
                {
                    return string.Format("select name as table_name from sys.objects where type='V'  order by name");
                }
                if (conStr.ProviderType == ProviderType.Oracle)
                {
                    return "select * from user_views";
                }
            }

            if (type == 3)
            {
                if (conStr.ProviderType == ProviderType.MySql)
                {
                    return string.Format("select  * from information_schema.columns where table_schema='{0}' and table_name='{1}'",
                conStr.Database, table_name);
                }
                if (conStr.ProviderType == ProviderType.SqlServer)
                {
                    return string.Format("SELECT * FROM sys.columns WHERE OBJECT_ID = (SELECT id  FROM sys.sysobjects WHERE type IN ('U','V') AND name='{0}')", table_name);
                }
                if (conStr.ProviderType == ProviderType.Oracle)
                {
                    return string.Format("select * from USER_TAB_COLUMNS where table_name='{0}'", table_name);
                }
            }
            return "";
        }

        public static bool TestConnect(DbConStrInfo conStr)
        {
            if(conStr.ProviderType== ProviderType.MySql)
            {
                return MySqlConnector.TestConnect(conStr.ConStr);
            }
            else if (conStr.ProviderType == ProviderType.Oracle)
            {
                return OracleConnector.TestConnect(conStr.ConStr);
            }
            else
            {
                return SqlConnector.TestConnect(conStr.ConStr);
            }
        }

        public static DataTable GetData(DbConStrInfo conStr, string sql)
        {
            if (conStr.ProviderType == ProviderType.MySql)
            {
                return MySqlConnector.GetData(conStr.ConStr,sql);
            }
            else if (conStr.ProviderType == ProviderType.Oracle)
            {
                return OracleConnector.GetData(conStr.ConStr, sql);
            }
            else
            {
                return SqlConnector.GetData(conStr.ConStr, sql);
            }
        }

        public static int ExecuteNonQuery(DbConStrInfo conStr, string sql)
        {
            if (conStr.ProviderType == ProviderType.MySql)
            {
                return MySqlConnector.ExecuteNonQuery(conStr.ConStr, sql);
            }
            else if (conStr.ProviderType == ProviderType.Oracle)
            {
                return OracleConnector.ExecuteNonQuery(conStr.ConStr, sql);
            }
            else
            {
                return SqlConnector.ExecuteNonQuery(conStr.ConStr, sql);
            }

        }
    }
}
