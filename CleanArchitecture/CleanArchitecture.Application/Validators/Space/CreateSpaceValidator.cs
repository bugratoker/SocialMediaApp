using CleanArchitecture.Core.Features.Spaces.Commands;
using CleanArchitecture.Core.Interfaces.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Validators.Space
{
    public class CreateSpaceValidator : AbstractValidator<CreateSpaceCommand>
    {
        private readonly ISpaceRepositoryAsync _spaceRepositoryAsync;
        public CreateSpaceValidator(ISpaceRepositoryAsync spaceRepositoryAsync)
        {
            _spaceRepositoryAsync = spaceRepositoryAsync;

            RuleFor(s=>s.SpaceName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MustAsync(IsUniqueName).WithMessage("{PropertyName} already exists.");
        }
        private async Task<bool> IsUniqueName(string name, CancellationToken cancellationToken)
        {
            return await _spaceRepositoryAsync.IsUniqueNameAsync(name);
        }
    }
}
