namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedgender : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "GenderId", c => c.Byte(nullable: false));
            AddColumn("dbo.Customers", "Gender_Id", c => c.Int());
            CreateIndex("dbo.Customers", "Gender_Id");
            AddForeignKey("dbo.Customers", "Gender_Id", "dbo.Genders", "Id");

            Sql("insert into genders (name) values('Male')");
            Sql("insert into genders (name) values('Female')");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "Gender_Id", "dbo.Genders");
            DropIndex("dbo.Customers", new[] { "Gender_Id" });
            DropColumn("dbo.Customers", "Gender_Id");
            DropColumn("dbo.Customers", "GenderId");
            DropTable("dbo.Genders");
        }
    }
}
