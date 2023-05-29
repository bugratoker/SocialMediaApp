using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Entities
{
    public class Follower
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public int FollowedUserId { get; set; }


    }
}
