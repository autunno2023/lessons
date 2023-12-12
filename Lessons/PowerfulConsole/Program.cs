using System.Net;
using System.Net.Mail;

namespace PowerfulConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var FromAddress = new MailAddress("marquis.mueller@ethereal.email", "CORSONET 2023");
            var ToAddress = new MailAddress("bruno_ferreira@hotmail.it");
            const string fromPassword = "BT6WuFezhU9FUwPVNW";


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
                Subject = "gffgfffg",
                Body = "gfgfgfgffg"
            })
            {
                smtp.Send(message);
            }
        }
    }


}
