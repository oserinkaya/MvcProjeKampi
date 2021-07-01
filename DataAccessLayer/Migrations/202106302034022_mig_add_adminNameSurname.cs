namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_adminNameSurname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminName", c => c.String(maxLength: 50));
            AddColumn("dbo.Admins", "AdminSurname", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "AdminSurname");
            DropColumn("dbo.Admins", "AdminName");
        }
    }
}
