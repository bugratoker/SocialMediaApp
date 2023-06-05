using CleanArchitecture.Core.Features.Spaces.Commands;
using CleanArchitecture.Core.Features.Spaces.Queries;
using CleanArchitecture.Core.Features.User.Commands.UploadUserProfilePhoto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CleanArchitecture.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [Authorize]
    public class SpaceController : BaseApiController
    {

        //AddSpace
        [HttpPost("CreateSpace/{spaceName}")]
        public async Task<IActionResult> CreateSpace(string spaceName)
        {

            var result = await Mediator.Send(new CreateSpaceCommand
            {
                SpaceName = spaceName
            });

            return Ok(result);
        }
        [HttpGet("GetSpacePosts/{spaceName}")]
        public async Task<IActionResult> GetSpacePostByName(string spaceName)
        {

            var result = await Mediator.Send(new GetPostsOfSpaceBySpaceNameQuery
            {
                SpaceName = spaceName
            });

            return Ok(result);
        }

        //GetPosts
    }
}
