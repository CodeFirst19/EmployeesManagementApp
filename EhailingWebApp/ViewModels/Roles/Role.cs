using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EhailingWebApp.ViewModels.Roles
{
    public class Role
    {
        [Required]
        public string RoleName { get; set; }
        public string Message { get; set; }
    }
}
