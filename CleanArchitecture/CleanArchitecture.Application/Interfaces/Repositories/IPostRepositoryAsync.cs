﻿using CleanArchitecture.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Interfaces.Repositories
{
    public interface IPostRepositoryAsync : IGenericRepositoryAsync<Post>
    {
        Task<Post> DeleteByIdAsync(string id);

        Task<Post> GetByGuidAsync(Guid id);

        Task<int> GetLikeCountOfPost(Guid id);
    }
}
