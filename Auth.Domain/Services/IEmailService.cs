using Auth.Domain.Entities;
using System.Threading.Tasks;

namespace Auth.Domain.Services
{
    public interface IEmailService
    {
        public Task SendWelcome(User user);
    }
}
