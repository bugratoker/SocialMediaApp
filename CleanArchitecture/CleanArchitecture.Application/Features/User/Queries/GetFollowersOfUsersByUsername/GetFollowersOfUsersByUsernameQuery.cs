using AutoMapper;
using CleanArchitecture.Core.DTOs.User;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.User.Queries.GetFollowersOfUsersByUsername
{
    public class GetFollowersOfUsersByUsernameQuery : IRequest<Response<List<UserDTO>>>
    {
        public string Username { get; set; }

    }
    public class GetFollowersOfUsersByUsernameQueryHandler
        : IRequestHandler<GetFollowersOfUsersByUsernameQuery, Response<List<UserDTO>>>
    {
        private readonly IUserRepositoryAsync _userRepositoryAsync;
        private readonly IMapper _mapper;
        public GetFollowersOfUsersByUsernameQueryHandler(IUserRepositoryAsync userRepositoryAsync, IMapper mapper)
        {
            _userRepositoryAsync = userRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<List<UserDTO>>> Handle(GetFollowersOfUsersByUsernameQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepositoryAsync.GetByUsernameAsync(request.Username);
            var followersFollower = user.Followers.ToList();
            var followersIds= followersFollower.Select(x=>x.FollowedUserId).ToList();
            List<UserDTO> users = new();
            foreach (var id in followersIds)
            {
                users.Add(_mapper.Map<UserDTO>(await _userRepositoryAsync.GetByIdAsync(id)));
            }
            return new Response<List<UserDTO>>(users);
        }
    }
}