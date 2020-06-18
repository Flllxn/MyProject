using System;
using System.Collections.Generic;
using System.Text;

namespace OSBB.Security.Identity
{
    public class Admin
        : Client
    {
        public Admin(int userId, string name, int catalogId) 
            : base(userId, name, catalogId, nameof(Admin))
        {
        }
    }
}
