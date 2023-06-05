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
        public UserRoles UserType { get; set; } = UserRoles.RegisteredUser;
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ProfilePhoto { get; set; }
        public bool EmailConfirmed { get; set; }
        public Account Account { get; set; }

        public ICollection<Follower> Followers { get;set;} 
        

    }
}
