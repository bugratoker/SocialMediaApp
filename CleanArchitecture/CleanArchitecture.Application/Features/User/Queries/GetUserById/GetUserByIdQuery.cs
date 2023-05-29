using CleanArchitecture.Core.Exceptions;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.User.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<Response<Entities.User>>
    {
        public int Id { get; set; }
    }

    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Response<Entities.User>>
    {
        public readonly IUserRepositoryAsync _userRepositoryAsync;
        public GetUserByIdQueryHandler(IUserRepositoryAsync userRepositoryAsync)
        {
            _userRepositoryAsync = userRepositoryAsync;
        }

        public async Task<Response<Entities.User>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {

            var user = await _userRepositoryAsync.GetByIdAsync(request.Id);
            return user == null ? throw new ApiException($"User Not Found.")
                            : new Response<Entities.User>(user, message: "true");
        }
    }
}
