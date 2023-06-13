using CleanArchitecture.Core.DTOs.Post;
using CleanArchitecture.Core.Features.Posts.Commands;
using CleanArchitecture.Core.Features.Posts.Commands.DeletePostById;
using CleanArchitecture.Core.Features.User.Commands.UploadUserProfilePhoto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace CleanArchitecture.WebApi.Controllers.v1
{
    
    [ApiVersion("1.0")]
    [Authorize]
    
    public class PostController : BaseApiController
    {
        #region Create Post
        [HttpPost("CreatePost")]
        public async Task<IActionResult> CreatePost([FromForm]CreatePostRequest createPostRequest)
        {
            byte[] imageData;
            using (var stream = new MemoryStream())
            {
                createPostRequest.formFile.CopyTo(stream);
                imageData = stream.ToArray();
            }

            var result = await Mediator.Send(new CreatePostCommand
            {
                UserId = createPostRequest.UserId,
                Photo = imageData,
                ContentType = createPostRequest.formFile.ContentType,
                Content = createPostRequest.Content,
                Description = createPostRequest.Description,
                SpaceId=createPostRequest.SpaceId,

            });



            return Ok(result);
        }
        #endregion

        #region DeletePost

        [HttpDelete("DeletePostById/{id}")]
        public async Task<IActionResult> DeletePost(string id)
        {

            return Ok(await Mediator.Send(new DeletePostByIdCommand { Id = id }));
        }
        #endregion
    }
}
