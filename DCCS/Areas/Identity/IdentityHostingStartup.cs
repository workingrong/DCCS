using System;
using DCCS.Areas.Identity.Data;
using DCCS.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(DCCS.Areas.Identity.IdentityHostingStartup))]
namespace DCCS.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<DCCSContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("DCCSContextConnection")));

                services.AddDefaultIdentity<DCCSUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<DCCSContext>();
            });
        }
    }
}