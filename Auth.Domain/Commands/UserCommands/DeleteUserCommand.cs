using Auth.Domain.Shared.Commands;
using Flunt.Notifications;
using System;

namespace Auth.Domain.Commands.UserCommands
{
    public class DeleteUserCommand : Notifiable, ICommand
    {

        public Guid Id { get; set; }
        public string Email { get; set; }

        //Fail Fast Validation
        public void Validate()
        {
            
        }
    }
}
