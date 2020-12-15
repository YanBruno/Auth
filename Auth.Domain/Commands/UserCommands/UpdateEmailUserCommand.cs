using Auth.Domain.Shared.Commands;
using Flunt.Notifications;
using System;

namespace Auth.Domain.Commands.UserCommands
{
    public class UpdateEmailUserCommand : Notifiable, ICommand
    {

        public Guid Id { get; set; }
        public string Email { get; set; }
        public string NewEmail { get; set; }

        public void Validate()
        {

        }
    }
}
