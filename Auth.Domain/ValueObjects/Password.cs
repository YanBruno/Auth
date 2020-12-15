using Auth.Domain.Shared.ValueObjects;
using Flunt.Validations;
using System.Text.RegularExpressions;

namespace Auth.Domain.ValueObjects
{
    public class Password : ValueObject, IValidatable
    {
        //EF Core
        public Password()
        {
        }

        public Password(string pass)
        {
            Pass = pass;
            Validate();
        }

        public string Pass { get; private set; }

        public void HidePassword()
        {
            var count = Pass.Length;
            var hidePass = "";
            for (int i = 0; i <= count; i++)
            {
                hidePass += "*";
            }
            Pass = hidePass;
        }
        public void Validate()
        {
            var hasNum = new Regex(@"[0-9]+");
            var hasUpper = new Regex(@"[A-Z]+");
            var hasLower = new Regex(@"[a-z]+");
            //var hasMaxMinLen = new Regex(@".{8,10}");
            var hasCaracters = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasUpper.IsMatch(Pass)) AddNotification("Password.Pass", "A senha deve conter ao menos um caractere maiúsculo");
            if (!hasLower.IsMatch(Pass)) AddNotification("Password.Pass", "A senha deve conter ao menos um caractere minúsculo");
            if (!hasNum.IsMatch(Pass)) AddNotification("Password.Pass", "A senha deve conter ao menos um caractere numérico");
            if (!hasCaracters.IsMatch(Pass)) AddNotification("Password.Pass", "A senha deve conter ao menos um caractere especial");
        }
    }
}