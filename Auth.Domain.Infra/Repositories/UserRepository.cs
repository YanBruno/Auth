using Auth.Domain.Entities;
using Auth.Domain.Infra.DataContexts;
using Auth.Domain.Queries;
using Auth.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Auth.Domain.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthDataContext _context;

        public UserRepository(AuthDataContext context)
        {
            _context = context;
        }

        public bool CheckEmail(string email)
        {
            var user = _context.Users.FirstOrDefault(UserQuery.GetUserByEmail(email));
            if (user == null)
                return false;

            return true;

        }

        public async Task Delete(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public User GetUser(Guid id, string email)
        {
            var user = _context.Users.FirstOrDefault(UserQuery.GetUser(id, email));
            return user;
        }

        public User GetUserByEmail(string email)
        {
            var user = _context.Users.FirstOrDefault(UserQuery.GetUserByEmail(email));
            return user;
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.AsNoTracking();
        }

        public async Task Save(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task Update(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
