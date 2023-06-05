using AutoMapper;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Features.User.Commands.CreateUser
{
    public partial class CreateUserCommand : IRequest<Response<int>>
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }


    }
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Response<int>>
    {
        private readonly IUserRepositoryAsync _userRepository;
        private readonly IAccountRepositoryAsync _accountRepository;
        private readonly IMapper _mapper;   
        public CreateUserCommandHandler(IUserRepositoryAsync userRepositoryAsync,
            IMapper mapper,
            IAccountRepositoryAsync accountRepositoryAsync)
        {
            _userRepository = userRepositoryAsync;
            _mapper = mapper;
            _accountRepository = accountRepositoryAsync;
        }

        public async Task<Response<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<Entities.User>(request);

            var userSaved = await _userRepository.AddAsync(user);

            var account = new Account
            {
                UserId = userSaved.Id,
                Created = DateTime.UtcNow,
                CreatedBy = user.Name,
                LastModifiedBy = user.Name,
                LastModified = DateTime.UtcNow,
            };

            await _accountRepository.AddAsync(account);

            return new Response<int>(user.Id,message:$"user added id : {user.Id}, name : {user.Name}, account added id: {account.Id}");
        }
    }
}
