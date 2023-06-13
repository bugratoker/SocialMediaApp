using CleanArchitecture.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Interfaces.Repositories
{
    public interface ISpaceRepositoryAsync : IGenericRepositoryAsync<Space>
    {
        Task<List<Post>> GetPostsOfSpace(string spaceName);
        Task<bool> IsUniqueNameAsync(string name);
    }
}
