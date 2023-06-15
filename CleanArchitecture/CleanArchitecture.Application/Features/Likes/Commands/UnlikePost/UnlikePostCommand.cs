using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.Likes.Commands.UnlikePost
{
    public class UnlikePostCommand : IRequest<Response<Boolean>>
    {
        public string PostId  { get; set; }
        public int  UserId { get; set; }
    }
    public class UnlikePostCommandHandler : IRequestHandler<UnlikePostCommand,Response<Boolean>>
    {
        private readonly ILikeRepositoryAsync _likeRepository;

        public UnlikePostCommandHandler(ILikeRepositoryAsync likeRepository)
        {
            _likeRepository = likeRepository;
        }

        public async Task<Response<bool>> Handle(UnlikePostCommand request, CancellationToken cancellationToken)
        {
            var unlike = await _likeRepository.UnlikePostAsync(request.PostId, request.UserId);
            if (null != unlike)
            {
                return new Response<bool>(true,message:"succesfully unliked");
            }
            
            return new Response<bool>("an error occured unlike post");
        }
    }
}
