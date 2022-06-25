
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmailValidation;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.Threading;
using System.IO;
namespace BLL
{
    public class sendMail
    {
        string[] Scopes = { GmailService.Scope.GmailSend };
        string ApplicationName = "GmailAppV2";
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
            return "OK";
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
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        string Base64UrlEncode(string input)
        {
            var data = Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(data).Replace("+", "-").Replace("/", "_").Replace("=", "");
        }
        public string Send(string sendto, string subject, string content)
        {

            //sendto: Email receiver (người nhận)
            //subject: Tiêu đề email
            //content: Nội dung của email, bạn có thể viết mã HTML
            //Nếu gửi email thành công, sẽ trả về kết quả: OK, không thành công sẽ trả về thông tin lỗi
            try
            {
                UserCredential credential;
                //read your credentials file
                using (FileStream stream = new FileStream(Application.StartupPath + @"/credentials.json", FileMode.Open, FileAccess.Read))
                {
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    path = Path.Combine(path, ".credentials/gmail-dotnet-quickstart.json");
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(stream).Secrets, Scopes, "user", CancellationToken.None, new FileDataStore(path, true)).Result;
                }

                string message = $"To: {sendto}\r\nSubject: {subject}\r\nContent-Type: text/html;charset=utf-8\r\n\r\n<h1>{content}</h1>";
                //call your gmail service
                var service = new GmailService(new BaseClientService.Initializer() { HttpClientInitializer = credential, ApplicationName = ApplicationName });
                var msg = new Google.Apis.Gmail.v1.Data.Message();
                msg.Raw = Base64UrlEncode(message.ToString());
                service.Users.Messages.Send(msg, "me").Execute();
                
                return "Sent Successfully";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }
    }
}
