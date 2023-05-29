using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.User.Commands.FollowUser
{
    public class FollowUserCommand : IRequest<Response<int>>
    {
        public int UserId { get; set; }
        public int FollowedUserId { get; set; }

    }
    public class FollowUserCommandHandler : IRequestHandler<FollowUserCommand, Response<int>>
    {
        public readonly IUserRepositoryAsync _userRepositoryAsync;
        public readonly IFollowerRepositoryAsync _followerRepositoryAsync;
        public FollowUserCommandHandler(IUserRepositoryAsync userRepositoryAsync, IFollowerRepositoryAsync followerRepositoryAsync)
        {
            _userRepositoryAsync = userRepositoryAsync;
            _followerRepositoryAsync = followerRepositoryAsync;
        }

        public async Task<Response<int>> Handle(FollowUserCommand request, CancellationToken cancellationToken)
        {
                var follower = await _followerRepositoryAsync.AddAsync(new Entities.Follower { 
                    UserId = request.UserId,
                    FollowedUserId= request.FollowedUserId });


            return new Response<int>(follower.FollowedUserId,
                message:$"user with id {follower.UserId} followed user with id {follower.FollowedUserId}");
        }
    }
}
