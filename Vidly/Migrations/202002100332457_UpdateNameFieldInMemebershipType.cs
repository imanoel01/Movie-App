namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNameFieldInMemebershipType : DbMigration
    {
        public override void Up()
        {
            Sql("update MembershipTypes set Name=\'PayAsYouGo\' where id = 1");
            Sql("update MembershipTypes set Name=\'Monthly\' where id = 2");
            Sql("update MembershipTypes set Name=\'3 Quarter Of the Year\' where id = 3");
            Sql("update MembershipTypes set Name=\'Yearly\' where id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
