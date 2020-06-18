using System;
using System.Collections.Generic;
using System.Text;

namespace OSBB.Security.Identity
{
    public abstract class Client
    {
        public Client(int userId, string name, int catalogId, string userType)
        {
            UserId = userId;
            Name = name;
            CatalogID = catalogId;
            UserType = userType;
        }
        public int UserId { get; }
        public string Name { get; }
        public int CatalogID { get; }
        protected string UserType { get; }
    }
}
