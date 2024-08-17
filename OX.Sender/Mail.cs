using OX.Sender.Entities;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Text;

namespace OX.Sender
{
    public class Mail
    {
        public MailConfiguration _mailConfiguration { get; private set; }

        public Mail(MailConfiguration mailConfiguration)
        {
            _mailConfiguration = mailConfiguration;
        }

        public bool Send()
        {
            var smtp = new SmtpClient
            {
                Host = _mailConfiguration.Host,
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_mailConfiguration.FromAddress, _mailConfiguration.Password),

            };
            AlternateView view = AlternateView.CreateAlternateViewFromString(CreateBody(_mailConfiguration.UserValidationTemplate, "mail", "link"), Encoding.UTF8, MediaTypeNames.Text.Html);

            using (var message = new MailMessage(_mailConfiguration.FromAddress, _mailConfiguration.ToAddress)
            {
                Subject = _mailConfiguration.Subject,
                Body = _mailConfiguration.Body,
            })

            {
                message.AlternateViews.Add(view);
                smtp.Send(message);
            }

            return true;
        }


        private string CreateBody(string TemplatePath, string email, string link)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(TemplatePath))
            {
                body = reader.ReadToEnd();
            }

            body = body.Replace("{femail}", email);
            body = body.Replace("{flink}", link);
            return body;
        }
    }
}
