namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_delete_skillstatus : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Skills", "SkillStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Skills", "SkillStatus", c => c.Boolean(nullable: false));
        }
    }
}
