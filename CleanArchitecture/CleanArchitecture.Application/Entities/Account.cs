using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Entities
{
    public class Account : AuditableBaseEntity
    {
        public List<Post> Posts { get; set; }



    }
}
