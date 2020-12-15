using Auth.Domain.Shared.ValueObjects;
using Flunt.Validations;

namespace Auth.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        //EF Core
        public Name()
        {
        }

        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(FirstName, 3, "Name.FirstName", "O nome deve conter ao menos 3 caracteres")
                .HasMaxLen(FirstName, 15, "Name.FirstName", "O nome deve conter no máximo 15 caracteres")
                .HasMinLen(LastName, 3, "Name.LastName", "O sobrenome deve conter ao menos 3 caracteres")
                .HasMaxLen(LastName, 15, "Name.LastName", "O sobrenome deve conter no máximo 15 caracteres")
            );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}"; 
        }
    }
}
