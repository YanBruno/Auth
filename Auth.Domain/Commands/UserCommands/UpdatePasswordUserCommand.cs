using Auth.Domain.Shared.Commands;
using Flunt.Notifications;
using System;

namespace Auth.Domain.Commands.UserCommands
{
    public class UpdatePasswordUserCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        public void Validate()
        {

        }
    }
}
