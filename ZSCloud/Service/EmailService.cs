using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using ZSCloud.Models;
using System.Configuration;
using System.Web.Configuration;

namespace ZSCloud.Service
{
    public class EmailService
    {
        // Hosting Server -- Symbol Host
        public bool SendEmail(SendEmailModel sendEmailModel)
        {

            try
            {
                SmtpClient smtpClient = new SmtpClient();

                smtpClient.Host = ConfigurationManager.AppSettings["Host"];
                smtpClient.Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]);
                smtpClient.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
                smtpClient.UseDefaultCredentials = Convert.ToBoolean(ConfigurationManager.AppSettings["UseDefaultCredentials"]);
                smtpClient.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["UserName"],
                                             ConfigurationManager.AppSettings["Password"]);

                MailAddress mailAddressFrom = new MailAddress(ConfigurationManager.AppSettings["MailTo"], "You", System.Text.Encoding.UTF8);
                MailAddress mailAddressTo = new MailAddress(sendEmailModel.SenderEmail);

                // Specify the message content.
                MailMessage message = new MailMessage(mailAddressTo, mailAddressFrom);
                message.Subject = sendEmailModel.Subject;
                message.SubjectEncoding = System.Text.Encoding.UTF8;

                message.Body = $"<div style='font-family: sans-serif; font-size: 13px;'>" + $"Hi, I am {sendEmailModel.FirstName}" +
                    $",<br><p>{sendEmailModel.Body}</a>.</p>";

                message.Body += Environment.NewLine;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.IsBodyHtml = true;



                smtpClient.Send(message);


                return true;

            }
            catch (Exception ex)
            {
                //DataLogger.LoggerDataInsert(_config, new LoggedData() { LogTypeId = LogType.InvalidCredential, Description = $"Email not sent for email address {appUser.UserEmail}, Error: " + ex.Message, CreatedBy = appUser.Id });
                throw ex;
            }

        }

        // GMail Server 
        //public bool SendEmail(SendEmailModel sendEmailModel)
        //{

        //    try
        //    {

        //        var fromAddress = new MailAddress(sendEmailModel.SenderEmail, sendEmailModel.FirstName);
        //        var toAddress = new MailAddress("wasiq.bahria84@gmail.com", "Wasiq Khan");
        //         string fromPassword = "goo238170825636";
        //         string subject = sendEmailModel.Subject;
        //         string body = sendEmailModel.Body;

        //        var smtp = new SmtpClient
        //        {
        //            Host = "smtp.gmail.com",
        //            Port = 587,
        //            EnableSsl = true,
        //            DeliveryMethod = SmtpDeliveryMethod.Network,
        //            UseDefaultCredentials = false,
        //            Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
        //        };
        //        using (var message = new MailMessage(fromAddress, toAddress)
        //        {
        //            Subject = subject,
        //            Body = body
        //        })
        //        {
        //            smtp.Send(message);
        //        }


        //        return true;

        //    }
        //    catch (Exception ex)
        //    {
        //        //DataLogger.LoggerDataInsert(_config, new LoggedData() { LogTypeId = LogType.InvalidCredential, Description = $"Email not sent for email address {appUser.UserEmail}, Error: " + ex.Message, CreatedBy = appUser.Id });
        //        throw ex;
        //    }

        //}
    }
}