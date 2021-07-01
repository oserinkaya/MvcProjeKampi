namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_skillvalue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Skills", "SkillValue", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Skills", "SkillValue");
        }
    }
}
