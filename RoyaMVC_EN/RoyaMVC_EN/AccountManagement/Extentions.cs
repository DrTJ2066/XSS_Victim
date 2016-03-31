using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoyaMVC_EN
{
    public static class ExtentionsMethods
    {
        public static string GetPersianName(this System.Security.Principal.IPrincipal user) {
            return "نام و نام خانوادگی";
        }

        public static string GetPersianName2(this string str, int hh) {
            return "نام و نام خانوادگی" + hh.ToString();
        }
    }
}
