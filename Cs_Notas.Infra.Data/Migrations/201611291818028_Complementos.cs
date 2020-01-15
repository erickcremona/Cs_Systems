namespace Cs_Notas.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Complementos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Complementos",
                c => new
                    {
                        ComplementoId = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(storeType: "date"),
                        Cct = c.String(maxLength: 9, unicode: false),
                        TipoCobranca = c.String(maxLength: 2, unicode: false),
                        IdAto = c.Int(),
                        DataPratica = c.DateTime(storeType: "date"),
                        Livro = c.Int(),
                        FolhaInicio = c.Int(),
                        FolhaFim = c.Int(),
                        NumeroAto = c.Int(),
                        Selo = c.String(maxLength: 9, unicode: false),
                        Aleatorio = c.String(maxLength: 3, unicode: false),
                        Emolumentos = c.Decimal(precision: 18, scale: 2),
                        Fetj = c.Decimal(precision: 18, scale: 2),
                        Fundperj = c.Decimal(precision: 18, scale: 2),
                        Funprj = c.Decimal(precision: 18, scale: 2),
                        Funarpen = c.Decimal(precision: 18, scale: 2),
                        Pmcmv = c.Decimal(precision: 18, scale: 2),
                        Iss = c.Decimal(precision: 18, scale: 2),
                        Total = c.Decimal(precision: 18, scale: 2),
                        NomeEscrevente = c.String(maxLength: 40, unicode: false),
                        CpfEscrevente = c.String(maxLength: 11, unicode: false),
                    })
                .PrimaryKey(t => t.ComplementoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Complementos");
        }
    }
}
