using System;
namespace NotificationService.Web
{
    public class OtpCreation
    {
        public string GenerateOtp()
        {
            string otp = null;
            Random rnd = new Random();
            otp = (rnd.Next(100000, 999999).ToString());

            return otp;

        }

        public bool CheckEmail(string email)
        {
            if (email.Contains("@"))
            {
                return true;
            }
            return false;

        }



    }
}