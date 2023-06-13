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

namespace CleanArchitecture.Core.Features.Likes.Commands.LikePost
{
    public class LikePostCommand : IRequest<Response<Like>>
    {
        public string PostId { get; set; }
        public int UserId { get; set; }
    }
    public class LikePostCommandHandler : IRequestHandler<LikePostCommand, Response<Like>>
    {
        private readonly ILikeRepositoryAsync _likeRepository;
        private readonly IUserRepositoryAsync _userRepository;
        private readonly IPostRepositoryAsync _postRepository;
        public LikePostCommandHandler(ILikeRepositoryAsync likeRepository, IUserRepositoryAsync userRepository, IPostRepositoryAsync postRepository)
        {
            _likeRepository = likeRepository;
            _userRepository = userRepository;
            _postRepository = postRepository;
        }

        public async Task<Response<Like>> Handle(LikePostCommand request, CancellationToken cancellationToken)
        {
            Guid guid = new(request.PostId);
            var post = await _postRepository.GetByGuidAsync(guid);
            var likedUser =await _userRepository.FindByAccountId(post.AccountId);

            var like = await _likeRepository.AddAsync(new Like { UserId = request.UserId, PostId = guid, LikedUserId = likedUser.Id });
            
            return new Response<Like>(like,message:$"user {request.UserId} liked post {request.PostId}");
        }
    }

}
