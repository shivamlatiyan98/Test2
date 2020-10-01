using System;
using Xunit;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using NotificationService.Web;
using NotificationService.Web.Controllers;

using System.Threading.Tasks;
namespace NotificationService.Test
{
    public class OtpControllerTest
    {
        IConfiguration configuration;
        OtpGeneration controller;
        public OtpControllerTest()
        {
            configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true)
             .Build();
            controller = new OtpGeneration(configuration);
        }

        [Fact]
        public void Test1()
        {
            OtpCreation ob1 = new OtpCreation();
            string s1 = ob1.GenerateOtp();
            string s2 = ob1.GenerateOtp();
            bool unique = false;
            if (s1 != s2)
            {
                unique = true;
            }

            Assert.Equal(unique, true);



        }

        [Fact]
        public void Test2()
        {

            string Email = "shivannot96@yahoo.com";


            OtpCreation otpCreation = new OtpCreation();
            bool flag = otpCreation.CheckEmail(Email);
            Assert.Equal(flag, true);

        }

        [Fact]
        public void Test3()
        {
            ContactDTO contact = new ContactDTO();

            contact.Email = "shivamlatiyan98@gmail.com";
            contact.FirstName = "shivam";
            contact.PrimaryPhone = "8700227876";


            var result = controller.Post(contact);

            Assert.IsType<OkObjectResult>(result);




        }













    }
}
