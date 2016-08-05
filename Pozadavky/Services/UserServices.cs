using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pozadavky.Services
{
    public static class UserServices
    {
        public static string GetActiveUser()
        {
            try
            {
                return RemoveDomain(System.Security.Principal.WindowsIdentity.GetCurrent().Name);
            }
            catch (Exception e)
            {
                return "Nemohu zjistit aktualniho uzivatele: " + e.Message;
            }
           
        }

        private static string RemoveDomain(string user)
        {
            return (user.Substring(user.LastIndexOf('\\') + 1)) ?? "";
        }

    }
}
