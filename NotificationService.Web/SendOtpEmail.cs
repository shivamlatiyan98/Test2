using System;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Net.Http;
using System.Diagnostics.CodeAnalysis;
namespace NotificationService.Web
{
    [ExcludeFromCodeCoverage]
    public class SendOtpEmail
    {
        private readonly IConfiguration _configuration;
        public SendOtpEmail(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void email(ContactDTO contact, string key, string sender)
        {

            Execute(contact, key, sender).Wait();


        }

        public async Task Execute(ContactDTO customer, string key, string sender)
        {
            var apiKey = key;
            var client = new SendGridClient(apiKey);
            OtpCreation otpCreation = new OtpCreation();
            string otp = otpCreation.GenerateOtp();

            string FilePath = "C://Users//shilatiy//Desktop//Otpgeneration//emailNotification//NotificationService.Web//Password1.html";

            StreamReader str = new StreamReader(FilePath);
            string MailText = str.ReadToEnd();
            str.Close();
            MailText = MailText.Replace("[otp]", otp);




            var msg = new SendGridMessage()
            {
                From = new EmailAddress(sender, "DX Team"),
                Subject = "Email For verification!",
                PlainTextContent = "Forget , Password!",
                HtmlContent = MailText
            };
            msg.AddTo(new EmailAddress(customer.Email, "Test User"));
            var response = await client.SendEmailAsync(msg);

        }








    }
}