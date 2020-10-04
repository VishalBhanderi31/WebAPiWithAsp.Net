namespace WebApiWithASP.Net.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewOfficeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewOffices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Location = c.String(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NewOffices");
        }
    }
}
