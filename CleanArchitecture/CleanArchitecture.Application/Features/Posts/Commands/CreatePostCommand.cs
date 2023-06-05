using AutoMapper;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.Posts.Commands
{
    public class CreatePostCommand : IRequest<Response<Post>> { 
        public string Description { get; set; }
        public string Content { get; set; }
        public byte[] Photo { get; set; }
        public string ContentType { get; set; }
        public int UserId { get; set; }
        public int SpaceId { get; set; }

    }

    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Response<Post>>
    {
        private readonly IPostRepositoryAsync _postRepositoryAsync;
        private readonly IUserRepositoryAsync _userRepositoryAsync;
        private readonly IMapper _mapper;
        private readonly IAzureStorageService _azureStorageService;
        private readonly IAccountRepositoryAsync _accountRepositoryAsync;

        public CreatePostCommandHandler(IPostRepositoryAsync postRepositoryAsync, IUserRepositoryAsync userRepositoryAsync, IMapper mapper, IAzureStorageService azureStorageService, IAccountRepositoryAsync accountRepositoryAsync)
        {

            _postRepositoryAsync = postRepositoryAsync;
            _userRepositoryAsync = userRepositoryAsync;
            _mapper = mapper;
            _azureStorageService = azureStorageService;
            _accountRepositoryAsync = accountRepositoryAsync;
        }

        public async Task<Response<Post>> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            //var user =  await _userRepositoryAsync.GetByIdAsync(request.UserId);
            var responsePhotoUrl = await
               _azureStorageService.UploadUserImageToBlob(request.Photo, request.ContentType);

            var account = _accountRepositoryAsync.GetByUserIdAsync(request.UserId).Result;


            var post = _mapper.Map<Post>(new CreatePostViewModel {
                AccountId=account.Id,
                Content = request.Content,
                Photo = responsePhotoUrl,
                Description = request.Description,
                Created = DateTime.UtcNow,
                SpaceId=request.SpaceId
            });

            await _postRepositoryAsync.AddAsync(post);

            return new Response<Post>(post,message:"post uploaded successfully");

            
        }
    }


}
