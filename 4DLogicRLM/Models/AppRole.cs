using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _4DLogicRLM.Models
{
    public class AppRole : IdentityRole
    {
        public string Access { get; set; }
        public string RoleName { get; set; }

    }
    
}
