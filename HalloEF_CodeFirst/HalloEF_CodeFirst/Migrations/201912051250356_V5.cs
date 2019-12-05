namespace HalloEF_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Essen", "Schmeckt", c => c.Boolean(nullable: false));
            AddColumn("dbo.Stand", "IsOffen", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stand", "IsOffen");
            DropColumn("dbo.Essen", "Schmeckt");
        }
    }
}
