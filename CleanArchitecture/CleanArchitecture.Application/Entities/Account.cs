using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Entities
{
    public class Account : AuditableBaseEntity
    {
        public User User { get; set; }
        public int UserId { get; set; }
        public ICollection<Post> Posts { get; set; }
        



    }
}
