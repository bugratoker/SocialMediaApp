using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Entities
{
    public class Post 
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Photo { get; set; }
        public Account Account{ get; set; }
        public int AccountId { get; set; }
        public Space Space { get; set; }
        public int SpaceId { get; set; }

    }
}
