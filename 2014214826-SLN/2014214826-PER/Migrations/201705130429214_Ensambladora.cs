namespace _2014214826_PER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ensambladora : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Asientos",
                c => new
                    {
                        AsientoId = c.Int(nullable: false),
                        NumSerie = c.String(nullable: false, maxLength: 10),
                        CinturonId = c.Int(nullable: false),
                        CarroId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AsientoId)
                .ForeignKey("dbo.Carroes", t => t.CarroId, cascadeDelete: true)
                .ForeignKey("dbo.Cinturones", t => t.AsientoId)
                .Index(t => t.AsientoId)
                .Index(t => t.CarroId);
            
            CreateTable(
                "dbo.Carroes",
                c => new
                    {
                        CarroId = c.Int(nullable: false),
                        NumSerieMotor = c.String(),
                        NumSerieChasis = c.String(),
                        PropietarioId = c.Int(nullable: false),
                        ParabrisasId = c.Int(nullable: false),
                        VolanteId = c.Int(nullable: false),
                        TipoCarro = c.Int(nullable: false),
                        EnsambladoraId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CarroId)
                .ForeignKey("dbo.Ensambladora", t => t.EnsambladoraId, cascadeDelete: true)
                .ForeignKey("dbo.Parabrisas", t => t.CarroId)
                .ForeignKey("dbo.Propietarios", t => t.CarroId)
                .ForeignKey("dbo.Volantes", t => t.CarroId)
                .Index(t => t.CarroId)
                .Index(t => t.EnsambladoraId);
            
            CreateTable(
                "dbo.Ensambladora",
                c => new
                    {
                        EnsambladoraId = c.Int(nullable: false, identity: true),
                        TipoCarro = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EnsambladoraId);
            
            CreateTable(
                "dbo.Llantas",
                c => new
                    {
                        LlantaId = c.Int(nullable: false, identity: true),
                        NumSerie = c.String(nullable: false),
                        CarroId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LlantaId)
                .ForeignKey("dbo.Carroes", t => t.CarroId, cascadeDelete: true)
                .Index(t => t.CarroId);
            
            CreateTable(
                "dbo.Parabrisas",
                c => new
                    {
                        ParabrisasId = c.Int(nullable: false, identity: true),
                        NumSerie = c.String(nullable: false, maxLength: 10),
                        CarroId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ParabrisasId);
            
            CreateTable(
                "dbo.Propietarios",
                c => new
                    {
                        PropietarioId = c.Int(nullable: false, identity: true),
                        DNI = c.String(nullable: false, maxLength: 8),
                        Nombres = c.String(),
                        Apellidos = c.String(),
                        LicenciaConducir = c.String(nullable: false, maxLength: 9),
                        CarroId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PropietarioId);
            
            CreateTable(
                "dbo.Volantes",
                c => new
                    {
                        VolanteId = c.Int(nullable: false, identity: true),
                        NumSerie = c.String(nullable: false, maxLength: 10),
                        CarroId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VolanteId);
            
            CreateTable(
                "dbo.Cinturones",
                c => new
                    {
                        CinturonId = c.Int(nullable: false, identity: true),
                        NumSerie = c.String(nullable: false, maxLength: 10),
                        Metraje = c.Int(nullable: false),
                        AsientoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CinturonId);
            
            CreateTable(
                "dbo.Automoviles",
                c => new
                    {
                        CarroId = c.Int(nullable: false),
                        AutomovilId = c.Int(nullable: false),
                        TipoAuto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CarroId)
                .ForeignKey("dbo.Carroes", t => t.CarroId)
                .Index(t => t.CarroId);
            
            CreateTable(
                "dbo.Buses",
                c => new
                    {
                        CarroId = c.Int(nullable: false),
                        BusId = c.Int(nullable: false),
                        TipoBus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CarroId)
                .ForeignKey("dbo.Carroes", t => t.CarroId)
                .Index(t => t.CarroId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Buses", "CarroId", "dbo.Carroes");
            DropForeignKey("dbo.Automoviles", "CarroId", "dbo.Carroes");
            DropForeignKey("dbo.Asientos", "AsientoId", "dbo.Cinturones");
            DropForeignKey("dbo.Asientos", "CarroId", "dbo.Carroes");
            DropForeignKey("dbo.Carroes", "CarroId", "dbo.Volantes");
            DropForeignKey("dbo.Carroes", "CarroId", "dbo.Propietarios");
            DropForeignKey("dbo.Carroes", "CarroId", "dbo.Parabrisas");
            DropForeignKey("dbo.Llantas", "CarroId", "dbo.Carroes");
            DropForeignKey("dbo.Carroes", "EnsambladoraId", "dbo.Ensambladora");
            DropIndex("dbo.Buses", new[] { "CarroId" });
            DropIndex("dbo.Automoviles", new[] { "CarroId" });
            DropIndex("dbo.Llantas", new[] { "CarroId" });
            DropIndex("dbo.Carroes", new[] { "EnsambladoraId" });
            DropIndex("dbo.Carroes", new[] { "CarroId" });
            DropIndex("dbo.Asientos", new[] { "CarroId" });
            DropIndex("dbo.Asientos", new[] { "AsientoId" });
            DropTable("dbo.Buses");
            DropTable("dbo.Automoviles");
            DropTable("dbo.Cinturones");
            DropTable("dbo.Volantes");
            DropTable("dbo.Propietarios");
            DropTable("dbo.Parabrisas");
            DropTable("dbo.Llantas");
            DropTable("dbo.Ensambladora");
            DropTable("dbo.Carroes");
            DropTable("dbo.Asientos");
        }
    }
}
