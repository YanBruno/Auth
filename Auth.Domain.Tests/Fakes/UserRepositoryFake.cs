using Auth.Domain.Entities;
using Auth.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Auth.Domain.Tests.Fakes
{
    public class UserRepositoryFake : IUserRepository
    {
        public Task<bool> CheckEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task Delete(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUser(Guid id, string email)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public Task Save(User user)
        {
            throw new NotImplementedException();
        }

        public Task Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
