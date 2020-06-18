using System;
using System.Collections.Generic;
using System.Text;

namespace OSBB.Security.Identity
{
    public class ProjectManager
        : Client
    {
        public ProjectManager(int userId, string name, int catalogId) 
            : base(userId, name, catalogId, nameof(ProjectManager))
        {
        }
    }
}
