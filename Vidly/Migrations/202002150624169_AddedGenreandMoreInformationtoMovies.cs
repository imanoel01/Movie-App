namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGenreandMoreInformationtoMovies : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "Stock", c => c.Byte(nullable: false));
            AddColumn("dbo.Movies", "GenreId", c => c.Byte(nullable: false));
            AddColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "Genre_Id", c => c.Int());
            CreateIndex("dbo.Movies", "Genre_Id");
            AddForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres", "Id");


            Sql("insert into Genres (name) values('Comedy')");
            Sql("insert into Genres (name) values('Action')");
            Sql("insert into Genres (name) values('Love')");
            Sql("insert into Genres (name) values('Romance')");
            Sql("insert into Genres (name) values('Family')");
            Sql("insert into Genres (name) values('Horror')");
            Sql("insert into Genres (name) values('Epic')");



        }

        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genre_Id" });
            DropColumn("dbo.Movies", "Genre_Id");
            DropColumn("dbo.Movies", "DateAdded");
            DropColumn("dbo.Movies", "GenreId");
            DropColumn("dbo.Movies", "Stock");
            DropColumn("dbo.Movies", "ReleaseDate");
            DropTable("dbo.Genres");
        }
    }
}
