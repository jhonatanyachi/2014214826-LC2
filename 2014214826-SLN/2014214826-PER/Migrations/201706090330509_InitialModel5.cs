namespace _2014214826_PER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel5 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Carroes", newName: "Carros");
            AlterColumn("dbo.Carros", "NumSerieMotor", c => c.String(nullable: false));
            AlterColumn("dbo.Carros", "NumSerieChasis", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Carros", "NumSerieChasis", c => c.String());
            AlterColumn("dbo.Carros", "NumSerieMotor", c => c.String());
            RenameTable(name: "dbo.Carros", newName: "Carroes");
        }
    }
}
