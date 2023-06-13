using CleanArchitecture.Core.Features.Spaces.Queries.GetPostsOfSpace;
using CleanArchitecture.Core.Features.User.Commands.CreateUser;
using CleanArchitecture.Core.Features.User.Commands.DeleteUserById;
using CleanArchitecture.Core.Features.User.Commands.FollowUser;
using CleanArchitecture.Core.Features.User.Commands.UploadUserPhoto;
using CleanArchitecture.Core.Features.User.Commands.UploadUserProfilePhoto;
using CleanArchitecture.Core.Features.User.Commands.UserAuthentication;
using CleanArchitecture.Core.Features.User.Queries.GetFollowersOfUsersByUsername;
using CleanArchitecture.Core.Features.User.Queries.GetPostsOfUserByUserId;
using CleanArchitecture.Core.Features.User.Queries.GetUserByUsername;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace CleanArchitecture.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [Authorize]
    public class UserController : BaseApiController
    {
        //examplesociospace.database.windows.net
        //tokerbugra
        //sociospace2023_
        //C:\Users\bugra\Downloads\CSE332_23B_Term_Project_Base\CSE332_23B_Term_Project\Backend\CleanArchitecture\CleanArchitecture.WebApi\CleanArchitecture.WebApi.xml
        #region Login
        [HttpPost("Login"),AllowAnonymous]
        public async Task<IActionResult> Login(UserAuthenticationCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        #endregion
        #region Create User
        [HttpPost("Register"),AllowAnonymous]
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
        #region Upload User Profile Photo
        [HttpPost("{id}/UploadUserProfilePhoto")]
        public async Task<IActionResult> UploadUserProfilePhoto(int id, IFormFile formFile)
        {


            byte[] imageData;
            using (var stream = new MemoryStream())
            {
                formFile.CopyTo(stream);
                imageData = stream.ToArray();
            }

            var result = await Mediator.Send(new UploadUserProfilePhotoCommand
            {
                UserId = id,
                ImageData = imageData,
                ContentType = formFile.ContentType

            });

            return Ok(result);
        }
        #endregion
        #region Get Posts of User
        [HttpGet("GetPostsOfUserByUserId/{userId}")]
        public async Task<IActionResult> GetPostsOfUser(int userId)
        {

            var result = await Mediator.Send(new GetPostsOfUserByUserIdQuery { Id=userId});

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
