using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DaGrasso.Data.Models
{
    public class CreateRoleViewModel :IdentityRole
    {
        [Required]
        public int RoleName { get; set; }
    }
}
