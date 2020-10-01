using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Cors;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;


namespace NotificationService.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OtpGeneration : ControllerBase
    {
        private readonly IConfiguration _configuration;


        public OtpGeneration(IConfiguration configuration)
        {
            _configuration = configuration;
        }



        [HttpPost, Route("/forgetpassword")]
        public IActionResult Post([FromBody] ContactDTO contact)
        {


            try
            {

                string key = "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";
                string sender = "shilatiy@publicisgroupe.net";
                SendOtpSmtp sendOtpSmtp = new SendOtpSmtp();
                sendOtpSmtp.Email(contact);

                return Ok(new { message = "data send" });

            }
            catch (System.Exception e)
            {
                return NotFound(new { message = "data send" });

            }


        }









    }






}
