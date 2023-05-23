using CleanArchitecture.Core.Features.Products.Commands.CreateProduct;
using CleanArchitecture.Core.Features.User.Commands.CreateUser;
using CleanArchitecture.Core.Features.User.Commands.UploadUserPhoto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace CleanArchitecture.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class UserController : BaseApiController
    {

        [HttpPost("CreateUser")]
        public async Task<IActionResult> Post(CreateUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }



        [HttpPost("{id}/UploadUserImage")]
        public async Task<IActionResult> UploadImage(int id ,IFormFile formFile)
        {


            byte[] imageData;
            using (var stream =new MemoryStream())
            {
                formFile.CopyTo(stream);
                imageData = stream.ToArray();
            }

            var result = await Mediator.Send(new UploadUserPhotoCommand
            {
                ProductId = id,
                ImageData = imageData,
                ContentType = formFile.ContentType

            });
        
            return Ok(result);
        }
    }
}
