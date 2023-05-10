using CleanArchitecture.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Entities
{
    public class User : AuditableBaseEntity
    {
        public UserRoles UserType { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public Boolean EmailConfirmed { get; set; }
        public List<User> Followings { get; set; }
        public List<User> Followers { get; set; }

    }
}
