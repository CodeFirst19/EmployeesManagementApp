using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EhailingWebApp.Areas.Identity.Data
{
    public class Status
    {
        [Key]
        public int StatusId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string StatusName { get; set; }

        //Collection Navigation Property
        public ICollection<ApplicationUser> Users { get; set; }
    }
}
