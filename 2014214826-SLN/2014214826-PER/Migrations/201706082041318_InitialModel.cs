namespace _2014214826_PER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Asientos",
                c => new
                    {
                        AsientoId = c.Int(nullable: false, identity: true),
                        NumSerieAsiento = c.String(nullable: false, maxLength: 10),
                        CinturonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AsientoId)
                .ForeignKey("dbo.Cinturones", t => t.CinturonId, cascadeDelete: true)
                .Index(t => t.CinturonId);
            
            CreateTable(
                "dbo.Carroes",
                c => new
                    {
                        CarroId = c.Int(nullable: false, identity: true),
                        NumSerieMotor = c.String(),
                        NumSerieChasis = c.String(),
                        ParabrisasId = c.Int(nullable: false),
                        VolanteId = c.Int(nullable: false),
                        TipoCarro = c.Int(nullable: false),
                        EnsambladoraId = c.Int(nullable: false),
                        TipoAuto = c.Int(),
                        TipoBus = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Propietario_PropietarioId = c.Int(),
                        Asiento_AsientoId = c.Int(),
                        Llanta_LlantaId = c.Int(),
                    })
                .PrimaryKey(t => t.CarroId)
                .ForeignKey("dbo.Ensambladora", t => t.EnsambladoraId, cascadeDelete: true)
                .ForeignKey("dbo.Parabrisas", t => t.ParabrisasId, cascadeDelete: true)
                .ForeignKey("dbo.Propietarios", t => t.Propietario_PropietarioId)
                .ForeignKey("dbo.Volantes", t => t.VolanteId, cascadeDelete: true)
                .ForeignKey("dbo.Asientos", t => t.Asiento_AsientoId)
                .ForeignKey("dbo.Llantas", t => t.Llanta_LlantaId)
                .Index(t => t.ParabrisasId)
                .Index(t => t.VolanteId)
                .Index(t => t.EnsambladoraId)
                .Index(t => t.Propietario_PropietarioId)
                .Index(t => t.Asiento_AsientoId)
                .Index(t => t.Llanta_LlantaId);
            
            CreateTable(
                "dbo.Ensambladora",
                c => new
                    {
                        EnsambladoraId = c.Int(nullable: false, identity: true),
                        _Ensambladora = c.String(),
                        TipoCarro = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EnsambladoraId);
            
            CreateTable(
                "dbo.Parabrisas",
                c => new
                    {
                        ParabrisasId = c.Int(nullable: false, identity: true),
                        NumSerie = c.String(nullable: false, maxLength: 10),
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
                    })
                .PrimaryKey(t => t.PropietarioId);
            
            CreateTable(
                "dbo.Volantes",
                c => new
                    {
                        VolanteId = c.Int(nullable: false, identity: true),
                        NumSerie = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.VolanteId);
            
            CreateTable(
                "dbo.Cinturones",
                c => new
                    {
                        CinturonId = c.Int(nullable: false, identity: true),
                        NumSerieCinturon = c.String(nullable: false, maxLength: 10),
                        Metraje = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CinturonId);
            
            CreateTable(
                "dbo.Llantas",
                c => new
                    {
                        LlantaId = c.Int(nullable: false, identity: true),
                        NumSerie = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.LlantaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carroes", "Llanta_LlantaId", "dbo.Llantas");
            DropForeignKey("dbo.Asientos", "CinturonId", "dbo.Cinturones");
            DropForeignKey("dbo.Carroes", "Asiento_AsientoId", "dbo.Asientos");
            DropForeignKey("dbo.Carroes", "VolanteId", "dbo.Volantes");
            DropForeignKey("dbo.Carroes", "Propietario_PropietarioId", "dbo.Propietarios");
            DropForeignKey("dbo.Carroes", "ParabrisasId", "dbo.Parabrisas");
            DropForeignKey("dbo.Carroes", "EnsambladoraId", "dbo.Ensambladora");
            DropIndex("dbo.Carroes", new[] { "Llanta_LlantaId" });
            DropIndex("dbo.Carroes", new[] { "Asiento_AsientoId" });
            DropIndex("dbo.Carroes", new[] { "Propietario_PropietarioId" });
            DropIndex("dbo.Carroes", new[] { "EnsambladoraId" });
            DropIndex("dbo.Carroes", new[] { "VolanteId" });
            DropIndex("dbo.Carroes", new[] { "ParabrisasId" });
            DropIndex("dbo.Asientos", new[] { "CinturonId" });
            DropTable("dbo.Llantas");
            DropTable("dbo.Cinturones");
            DropTable("dbo.Volantes");
            DropTable("dbo.Propietarios");
            DropTable("dbo.Parabrisas");
            DropTable("dbo.Ensambladora");
            DropTable("dbo.Carroes");
            DropTable("dbo.Asientos");
        }
    }
}
