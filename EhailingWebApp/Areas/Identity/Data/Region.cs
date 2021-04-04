using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EhailingWebApp.Areas.Identity.Data
{
    public class Region
    {
        [Key]
        public int RegionId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string RegionName { get; set; }

        //Collection Navigation Property
        public ICollection<ApplicationUser> Users { get; set; }
    }
}
