using Auth.Domain.Entities;
using Auth.Domain.Services;
using System;
using System.Threading.Tasks;

namespace Auth.Domain.Tests.Fakes
{
    public class EmailServiceFake : IEmailService
    {
        public async Task<bool> SendWelcome(User user)
        {
            Console.WriteLine($"Iniciando envio do email para {user.Name}");
            await Task.Delay(9000);
            Console.WriteLine($"Email enviado para {user.Name}");
            return true;
        }

        Task IEmailService.SendWelcome(User user)
        {
            throw new NotImplementedException();
        }
    }
}
