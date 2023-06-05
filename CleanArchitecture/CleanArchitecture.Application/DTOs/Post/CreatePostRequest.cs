using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.DTOs.Post
{
    public class CreatePostRequest
    {
        public IFormFile formFile { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public int SpaceId { get; set; }



    }
}
