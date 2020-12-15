using Auth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Auth.Domain.Repositories
{
    public interface IUserRepository
    {
        public Task Delete(User user);
        public bool CheckEmail(string email);
        public User GetUserByEmail(string email);
        public User GetUser(Guid id, string email);
        public IEnumerable<User> GetUsers();
        public Task Update(User user);
        public Task Save(User user);
    }
}
