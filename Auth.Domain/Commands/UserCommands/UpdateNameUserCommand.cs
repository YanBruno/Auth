using Auth.Domain.Shared.Commands;
using Flunt.Notifications;
using System;

namespace Auth.Domain.Commands.UserCommands
{
    public class UpdateNameUserCommand : Notifiable, ICommand
    {

        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public void Validate()
        {

        }
    }
}
