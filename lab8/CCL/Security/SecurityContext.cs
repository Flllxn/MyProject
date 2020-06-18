using OSBB.Security.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OSBB.Security
{
    public static class SecurityContext
    {
        static Client _user = null;

        public static Client GetUser()
        {
            return _user;
        }        public static void SetUser(Client user)
        {
            _user = user;
        }
    }
}
