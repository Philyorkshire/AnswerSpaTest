namespace AnswerSpaTest.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialUp : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Colours", "Person_Id", "dbo.People");
            DropIndex("dbo.Colours", new[] { "Person_Id" });
            RenameColumn(table: "dbo.Colours", name: "Id", newName: "ColourId");
            RenameColumn(table: "dbo.People", name: "Id", newName: "PersonId");
            CreateTable(
                "dbo.FavouriteColours",
                c => new
                    {
                        PersonId = c.Int(nullable: false),
                        ColourId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PersonId, t.ColourId })
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .ForeignKey("dbo.Colours", t => t.ColourId, cascadeDelete: true)
                .Index(t => t.PersonId)
                .Index(t => t.ColourId);
            
            DropColumn("dbo.Colours", "Person_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Colours", "Person_Id", c => c.Int());
            DropForeignKey("dbo.FavouriteColours", "ColourId", "dbo.Colours");
            DropForeignKey("dbo.FavouriteColours", "PersonId", "dbo.People");
            DropIndex("dbo.FavouriteColours", new[] { "ColourId" });
            DropIndex("dbo.FavouriteColours", new[] { "PersonId" });
            DropTable("dbo.FavouriteColours");
            RenameColumn(table: "dbo.People", name: "PersonId", newName: "Id");
            RenameColumn(table: "dbo.Colours", name: "ColourId", newName: "Id");
            CreateIndex("dbo.Colours", "Person_Id");
            AddForeignKey("dbo.Colours", "Person_Id", "dbo.People", "Id");
        }
    }
}
