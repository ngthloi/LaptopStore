namespace AppleWebsite.IdentityMigration
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewFieldUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Birthday", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "City", c => c.String());
            AddColumn("dbo.AspNetUsers", "imgURL", c => c.String());
            AddColumn("dbo.AspNetUsers", "Fullname", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Fullname");
            DropColumn("dbo.AspNetUsers", "imgURL");
            DropColumn("dbo.AspNetUsers", "City");
            DropColumn("dbo.AspNetUsers", "Birthday");
        }
    }
}
