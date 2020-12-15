using Auth.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace Auth.Domain.Queries
{
    public static class UserQuery
    {
        public static Expression<Func<User, bool>> GetUser(Guid id, string email)
        {
            return x => x.Id == id && x.Email.Address == email;
        }

        public static Expression<Func<User, bool>> GetUserByEmail(string email)
        {
            return x => x.Email.Address == email;
        }

        public static Expression<Func<User, bool>> GetUserById(Guid id)
        {
            return x => x.Id == id;
        }

    }
}
