using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Web.Models;

namespace Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Web.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Web.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            // context.Product.AddOrUpdate( p=>p.)
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "Administrator" });
                roleManager.Create(new IdentityRole { Name = "Retail" });
                roleManager.Create(new IdentityRole { Name = "Wholesale" });
            }
            // Create Admin user
            var user = new ApplicationUser()
            {
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
                EmailConfirmed = true
            };
            manager.Create(user, "Admin-1234");
            var admin = manager.FindByName("admin@admin.com");
            manager.AddToRoles(admin.Id, new string[] { "Administrator" });
            // Create Retail User
            var user2 = new ApplicationUser()
            {
                UserName = "retail@retail.com",
                Email = "retail@retail.com",
                EmailConfirmed = true
            };
            manager.Create(user2, "Retail-1234");
            var retail = manager.FindByName("retail@retail.com");
            manager.AddToRoles(retail.Id, new string[] { "Retail" });

            // Create Wholesale User
            var user3 = new ApplicationUser()
            {
                UserName = "wholesale@wholesale.com",
                Email = "wholesale@wholesale.com",
                EmailConfirmed = true
            };
            manager.Create(user3, "Wholesale-1234");
            var wholesale = manager.FindByName("wholesale@wholesale.com");
            manager.AddToRoles(wholesale.Id, new string[] { "Wholesale" });
        }
       
    }
}
