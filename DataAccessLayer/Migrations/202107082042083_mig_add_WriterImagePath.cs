namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_WriterImagePath : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writers", "WriterImagePath");
        }
    }
}
