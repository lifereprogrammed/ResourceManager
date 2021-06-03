using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _4DLogicRLM.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _4DLogicRLM.Models
{
    public class _4DLogicRLMContext : IdentityDbContext<_4DLogicRLMUser>
    {
        public _4DLogicRLMContext(DbContextOptions<_4DLogicRLMContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
