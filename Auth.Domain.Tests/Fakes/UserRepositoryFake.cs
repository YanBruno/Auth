using Auth.Domain.Entities;
using Auth.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Auth.Domain.Tests.Fakes
{
    public class UserRepositoryFake : IUserRepository
    {
        public bool CheckEmail(string email)
        {
            return false;
        }

        public Task Delete(User user)
        {
            throw new NotImplementedException();
        }

        public User GetUser(Guid id, string email)
        {
            throw new NotImplementedException();
        }

        public User GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public async Task Save(User user)
        {
            await Task.Delay(2000);
        }

        public void Update(User user)
        {

        }

        Task IUserRepository.Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
