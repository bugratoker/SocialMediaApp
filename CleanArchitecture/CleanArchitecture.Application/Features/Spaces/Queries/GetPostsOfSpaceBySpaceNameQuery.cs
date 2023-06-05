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

namespace CleanArchitecture.Core.Features.Spaces.Queries
{
    public class GetPostsOfSpaceBySpaceNameQuery : IRequest<Response<List<Post>>>
    {
        public string SpaceName { get; set; }
    }
    public class GetPostsOfSpaceBySpaceNameQueryHandler : IRequestHandler<GetPostsOfSpaceBySpaceNameQuery
                                                                         , Response<List<Post>>>
    {
        private readonly ISpaceRepositoryAsync _spaceRepositoryAsync;
        public GetPostsOfSpaceBySpaceNameQueryHandler(ISpaceRepositoryAsync spaceRepositoryAsync)
        {
            _spaceRepositoryAsync = spaceRepositoryAsync;
        }

        public async Task<Response<List<Post>>> Handle(GetPostsOfSpaceBySpaceNameQuery request, CancellationToken cancellationToken)
        {
            var posts = await _spaceRepositoryAsync.GetPostsOfSpace(request.SpaceName);

            return new Response<List<Post>>(posts, message: "posts fetched successfully");
        }
    }
}
