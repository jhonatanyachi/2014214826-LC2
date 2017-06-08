namespace _2014214826_PER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ensambladora", "_Ensambladora", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ensambladora", "_Ensambladora");
        }
    }
}
