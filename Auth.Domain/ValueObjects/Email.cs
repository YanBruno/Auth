using Auth.Domain.Shared.ValueObjects;
using Flunt.Validations;

namespace Auth.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        //EF Core
        public Email()
        {
        }

        public Email(string address)
        {
            Address = address;

            AddNotifications(new Contract()
                .Requires()
                .IsEmail(Address, "Email.Address", "E-mail inválido")
            );

        }

        public string Address { get; private set; }

    }
}
