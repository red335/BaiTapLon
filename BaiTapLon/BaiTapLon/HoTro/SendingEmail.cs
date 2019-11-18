using System.Net;
using System.Net.Mail;
namespace BaiTapLon.HoTro
{
    public class SendingEmail
    {
        private static string mailFrom = "KHName@gmail.com";
        private static string pass = "Name12345";
        public void email_send(string mailTo,string subject, string body)
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress(mailFrom);
            mail.To.Add(mailTo);
            mail.Subject = subject;
            mail.Body = body;
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential(mail.From.Address, pass);
            smtp.EnableSsl = true;
            smtp.Send(mail);

        }

    }
}
