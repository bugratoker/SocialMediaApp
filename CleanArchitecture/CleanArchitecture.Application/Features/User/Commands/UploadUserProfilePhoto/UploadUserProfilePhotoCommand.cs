using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.User.Commands.UploadUserProfilePhoto
{
    public class UploadUserProfilePhotoCommand : IRequest<Response<string>>
    {
        public byte[] ImageData { get; set; }
        public string ContentType { get; set; }
        public int UserId { get; set; }


    }
    public class UploadUserProfilePhotoCommandHandler : IRequestHandler<UploadUserProfilePhotoCommand, Response<string>>
    {
        private readonly IAzureStorageService _azureStorageService;
        public readonly IUserRepositoryAsync _userRepositoryAsync;

        public UploadUserProfilePhotoCommandHandler(IAzureStorageService azureStorageService, IUserRepositoryAsync userRepositoryAsync)
        {
            _azureStorageService = azureStorageService;
            _userRepositoryAsync = userRepositoryAsync;
        }
        public async Task<Response<string>> Handle(UploadUserProfilePhotoCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepositoryAsync.GetByIdAsync(request.UserId);
            var response = await
                _azureStorageService.UploadUserImageToBlob(request.ImageData, request.ContentType);
            await _userRepositoryAsync.UpdateUserProfilePhoto(user.Username, response);
            return new Response<string> {Succeeded=true, Data = response, Message = $"id : {request.UserId} added and url :{response}" };
        }


    }
}
