using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Infrastructure.Contexts;
using CleanArchitecture.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class LikeRepositoryAsync : GenericRepositoryAsync<Like>, ILikeRepositoryAsync
    {
        public readonly DbSet<Like> _likes; 
        public LikeRepositoryAsync(AppDbContext dbContext) : base(dbContext)
        {
            _likes = dbContext.Set<Like>();
        }

        public  Task<Like> LikePostAsync(string postId, int userId)
        {
            throw new NotImplementedException();
        }
    }
}
