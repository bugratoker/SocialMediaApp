using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Entities
{
    public class Like
    {
        //public int Id { get; set; }
        public Guid PostId { get; set; }
        //posta sahip olan userın idsi
        public int LikedUserId { get; set; }
        //beğenen kullanıcının idsi
        public int UserId { get; set; }
        

    }
}
