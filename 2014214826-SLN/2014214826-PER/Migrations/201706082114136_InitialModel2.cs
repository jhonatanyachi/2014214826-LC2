namespace _2014214826_PER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carroes", "Llanta_LlantaId", "dbo.Llantas");
            DropForeignKey("dbo.Carroes", "Propietario_PropietarioId", "dbo.Propietarios");
            DropIndex("dbo.Carroes", new[] { "Propietario_PropietarioId" });
            DropIndex("dbo.Carroes", new[] { "Llanta_LlantaId" });
            RenameColumn(table: "dbo.Carroes", name: "Propietario_PropietarioId", newName: "PropietarioId");
            AlterColumn("dbo.Carroes", "PropietarioId", c => c.Int(nullable: false));
            CreateIndex("dbo.Carroes", "PropietarioId");
            AddForeignKey("dbo.Carroes", "PropietarioId", "dbo.Propietarios", "PropietarioId", cascadeDelete: true);
            DropColumn("dbo.Carroes", "Llanta_LlantaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carroes", "Llanta_LlantaId", c => c.Int());
            DropForeignKey("dbo.Carroes", "PropietarioId", "dbo.Propietarios");
            DropIndex("dbo.Carroes", new[] { "PropietarioId" });
            AlterColumn("dbo.Carroes", "PropietarioId", c => c.Int());
            RenameColumn(table: "dbo.Carroes", name: "PropietarioId", newName: "Propietario_PropietarioId");
            CreateIndex("dbo.Carroes", "Llanta_LlantaId");
            CreateIndex("dbo.Carroes", "Propietario_PropietarioId");
            AddForeignKey("dbo.Carroes", "Propietario_PropietarioId", "dbo.Propietarios", "PropietarioId");
            AddForeignKey("dbo.Carroes", "Llanta_LlantaId", "dbo.Llantas", "LlantaId");
        }
    }
}
