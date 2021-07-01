namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_skillstatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Skills", "SkillStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Skills", "SkillStatus");
        }
    }
}
