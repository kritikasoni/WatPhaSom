using System.Collections.Generic;

namespace Models.Migrations

{
    using Entities;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.Repository.EfDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Models.Repository.EfDbContext context)
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
            context.Products.AddOrUpdate(p => p.Name,
               new Product { Name = "Rice", WholesalePrice = 30.00, RetailPrice = 20.00 ,Description = "For Eat", Image = "http://culturalhealthsolutions.com/wp-content/uploads/2015/09/rice.jpg", },
               new Product { Name = "Shampoo", WholesalePrice = 60.00, RetailPrice = 20.00, Description = "For Use", Image = "http://ecx.images-amazon.com/images/I/81UIfFxHSKL._SL1500_.jpg" },
               new Product { Name = "Coffee Bean", WholesalePrice = 500.00, RetailPrice = 100.00, Description = "For Eat", Image = "http://www.drterlep.com/wp-content/uploads/cup-of-coffee.jpg" },
               new Product { Name = "Rice Berry", WholesalePrice = 70.00, RetailPrice = 30.00, Description = "For Eat", Image = "http://mom.girlstalkinsmack.com/image/122012/21/173837834.jpg"},
               new Product { Name = "Pan", WholesalePrice = 500.00, RetailPrice = 300.00, Description = "For Use", Image = "http://pngimg.com/upload/frying_pan_PNG8347.png" }
           );
        }
    }
}
