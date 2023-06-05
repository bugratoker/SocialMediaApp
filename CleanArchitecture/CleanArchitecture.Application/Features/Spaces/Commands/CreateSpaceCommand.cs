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

namespace CleanArchitecture.Core.Features.Spaces.Commands
{
    public class CreateSpaceCommand : IRequest<Response<string>>
    {
        public string SpaceName { get; set; }
        
    }
    public class CreateSpaceCommandHandler : IRequestHandler<CreateSpaceCommand, Response<string>>
    {
        private readonly ISpaceRepositoryAsync _spaceRepositoryAsync;
        private readonly IMapper _mapper;
        public CreateSpaceCommandHandler(ISpaceRepositoryAsync spaceRepositoryAsync, IMapper mapper)
        {
            _spaceRepositoryAsync = spaceRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(CreateSpaceCommand request, CancellationToken cancellationToken)
        {
            
            var space =  _mapper.Map<Space>(request);
            await _spaceRepositoryAsync.AddAsync(space);

            return new Response<string>(space.SpaceName, message: "added successfully");
        }
    }

}
