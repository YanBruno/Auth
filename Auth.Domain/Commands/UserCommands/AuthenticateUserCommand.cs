using Auth.Domain.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace Auth.Domain.Commands.UserCommands
{
    public class AuthenticateUserCommand : Notifiable, ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public void Validate()
        {
            //FFV
            AddNotifications(new Contract()
                .Requires()
                .IsEmail(Email, "Command.Email", "E-mail inválido")
                .HasMinLen(Password, 8, "Command.Password", "A senha deve conter um mínimo de 8 caracteres")
                .HasMaxLen(Password, 10, "Command.Password", "A senha deve conter um mínimo de 10 caracteres"));
        }
    }
}
