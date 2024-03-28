namespace AppleWebsite.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AppleWebsite.Models.MTDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AppleWebsite.Models.AppleDBContext";
        }

        protected override void Seed(AppleWebsite.Models.MTDBContext context)
        {
           
        }
    }
}
