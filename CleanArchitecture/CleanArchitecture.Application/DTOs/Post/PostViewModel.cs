﻿using CleanArchitecture.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.DTOs.Post
{
    public class PostViewModel
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Photo { get; set; }
        public int AccountId { get; set; }
        public int SpaceId { get; set; }
        public ICollection<Like> Likes { get; set; }
        public int LikeCount { get; set; }
    }
}