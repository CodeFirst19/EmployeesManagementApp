using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EhailingWebApp.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName="nvarchar(100)")]
        public string FirstName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string Gender { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(15)")]
        public DateTime DateOfBirth { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string StreetName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string City { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string Provice { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string Status { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string Platform { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string Region { get; set; }
    }
}
