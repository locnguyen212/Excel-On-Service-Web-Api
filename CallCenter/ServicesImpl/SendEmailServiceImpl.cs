using CallCenter.Services;
using CallCenter.Utils.UtilModels;
using MailKit.Net.Smtp;
using MimeKit;

namespace CallCenter.ServicesImpl
{
    public class SendEmailServiceImpl : ISendEmailService
    {
        private IConfiguration _configuration;
        public SendEmailServiceImpl(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendEmail(EmailModel emailModel)
        {
            var emailMessage = new MimeMessage();
            var from = _configuration["Gmail:From"];
            emailMessage.From.Add(new MailboxAddress("Api mailing", from));
            emailMessage.To.Add(new MailboxAddress(emailModel.To, emailModel.To));
            emailMessage.Subject = emailModel.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = String.Format(emailModel.Content)
            };

            using(var client = new SmtpClient())
            {
                var port = int.Parse(_configuration["Gmail:Port"]);
                try
                {
                    client.Connect(_configuration["Gmail:Host"], 465, true);
                    client.Authenticate(_configuration["Gmail:From"], _configuration["Gmail:Password"]);
                    client.Send(emailMessage);
                }
                catch(Exception ex)
                {
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
        }
    }
}
