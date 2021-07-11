namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_delete_writerimageprop : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Writers", "WriterImagePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Writers", "WriterImagePath", c => c.String());
        }
    }
}
