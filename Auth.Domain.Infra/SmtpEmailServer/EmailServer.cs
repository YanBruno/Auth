using Auth.Domain.Shared;
using System.Net.Mail;

namespace Auth.Domain.Infra.SmtpEmailServer
{
    public class EmailServer
    {
        private readonly SmtpClient _gmailService = new SmtpClient();

        public SmtpClient OutLookServer()
        {
            return new SmtpClient();
        }

        public SmtpClient GmailService()
        {
            _gmailService.Host = "smtp.gmail.com";
            _gmailService.Port = 587;
            _gmailService.Credentials = new System.Net.NetworkCredential(Settings.DefaultGmail, Settings.GmailSecret);
            _gmailService.EnableSsl = true;

            return _gmailService;
        }
    }
}
