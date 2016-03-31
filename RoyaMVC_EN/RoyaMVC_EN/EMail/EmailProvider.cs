using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;

namespace RoyaMVC_EN.EMail
{
    
    public static class EmailProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gmailUserName">The sending email username. e.g. info@gmail.com</param>
        /// <param name="gmailPassword">The sending email username. e.g. 1234567890</param>
        /// <param name="receiversList"></param>
        /// <param name="subject"></param>
        /// <param name="messageBody"></param>
        public static void SendFromGMail(string gmailUserName, string gmailPassword, List<string> receiversList, string subject, string messageBody) {
            EmailProvider.Send(gmailUserName, gmailPassword, receiversList, subject, messageBody, "smtp.gmail.com", 587, true, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="senderUserName">The sending email username. e.g. info@RoyaPajoohesh.ir</param>
        /// <param name="senderPassword">The sending email username. e.g. 1234567890</param>
        /// <param name="senderShortDomainAddress">The domain name. e.g. RoyaPajoohesh.ir</param>
        /// <param name="receiversList"></param>
        /// <param name="subject"></param>
        /// <param name="messageBody"></param>
        public static void SendFromParallelPlesk(string senderUserName, string senderPassword, List<string> receiversList, string subject, string messageBody, string senderShortDomainAddress = "127.0.0.1") {
            EmailProvider.Send(senderUserName, senderPassword, receiversList, subject, messageBody, senderShortDomainAddress, 587, true, false);
        }

        public static void Send(string senderUserName, string senderPassword, 
                                List<string> receiversList, string subject, string messageBody,
                                string serverOutgoingAddress, int serverOutgoingPort=-1, bool hasHTMLBody = true, bool ssl = false) {

            var loginInfo = new NetworkCredential(senderUserName, senderPassword);

            var msg = new MailMessage();
            msg.From = new MailAddress(senderUserName);

            foreach (var item in receiversList) {
                msg.To.Add(new MailAddress(item));
            }


            var siteAddress = System.Configuration.ConfigurationManager.AppSettings["SiteAddress"];
            if (string.IsNullOrWhiteSpace(siteAddress) == false)
                messageBody = messageBody.Replace("{SiteAddress}", siteAddress);


            msg.Subject = subject;
            msg.Body = messageBody;
            msg.IsBodyHtml = hasHTMLBody;

            var smtp = (serverOutgoingPort == -1) ? new SmtpClient(serverOutgoingAddress) : new SmtpClient(serverOutgoingAddress, serverOutgoingPort);
            smtp.EnableSsl = ssl;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = loginInfo;
            smtp.Send(msg);
        }
    }
}
