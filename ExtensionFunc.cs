using System;
using System.Collections.Generic;
using System.Text;

namespace System.Runtime.CompilerServices
{
    public class ExtensionAttribute : Attribute { }
}
namespace SqlFastQuery
{
    
    public static class ExtensionFunc
    {
        public static bool ContainsExtra(this string data,string contains)
        {
            bool ret = false;
            ret = data.Contains(string.Format("{0} ", contains));
            if (ret)
            {
                return ret;
            }

            ret = data.Contains(string.Format("{0}  ", contains));
            if (ret)
            {
                return ret;
            }
            ret = data.Contains(string.Format("{0}( ", contains));
            if (ret)
            {
                return ret;
            }
            return ret;
        }
    
        public static int IndexOfExtra(this string data, string indexof)
        {
            int ret = -1;
            ret = data.IndexOf(string.Format("{0} ", indexof));
            if (ret>=0)
            {
                return ret;
            }

            ret = data.IndexOf(string.Format("{0}   ", indexof));
            if (ret >= 0)
            {
                return ret;
            }

            ret = data.IndexOf(string.Format("{0}(", indexof));
            if (ret >= 0)
            {
                return ret;
            }

            return ret;
        }

        public static int IndexOfExtra(this string data, string indexof,int pos)
        {
            int ret = -1;
            ret = data.IndexOf(string.Format("{0} ", indexof), pos);
            if (ret >= 0)
            {
                return ret;
            }

            ret = data.IndexOf(string.Format("{0}   ", indexof), pos);
            if (ret >= 0)
            {
                return ret;
            }

            ret = data.IndexOf(string.Format("{0}(", indexof), pos);
            if (ret >= 0)
            {
                return ret;
            }

            return ret;
        }
    }
}
