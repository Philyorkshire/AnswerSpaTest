namespace AnswerSpaTest.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Colours",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsEnabled = c.Boolean(nullable: false),
                        Person_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Person_Id)
                .Index(t => t.Person_Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        IsAuthorised = c.Boolean(nullable: false),
                        IsValid = c.Boolean(nullable: false),
                        IsEnabled = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Colours", "Person_Id", "dbo.People");
            DropIndex("dbo.Colours", new[] { "Person_Id" });
            DropTable("dbo.People");
            DropTable("dbo.Colours");
        }
    }
}
