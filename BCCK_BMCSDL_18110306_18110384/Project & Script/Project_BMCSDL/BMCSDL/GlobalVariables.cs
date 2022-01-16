using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMCSDL
{
    public static class GlobalVariables
    {
        public static int GlobalUserID { get; private set; }

        // GlobalInt can be changed only via this method
        public static void SetGlobalInt(int userId)
        {
            GlobalUserID = userId;
        }

        public static string GlobalUserName { get; private set; }

        // GlobalInt can be changed only via this method
        public static void setGlobalUserName(string userName)
        {
            GlobalUserName = userName;
        }

        public static string GlobalPassword { get; private set; }

        // GlobalInt can be changed only via this method
        public static void setGlobalPassword(string password)
        {
            GlobalPassword = password;
        }
    }
}
