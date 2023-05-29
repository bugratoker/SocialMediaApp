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
    public class FollowerRepositoryAsync : GenericRepositoryAsync<Follower>, IFollowerRepositoryAsync
    {
        public DbSet<Follower> Followers { get; set; }
        public FollowerRepositoryAsync(AppDbContext dbContext) : base(dbContext)
        {
            Followers = dbContext.Set<Follower>();
        }




    }
}
