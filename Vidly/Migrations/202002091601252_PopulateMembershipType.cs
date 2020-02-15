namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        SignUpFee = c.Short(nullable: false),
                        DurationInMonth = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "MembershipTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Customers", "MembershipTypeId");
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);

            Sql("Insert into MembershipTypes(Id,SignUpFee,DurationInMonth, DiscountRate) values(1,0,0,0)");
            Sql("Insert into MembershipTypes(Id,SignUpFee,DurationInMonth, DiscountRate) values(2,2000,3,10)");
            Sql("Insert into MembershipTypes(Id,SignUpFee,DurationInMonth, DiscountRate) values(3,5000,9,15)");
            Sql("Insert into MembershipTypes(Id,SignUpFee,DurationInMonth, DiscountRate) values(4,7000,12,20)");

        }

        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            DropColumn("dbo.Customers", "MembershipTypeId");
            DropTable("dbo.MembershipTypes");
        }
    }
}
