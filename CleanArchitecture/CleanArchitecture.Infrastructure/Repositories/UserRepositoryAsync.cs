using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Infrastructure.Contexts;
using CleanArchitecture.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Math.EC.Rfc7748;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class UserRepositoryAsync : GenericRepositoryAsync<User>,IUserRepositoryAsync
    {
        public readonly DbSet<User> _users; 
        public UserRepositoryAsync(AppDbContext dbContext) : base(dbContext)
        {
            _users = dbContext.Set<User>();
            
        }

        public Task<User> GetByEmailAsync(string email)
        {
            return _users.FirstAsync(x => x.Email == email);
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            var user = await _users.Include(u => u.Followers).SingleOrDefaultAsync(u=> u.Username == username);
            return user;
        }
        public async Task<User> UpdateUserProfilePhoto(string username,string url)
        {
            var result = await _users.SingleOrDefaultAsync(u => u.Username==username);

            if (result != null)
            {
                result.ProfilePhoto = url;
                await _dbContext.SaveChangesAsync();
                   
            }
            return result;
        }
        public Task<bool> IsUniqueEmail(string email)
        {                           //bütün userlar bu kosulu sağlıyor ise true döner
            return _users.AllAsync(x => x.Email != email);
        }

        public Task<bool> IsUniqueUsername(string username)
        {
            return _users.AllAsync(x => x.Username != username);
        }

        public Task<User> FindByAccountId(int accountId)
        {
            return _users.FirstAsync(u => u.Account.Id == accountId);
        }
    }
}
