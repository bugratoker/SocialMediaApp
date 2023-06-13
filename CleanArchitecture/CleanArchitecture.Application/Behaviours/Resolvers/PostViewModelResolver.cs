using AutoMapper;
using CleanArchitecture.Core.DTOs.Post;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Behaviours.Resolvers
{
    public class PostViewModelResolver : IValueResolver<Post, PostViewModel, int>
    {
        private readonly IPostRepositoryAsync _postRepositoryAsync;
        
        public PostViewModelResolver(IPostRepositoryAsync postRepositoryAsync)
        {
            _postRepositoryAsync = postRepositoryAsync;
            
        }

        public int Resolve(Post source, PostViewModel destination, int destMember, ResolutionContext context)
        {
            //Result would block thread until the task had completed. Avoid from that but here is mandatory 
            return _postRepositoryAsync.GetLikeCountOfPost(source.Id).Result; 
        }
    }
}