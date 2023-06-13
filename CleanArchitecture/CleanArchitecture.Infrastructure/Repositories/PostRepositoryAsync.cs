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
    public class PostRepositoryAsync : GenericRepositoryAsync<Post>, IPostRepositoryAsync
    {
   
        private readonly DbSet<Post> _posts;
        public PostRepositoryAsync(AppDbContext dbContext) : base(dbContext)
        {
            _posts = dbContext.Set<Post>();
        }

        public async Task<Post> DeleteByIdAsync(string id)
        {
            var guid = new Guid(id);
            
            var post = await _posts.FirstOrDefaultAsync(x => x.Id==guid);
            if (post != null)
            {
                _posts.Remove(post);
                await _dbContext.SaveChangesAsync();
                return post;

            }
            throw new InvalidOperationException($"There is no post specified id {id}");

        }

        public async Task<Post> GetByGuidAsync(Guid id)
        {
           return await _posts.FirstAsync(x => x.Id==id);
        }

        public async Task<int> GetLikeCountOfPost(Guid id)
        {


            var LikeCount = await _posts.Where(p => p.Id == id).
                                    Include(p => p.Likes).
                                    SelectMany(p => p.Likes).CountAsync();

            return LikeCount;

        }
    }
}
