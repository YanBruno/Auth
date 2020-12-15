using Auth.Domain.Enums;
using Auth.Domain.Shared.Commands;
using Flunt.Notifications;
using System;

namespace Auth.Domain.Commands.UserCommands
{
    public class UpdateRoleUserCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public ERoleType Role { get; set; }

        public void Validate()
        {

        }
    }
}
