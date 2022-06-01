using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jeweler.EF;

namespace Jeweler.ClassHelper
{
    public static class UserSearch
    {
        public static bool GetUser(string login, string password) 
        {
            var user = AppData.Context.User.ToList().
               Where(i => i.UserLogin == login && i.UserPassword == password).
               FirstOrDefault();

            if (user != null)
            {
                AppData.userData = user;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
