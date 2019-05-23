using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HebianGu.Demo.AspNetCore.IdentityServer.Models
{
    public class ApplicationIdentityUser : IdentityUser
    { 
        public string Tel { get; set; }

        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime CDate { get; set; }
    }
}
