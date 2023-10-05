using Core.Const;
using System.Net;
using System.Net.Mail;

namespace Core.CrossCuttingConcern.MailOp
{
    public class MailManager
    {
        public static bool Send(string to, string title, string message)
        {
            MailMessage msg = new MailMessage(CoreKeys.EMAILADDRESS,to);
            msg.Subject = title;
            msg.Body = message;
            msg.IsBodyHtml= true; //body de html kullanılacak mı kullanılmayacak mı true yazarsak mesajda html kodları kullanılabilir.

            //msg.Attachments //maile kod ile dosya da ekleyebiliyorsunuz //msg.Attactment.Add(new Attachment("C:\file.zip"));

            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential(CoreKeys.EMAILUSER, CoreKeys.EMAILPASSWORD);
            smtp.Host = "smtp-mail.outlook.com"; //senin özel mailin(domaini olan) veya google ve hotmail servislerinin özel host bağlantı linki olur onu koyman lazım
            smtp.Port = 587;

            smtp.EnableSsl = true; //Bu değer şirket mailleri için false olarak yazılmalı.
            smtp.Send(msg);
            return true;
        }
    }
}
