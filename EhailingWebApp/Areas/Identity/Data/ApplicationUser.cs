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
        [Column(TypeName = "nvarchar(10)")]
        public string Gender { get; set; }

        [PersonalData]
        [Column(TypeName = "date")]
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

        //Foreign Keys
        [ForeignKey("Status")]
        public int StatusId { get; set; }
        [ForeignKey("Platform")]
        public int PlatformId { get; set; }
        [ForeignKey("Region")]
        public int RegionId { get; set; }

        //Reference Navigation properties
        public Status Status { get; set; }
        public Platform Platform { get; set; }
        public Region Region { get; set; }
    }
}
