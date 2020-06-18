using System;
using System.Collections.Generic;
using System.Text;

namespace OSBB.Security.Identity
{
    public class CEO
        : Client
    {
        public CEO(int userId, string name, int catalogId) 
            : base(userId, name, catalogId, nameof(CEO))
        {
        }
    }
}
