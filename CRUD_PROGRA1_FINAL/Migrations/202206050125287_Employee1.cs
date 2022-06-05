namespace CRUD_PROGRA1_FINAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Employee1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "ImageUrl");
        }
    }
}
