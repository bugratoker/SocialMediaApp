using CleanArchitecture.Core.Features.User.Commands.CreateUser;
using CleanArchitecture.Core.Interfaces.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Validators.User
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        private readonly IUserRepositoryAsync _userRepositoryAsync;
        public CreateUserValidator(IUserRepositoryAsync userRepositoryAsync)
        {
            _userRepositoryAsync = userRepositoryAsync;

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .MustAsync(IsUniqueUsername).WithMessage("{PropertyName} already exists.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .MustAsync(IsUniqueEmail).WithMessage("{PropertyName} already exists.");
          
        }
        private async Task<bool> IsUniqueEmail(string email, CancellationToken cancellationToken)
        {
            return await _userRepositoryAsync.IsUniqueEmail(email);
        }
        private async Task<bool> IsUniqueUsername(string username, CancellationToken cancellationToken)
        {
            return await _userRepositoryAsync.IsUniqueUsername(username);
        }
    }
}
