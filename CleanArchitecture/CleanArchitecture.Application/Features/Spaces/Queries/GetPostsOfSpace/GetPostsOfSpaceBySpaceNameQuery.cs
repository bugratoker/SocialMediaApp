using AutoMapper;
using CleanArchitecture.Core.DTOs.Post;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.Spaces.Queries.GetPostsOfSpace
{
    public class GetPostsOfSpaceBySpaceNameQuery : IRequest<Response<List<PostViewModel>>>
    {
        public string SpaceName { get; set; }
    }
    public class GetPostsOfSpaceBySpaceNameQueryHandler : IRequestHandler<GetPostsOfSpaceBySpaceNameQuery
                                                                         , Response<List<PostViewModel>>>
    {
        private readonly ISpaceRepositoryAsync _spaceRepositoryAsync;
        private readonly IMapper _mapper;
        public GetPostsOfSpaceBySpaceNameQueryHandler(ISpaceRepositoryAsync spaceRepositoryAsync, IMapper mapper)
        {
            _spaceRepositoryAsync = spaceRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<List<PostViewModel>>> Handle(GetPostsOfSpaceBySpaceNameQuery request, CancellationToken cancellationToken)
        {
            
            var posts = await _spaceRepositoryAsync.GetPostsOfSpace(request.SpaceName);
            //                           source         destination      source
            var postViews = _mapper.Map<List<Post>, List<PostViewModel>>(posts);

            return new Response<List<PostViewModel>>(postViews, message: "posts fetched successfully");
        }
    }
}
