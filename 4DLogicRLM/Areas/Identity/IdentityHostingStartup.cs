using System;
using _4DLogicRLM.Areas.Identity.Data;
using _4DLogicRLM.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using _4DLogicRLM.Data;

//[assembly: HostingStartup(typeof(_4DLogicRLM.Areas.Identity.IdentityHostingStartup))]
//namespace _4DLogicRLM.Areas.Identity
//{
//    public class IdentityHostingStartup : IHostingStartup
//    {
//        public void Configure(IWebHostBuilder builder)
//        {
//            builder.ConfigureServices((context, services) => {
//                services.AddDbContext<ApplicationDbContext>(options =>
//                    options.UseSqlServer(
//                        context.Configuration.GetConnectionString("_4DLogicRLMContextConnection")));

//                services.AddDefaultIdentity<_4DLogicRLMUser>()
//                    .AddEntityFrameworkStores<ApplicationDbContext>();
//            });
//        }
//    }
//}