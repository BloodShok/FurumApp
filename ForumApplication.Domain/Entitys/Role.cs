using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApplication.Domain.Entitys
{
    public class Role : IdentityRole
    {
        public Role() {}

        public Role(string role) : base(role)
        {

        }
    }
}
