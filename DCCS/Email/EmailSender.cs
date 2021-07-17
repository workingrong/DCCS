using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DCCS.Email
{
    public class EmailSender : IEmailSender
    {
        public EmailSender(IOptions<EmailSenderAuthOptions> optionsAccessor)
        {
            this.Options = optionsAccessor.Value;
        }

        public EmailSenderAuthOptions Options { get; }

        public Task Execute(string subject, string message, string email)
        {
            string host = this.Options.Email_Smtp_Host;
            int port = int.Parse(this.Options.Email_Smtp_Port);
            string user = this.Options.Email_Sender_User;
            string key = this.Options.Email_Sender_Key;

            using (MailMessage mail = new MailMessage(user, email))
            {
                mail.Subject = subject;
                mail.Body = message;
                mail.BodyEncoding = Encoding.UTF8;
                mail.IsBodyHtml = true;

                using (SmtpClient client = new SmtpClient(
                    this.Options.Email_Smtp_Host,
                    int.Parse(this.Options.Email_Smtp_Port)))
                {
                    NetworkCredential basicCredential = new NetworkCredential(user, key);
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = basicCredential;

                    try
                    {
                        client.Send(mail);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        throw;
                    }
                }
            }

            return Task.CompletedTask;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return this.Execute(subject, htmlMessage, email);
        }
    }
}
