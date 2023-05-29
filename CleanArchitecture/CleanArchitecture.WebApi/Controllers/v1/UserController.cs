using CleanArchitecture.Core.Features.Products.Commands.CreateProduct;
using CleanArchitecture.Core.Features.User.Commands.CreateUser;
using CleanArchitecture.Core.Features.User.Commands.DeleteUserById;
using CleanArchitecture.Core.Features.User.Commands.FollowUser;
using CleanArchitecture.Core.Features.User.Commands.UploadUserPhoto;
using CleanArchitecture.Core.Features.User.Queries.GetFollowersOfUsersByUsername;
using CleanArchitecture.Core.Features.User.Queries.GetUserByUsername;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace CleanArchitecture.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class UserController : BaseApiController
    {
        #region Create User
        [HttpPost("CreateUser")]
        public async Task<IActionResult> Post(CreateUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        #endregion
        #region Remove User
        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> RemoveUser(string email, string password)
        {
            return Ok(await Mediator.Send(new DeleteUserCommand { Email = email, Password = password }));
        }
        #endregion
        #region Upload Image
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
        #endregion
        #region Follow User
        [HttpPost("{userId}/{followedUserId}/FollowUser")]
        public async Task<IActionResult> FollowUser(int userId,int followedUserId)
        {


            return Ok(await Mediator.Send(new FollowUserCommand { 
                UserId = userId, 
                FollowedUserId = followedUserId }));
        }
        #endregion
        #region Get User By Username

        [HttpGet("{username}/GetByUsername")]
        public async Task<IActionResult> GetUserByUsername(string username)
        {
            return Ok(await Mediator.Send(new GetUserByUsernameQuery { Username = username }));
        }



        #endregion
        #region Get Followers of User By Username

        [HttpGet("{username}/GetFollowersByUsername")]
        public async Task<IActionResult> GetFollowersByUsername(string username)
        {
            return Ok(await Mediator.Send(new GetFollowersOfUsersByUsernameQuery{ Username = username }));
        }

        #endregion
        
    }
}
