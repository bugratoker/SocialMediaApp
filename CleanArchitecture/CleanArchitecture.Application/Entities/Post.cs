using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Entities
{
    public class Post : AuditableBaseEntity
    {

        public string Description { get; set; }
        public string Content { get; set; }
        public Blob Photo{ get; set; }
        public User Holder { get; set; }
    }
}
