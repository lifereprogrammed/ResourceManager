using System;
using System.Collections.Generic;
using System.Text;
using _4DLogicRLM.Areas.Identity.Data;
using _4DLogicRLM.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _4DLogicRLM.Data
{
    public class ApplicationDbContext : IdentityDbContext<_4DLogicRLMUser, AppRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //General
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<BillingInfo> BillingInfo { get; set; }
        public DbSet<SubscriptionPlans> SubscriptionPlans { get; set; }
        

        //Locations 
        public DbSet<Locations> Locations { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Country> Countries { get; set; }

        //Resources
        public DbSet<Resources> Resources { get; set; }
        public DbSet<ResourceType> ResourceTypes { get; set; }
        public DbSet<ResourceQuantityType> ResourceQuantityTypes { get; set; }
        public DbSet<LocationType> LocationType { get; set; }
    }
}
