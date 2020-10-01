using Microsoft.Extensions.Configuration;
using System.IO;
using System;


using System.Net;
using System.Net.Mail;
namespace NotificationService.Web
{
    public class SendOtpSmtp
    {
        public void Email(ContactDTO contact)
        {


            string emailSender = "PSI-2020_Sep_ASDEII_GGN_Batch_PBS_TEAM_IND@groups.publicisgroupe.net";
            string emailSenderPassword = "";
            string emailSenderHost = "smtp.apac-resources.com";
            int emailSenderPort = Convert.ToInt16("25");
            Boolean emailIsSSL = Convert.ToBoolean("false");
            OtpCreation otpCreation = new OtpCreation();
            string otp = otpCreation.GenerateOtp();

            string FilePath = "C://Users//shilatiy//Desktop//Otpgeneration//emailNotification//NotificationService.Web//OTPValidation.html";
            StreamReader str = new StreamReader(FilePath);
            string MailText = str.ReadToEnd();
            str.Close();


            MailText = MailText.Replace("[newusername]", contact.Email.Trim());
            MailText = MailText.Replace("[otp]", otp);

            string subject = "Authentication Required";


            MailMessage _mailmsg = new MailMessage();


            _mailmsg.IsBodyHtml = true;


            _mailmsg.From = new MailAddress(emailSender);


            _mailmsg.To.Add(contact.Email.ToString());


            _mailmsg.Subject = subject;


            _mailmsg.Body = MailText;



            SmtpClient _smtp = new SmtpClient();


            _smtp.Host = emailSenderHost;


            _smtp.Port = emailSenderPort;


            _smtp.EnableSsl = emailIsSSL;


            NetworkCredential _network = new NetworkCredential(emailSender, emailSenderPassword);
            _smtp.Credentials = _network;


            try
            {
                _smtp.Send(_mailmsg);
            }
            catch (System.Exception e)
            {

                System.Console.WriteLine(e.Message);
            }




        }



    }
}

