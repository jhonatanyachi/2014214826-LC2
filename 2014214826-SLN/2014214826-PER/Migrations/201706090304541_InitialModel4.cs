namespace _2014214826_PER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carroes", "Asiento_AsientoId", "dbo.Asientos");
            DropIndex("dbo.Carroes", new[] { "Asiento_AsientoId" });
            RenameColumn(table: "dbo.Carroes", name: "Asiento_AsientoId", newName: "AsientoId");
            AddColumn("dbo.Carroes", "LlantaId", c => c.Int(nullable: false));
            AlterColumn("dbo.Carroes", "AsientoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Carroes", "AsientoId");
            CreateIndex("dbo.Carroes", "LlantaId");
            AddForeignKey("dbo.Carroes", "LlantaId", "dbo.Llantas", "LlantaId", cascadeDelete: true);
            AddForeignKey("dbo.Carroes", "AsientoId", "dbo.Asientos", "AsientoId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carroes", "AsientoId", "dbo.Asientos");
            DropForeignKey("dbo.Carroes", "LlantaId", "dbo.Llantas");
            DropIndex("dbo.Carroes", new[] { "LlantaId" });
            DropIndex("dbo.Carroes", new[] { "AsientoId" });
            AlterColumn("dbo.Carroes", "AsientoId", c => c.Int());
            DropColumn("dbo.Carroes", "LlantaId");
            RenameColumn(table: "dbo.Carroes", name: "AsientoId", newName: "Asiento_AsientoId");
            CreateIndex("dbo.Carroes", "Asiento_AsientoId");
            AddForeignKey("dbo.Carroes", "Asiento_AsientoId", "dbo.Asientos", "AsientoId");
        }
    }
}
