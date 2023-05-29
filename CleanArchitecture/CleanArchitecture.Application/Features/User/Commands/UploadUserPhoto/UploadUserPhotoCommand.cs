using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.User.Commands.UploadUserPhoto
{
    public class UploadUserPhotoCommand : IRequest<Response<string>>
    {
        public byte[] ImageData { get; set; }
        public string ContentType { get; set; }
        public int ProductId { get; set; } 
        

    }
    public class UploadUserPhotoCommandHandler : IRequestHandler<UploadUserPhotoCommand,Response<string>> 
    {
        private readonly IAzureStorageService _azureStorageService;
        private readonly ILogger<UploadUserPhotoCommandHandler> _logger;
        public UploadUserPhotoCommandHandler(IAzureStorageService azureStorageService, ILogger<UploadUserPhotoCommandHandler> logger)
        {
            _azureStorageService = azureStorageService;
            _logger = logger;
        }
        public async Task<Response<string>> Handle(UploadUserPhotoCommand request, CancellationToken cancellationToken)
        {
            var response = await 
                _azureStorageService.UploadUserImageToBlob(request.ImageData,request.ContentType);
            _logger.LogInformation($"id : {request.ProductId} added and url :{response}" );
            
            return new Response<string> { Data = response,Message= $"id : {request.ProductId} added and url :{response}" };
        }


    }
}
