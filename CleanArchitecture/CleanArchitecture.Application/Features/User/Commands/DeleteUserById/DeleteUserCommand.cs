using AutoMapper;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.User.Commands.DeleteUserById
{
    public partial class DeleteUserCommand : IRequest<Response<int>>
    {

        public string Email { get; set; }
        public string Password { get; set; }


    }
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Response<int>>
    {
        private readonly IUserRepositoryAsync _userRepository;
        private readonly IMapper _mapper;
        public DeleteUserCommandHandler(IUserRepositoryAsync userRepositoryAsync, IMapper mapper)
        {
            _userRepository = userRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetByEmailAsync(request.Email).Result;
            if (user.Password == request.Password) {   
                await _userRepository.DeleteAsync(user);
                return new Response<int>(user.Id, message: $"user added id : {user.Id}, name : {user.Name}");
            }
            else
            {
                return new Response<int>(message: $"user cannot added id : {user.Id} because password is incorrect ");

            }
            
            
        }
    }
}
