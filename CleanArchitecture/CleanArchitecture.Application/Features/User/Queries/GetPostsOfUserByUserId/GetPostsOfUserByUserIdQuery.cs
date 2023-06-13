using AutoMapper;
using CleanArchitecture.Core.DTOs.Post;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.User.Queries.GetPostsOfUserByUserId
{
    public class GetPostsOfUserByUserIdQuery : IRequest<Response<List<PostViewModel>>>
    {
        public int Id { get; set; }
    }
    public class GetPostsOfUserByUserIdQueryHandler : IRequestHandler<GetPostsOfUserByUserIdQuery, Response<List<PostViewModel>>>
    {
        private readonly IPostRepositoryAsync _postRepositoryAsync;
        private readonly IUserRepositoryAsync _userRepositoryAsync;
        private readonly IMapper _mapper;
        public GetPostsOfUserByUserIdQueryHandler(IPostRepositoryAsync postRepositoryAsync, IUserRepositoryAsync userRepositoryAsync, IMapper mapper)
        {
            _postRepositoryAsync = postRepositoryAsync;
            _userRepositoryAsync = userRepositoryAsync;
            _mapper = mapper;
        }
        public async Task<Response<List<PostViewModel>>> Handle(GetPostsOfUserByUserIdQuery request, CancellationToken cancellationToken)
        {

            var posts = await _userRepositoryAsync.GetPostsOfUserByUserId(request.Id);
            var postModels = _mapper.Map<List<Post>, List<PostViewModel>>(posts);
            return new Response<List<PostViewModel>>(postModels,message:"Posts listed successfully");
        }
    }
}
