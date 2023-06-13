using CleanArchitecture.Core.Features.Spaces.Commands;
using CleanArchitecture.Core.Features.Spaces.Queries.GetPostsOfSpace;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> CreateSpace(CreateSpaceCommand createSpaceCommand)  {

            var result = await Mediator.Send(createSpaceCommand);

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
