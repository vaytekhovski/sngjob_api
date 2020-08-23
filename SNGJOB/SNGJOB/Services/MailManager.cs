using System;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Logging;

namespace SNGJOB.Services
{
    public class MailManager
    {
        private readonly ILogger<MailManager> logger;
        public MailManager(ILogger<MailManager> logger)
        {
            this.logger = logger;
        }

        public void SendEmailDefaul(string recipient, string subject, string messageText)
        {
            try
            {
                MailMessage message = new MailMessage();
                message.IsBodyHtml = true;
                message.From = new MailAddress("jobfromsng@gmail.com", "SNGJOB");
                message.To.Add(recipient);
                message.Subject = subject;
                message.Body = messageText;

                using (SmtpClient client = new SmtpClient("smtp.gmail.com"))
                {
                    client.Credentials = new NetworkCredential("jobfromsng@gmail.com", "%:cB)@F6#!FkgM):");
                    client.Port = 587;
                    client.EnableSsl = true;

                    client.Send(message);
                }

                logger.LogInformation("Сообщение " + recipient + " отправлено успешно!");
            }
            catch (Exception e)
            {

                logger.LogError(e.GetBaseException().Message);
            }
        }

        

    }
}
