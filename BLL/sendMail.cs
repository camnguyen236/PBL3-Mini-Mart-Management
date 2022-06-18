
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmailValidation;

namespace BLL
{
    public class sendMail
    {
        private static sendMail _Instance;
        public static sendMail Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new sendMail();
                }
                return _Instance;
            }
            private set { } //chỉ nội bộ lớp này mới đc set dữ liệu vào
        }
        private sendMail() { }
        //private static readonly string _from = "dcd.minimart@gmail.com"; //"236camnguyen@gmail.com"; // Email của Sender (của bạn)
        //private static readonly string _pass = "DCD@PBL3"; //"Camnguyen236@"; // Mật khẩu Email của Sender (của bạn)
        private static readonly string _from = "g8cinestar.@gmail.com"; // Email của Sender (của bạn)
        private static readonly string _pass = "quanlirapchieuphim"; // Mật khẩu Email của Sender (của bạn)

        public string checkMail(string mail)
        {
            EmailValidator emailValidator = new EmailValidator();
            EmailValidationResult result;

            try
            {
                if (!emailValidator.Validate(mail, out result))
                {
                    // no internet connection or mailserver is down / busy
                    return "Unable to check email";
                }

                switch (result)
                {
                    case EmailValidationResult.MailboxUnavailable:
                        return "Email server replied there is no such mailbox";

                    case EmailValidationResult.MailboxStorageExceeded:
                        return "Mailbox overflow";

                    case EmailValidationResult.NoMailForDomain:
                        return "Emails are not configured for domain (no MX records)";
                }
                return "OKk";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public string Send(string sendto, string subject, string content)
        {

            //sendto: Email receiver (người nhận)
            //subject: Tiêu đề email
            //content: Nội dung của email, bạn có thể viết mã HTML
            //Nếu gửi email thành công, sẽ trả về kết quả: OK, không thành công sẽ trả về thông tin lỗi
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress(_from);
                mail.To.Add(sendto);
                mail.Subject = subject;
                mail.IsBodyHtml = true;
                mail.Body = content;

                mail.Priority = MailPriority.High;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(_from, _pass);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                return "Sent Successfully";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }
    }
}
