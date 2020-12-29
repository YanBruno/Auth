using Auth.Domain.Entities;
using Auth.Domain.Services;
using System.Threading.Tasks;

namespace Auth.Domain.Infra.Services
{
    public class EmailService : IEmailService
    {
        //private readonly MailMessage _mail;

        ////Implementar melhor a dependencia do SmtpClient
        //private readonly EmailServer _server;

        //public EmailService(EmailServer server)
        //{
        //    _server = server;
        //    _mail = new MailMessage
        //    {
        //        From = new MailAddress(Settings.DefaultGmail)
        //    };
        //}

        //public async Task SendWelcome(User user)
        //{
        //    _mail.To.Add(user.Email.Address);
        //    _mail.Subject = $"Boas vindas";
        //    _mail.Body = $"Bem vindo à plataforma, {user.Name}!";

        //    //System.Net.Mail.Attachment attachment;
        //    //attachment = new System.Net.Mail.Attachment("c:/textfile.txt");
        //    //mail.Attachments.Add(attachment);

        //    await _server.GmailService().SendMailAsync(_mail);
        //}

        public async Task SendWelcome(User user)
        {
            await Task.Delay(9000);
        }
    }
}
