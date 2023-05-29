using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
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
    public class AccountRepositoryAsync : GenericRepositoryAsync<Account>, IAccountRepositoryAsync
    {
        public readonly DbSet<Account> _account;
        public AccountRepositoryAsync(AppDbContext dbContext) : base(dbContext)
        {
            _account = dbContext.Set<Account>();
        }
    }
}
