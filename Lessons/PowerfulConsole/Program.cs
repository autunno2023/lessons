﻿using System.Net;
using System.Net.Mail;

namespace PowerfulConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var FromAddress = new MailAddress("trinity.casper@ethereal.email", "CORSONET 2023");
            var ToAddress = new MailAddress("");
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
                Subject = "",
                Body = ""
            })
            {
                smtp.Send(message);
            }
        }
    }


}
