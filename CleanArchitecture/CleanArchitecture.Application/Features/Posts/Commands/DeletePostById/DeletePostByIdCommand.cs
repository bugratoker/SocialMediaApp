using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.Posts.Commands.DeletePostById
{
    public class DeletePostByIdCommand : IRequest<Response<string>>
    {
        public string Id { get; set; }
    }
    public class DeletePostByIdCommandHandler : IRequestHandler<DeletePostByIdCommand,Response<string>>
    {
        private readonly IPostRepositoryAsync _postRepositoryAsync;
        public DeletePostByIdCommandHandler(IPostRepositoryAsync postRepositoryAsync)
        {
            _postRepositoryAsync = postRepositoryAsync;
        }

        public async Task<Response<string>> Handle(DeletePostByIdCommand request, CancellationToken cancellationToken)
        {
            var post = await _postRepositoryAsync.DeleteByIdAsync(request.Id);

            var id = Convert.ToString(post.Id);
            return new Response<string>(id, message: "successfully deleted");
        }
    }

}
