using Auth.Domain.Shared.ValueObjects;
using Flunt.Validations;
using System.Linq;
using System.Text;
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
            var hidePass = new StringBuilder();
            Pass.ToList().ForEach(x => {hidePass.Append("*");});
            Pass = hidePass.ToString();
        }
        public void Validate()
        {
            var hasNum = new Regex(@"[0-9]+");
            var hasUpper = new Regex(@"[A-Z]+");
            var hasLower = new Regex(@"[a-z]+");
            //var hasMaxMinLen = new Regex(@".{8,10}"); este já está sendo validado por outros meios
            var hasCaracters = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasUpper.IsMatch(Pass)) AddNotification("Password.Pass", "A senha deve conter ao menos um caractere maiúsculo");
            if (!hasLower.IsMatch(Pass)) AddNotification("Password.Pass", "A senha deve conter ao menos um caractere minúsculo");
            if (!hasNum.IsMatch(Pass)) AddNotification("Password.Pass", "A senha deve conter ao menos um caractere numérico");
            if (!hasCaracters.IsMatch(Pass)) AddNotification("Password.Pass", "A senha deve conter ao menos um caractere especial");
        }

    }
}