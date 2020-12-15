using Auth.Domain.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace Auth.Domain.Commands.UserCommands
{
    public class CreateUserCommand : Notifiable, ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public void Validate()
        {
            //Fail Fast Validation
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(FirstName, 3, "Command.FirstName", "Mínimo de 3 caracteres permitidos")
                .HasMaxLen(FirstName, 15, "Command.FirstName", "Máximo de 15 caracteres permitidos")
                .HasMinLen(LastName, 3, "Command.LastName", "Mínimo de 3 caracteres permitidos")
                .HasMaxLen(LastName, 15, "Command.LastName", "Máximo de 15 caracteres permitidos")
                .IsEmail(Email, "Command.Email", "E-mail inválido")
                .HasMinLen(Password, 8, "Command.Password", "A senha deve conter um mínimo de 8 caracteres")
                .HasMaxLen(Password, 10, "Command.Password", "A senha deve conter um mínimo de 10 caracteres")
            );
        }
    }
}
