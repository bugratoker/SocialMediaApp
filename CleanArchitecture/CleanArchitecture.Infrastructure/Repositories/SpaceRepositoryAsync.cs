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
    public class SpaceRepositoryAsync : GenericRepositoryAsync<Space>, ISpaceRepositoryAsync
    {

        private readonly DbSet<Space> spaces;
        public SpaceRepositoryAsync(AppDbContext dbContext) : base(dbContext)
        {
            spaces = dbContext.Set<Space>();
        }
        public async Task<List<Post>> GetPostsOfSpace(string spaceName)
        {
            var space = await spaces.SingleAsync(s=>s.SpaceName == spaceName);
            if (space == null)
            {
                throw new ArgumentException($"no space found space name : {spaceName}");
            }
            var result = await spaces.Where(s=>s.SpaceName==spaceName)
                                     .Include(s => s.Posts)
                                     .SelectMany(s => s.Posts)
                                     .ToListAsync();
            //var x = result.SelectMany(s => s.Posts);   
            return result;
        }
    }
}

