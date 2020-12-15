using Auth.Domain.Enums;
using Auth.Domain.Shared.Entities;
using Auth.Domain.ValueObjects;

namespace Auth.Domain.Entities
{
    public class User : Entity
    {
        //EF Core
        public User()
        {
        }

        public User(Name name, Email email, Password password)
        {
            Name = name;
            Email = email;
            Password = password;
            Role = ERoleType.Employee;

            //Implementar validação
            AddNotifications(Name, Email, Password);
        }

        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public Password Password { get; private set; }
        public ERoleType Role { get; private set; }

        public void UpdateName(Name name)
        {
            Name = name;
        }
        public void UpdateEmail(Email email)
        {
            Email = email;
        }
        public void UpdatePassword(Password password)
        {
            Password = password;
        }
        public void UpdateRole(ERoleType role)
        {
            Role = role;
        }
    }
}
