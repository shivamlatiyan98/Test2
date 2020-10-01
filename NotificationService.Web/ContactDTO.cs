using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
namespace NotificationService
{
    [ExcludeFromCodeCoverage]
    public partial class ContactDTO
    {
        public string FirstName { get; set; }

        public string Email { get; set; }
        public string PrimaryPhone { get; set; }



    }
}