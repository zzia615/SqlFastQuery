using System;
using System.Collections.Generic;
using System.Text;

namespace SqlFastQuery
{
    public class DbConStrInfo
    {
        public string Server { get; set; }

        public string Port { get; set; }

        public string LogId { get; set; }

        public string LogPass { get; set; }

        public string Database { get; set; }

        public string ConStr
        {
            get
            {
                if (Provider == "MySql.Data.MySqlClient")
                {
                    return string.Format("server={0};port={1};userid={2};password={3};database={4}", Server, Port, LogId, LogPass, Database);
                }
                if (Provider == "System.Data.OracleClient")
                {
                    return string.Format("data source={0},{1};uid={2};pwd={3};", Server, Port, LogId, LogPass, Database);
                }
                else
                {
                    return string.Format("data source={0},{1};uid={2};pwd={3};database={4}", Server, Port, LogId, LogPass, Database);
                }

            }
        }
        public string Provider { get; set; }

        public ProviderType ProviderType
        {
            get
            {
                if (Provider == "MySql.Data.MySqlClient")
                {
                    return ProviderType.MySql;
                }
                if (Provider == "System.Data.OracleClient")
                {
                    return ProviderType.Oracle;
                }
                else
                {
                    return ProviderType.SqlServer;
                }
            }
        }
    }

    public enum ProviderType
    {
        MySql,SqlServer,Oracle
    }
}
