namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_delete_skillvalue : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Skills", "SkillValue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Skills", "SkillValue", c => c.Int(nullable: false));
        }
    }
}
