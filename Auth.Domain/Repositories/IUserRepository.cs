using Auth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Auth.Domain.Repositories
{
    public interface IUserRepository
    {
        public Task<bool> CheckEmail(string email);
        public Task<IEnumerable<User>> GetUsers();
        public Task<User> GetUserByEmail(string email);
        public Task<User> GetUser(Guid id, string email);
        public Task Delete(User user);
        public Task Update(User user);
        public Task Save(User user);
    }
}
