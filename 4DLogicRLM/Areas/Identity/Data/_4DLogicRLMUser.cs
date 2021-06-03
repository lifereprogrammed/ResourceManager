using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace _4DLogicRLM.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the _4DLogicRLMUser class
    public class _4DLogicRLMUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyID { get; set; }
    }
}
