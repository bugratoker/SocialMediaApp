using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Core.Exceptions;

namespace CleanArchitecture.Core.Features.User.Queries.GetUserByUsername
{
    public class GetUserByUsernameQuery : IRequest<Response<Entities.User>>
    {
        public string Username { get; set; }
    }

    public class GetUserByUsernameQueryHandler : IRequestHandler<GetUserByUsernameQuery, Response<Entities.User>>
    {
        public readonly IUserRepositoryAsync _userRepositoryAsync;
        public GetUserByUsernameQueryHandler(IUserRepositoryAsync userRepositoryAsync)
        {
            _userRepositoryAsync = userRepositoryAsync;
        }

        public async Task<Response<Entities.User>> Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
        {

            var user = await _userRepositoryAsync.GetByUsernameAsync(request.Username);
            return user == null ? throw new ApiException($"User Not Found.") 
                            : new Response<Entities.User>(user, message: "true");
        }
    }
}
