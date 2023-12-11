using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace PowerfulConsole
{
    public class EmailSender
    {
        readonly IConfiguration _configuration;
        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendEmail(string toAddress, string subject, string body)
        {

            var FromAddress = new MailAddress("trinity.casper@ethereal.email", "CORSONET 2023");
            var ToAddress = new MailAddress(toAddress);
            const string fromPassword = "pjreAx4EygBMUPrnBN";


            var smtp = new SmtpClient
            {
                Host = "smtp.ethereal.email",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(FromAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(FromAddress, ToAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}
