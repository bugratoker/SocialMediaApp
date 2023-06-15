using CleanArchitecture.Core.Features.Likes.Commands.LikePost;
using CleanArchitecture.Core.Features.Likes.Commands.UnlikePost;
using CleanArchitecture.Core.Features.User.Commands.CreateUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchitecture.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [Authorize]
    public class LikeController : BaseApiController
    {
        #region Like Post
        [HttpPost("LikePost")]
        public async Task<IActionResult> LikePost(LikePostCommand likePostCommand)
        {
            return Ok(await Mediator.Send(likePostCommand));
        }
        #endregion
        #region Unlike Post
        [HttpDelete("UnlikePost")]
        public async Task<IActionResult> UnlikePost(UnlikePostCommand unlikePostCommand)
        {
            return Ok(await Mediator.Send(unlikePostCommand));
        }
        #endregion
    }
}
