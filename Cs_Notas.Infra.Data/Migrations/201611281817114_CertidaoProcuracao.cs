namespace Cs_Notas.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CertidaoProcuracao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CertidaoProcuracao",
                c => new
                    {
                        CertidaoProcuracaoId = c.Int(nullable: false, identity: true),
                        IdReferencia = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false, storeType: "date"),
                        Selo = c.String(maxLength: 9, unicode: false),
                        Cpf1 = c.String(maxLength: 11, unicode: false),
                        Cpf2 = c.String(maxLength: 11, unicode: false),
                        Cpf3 = c.String(maxLength: 11, unicode: false),
                        TipoCobranca = c.String(maxLength: 2, unicode: false),
                        Emolumentos = c.Decimal(precision: 18, scale: 2),
                        Fetj = c.Decimal(precision: 18, scale: 2),
                        Fundperj = c.Decimal(precision: 18, scale: 2),
                        Funprj = c.Decimal(precision: 18, scale: 2),
                        Funarpen = c.Decimal(precision: 18, scale: 2),
                        Pmcmv = c.Decimal(precision: 18, scale: 2),
                        Iss = c.Decimal(precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Login = c.String(maxLength: 100, unicode: false),
                        DataModificado = c.DateTime(storeType: "date"),
                        HoraModificado = c.DateTime(precision: 0),
                        Aleatorio = c.String(maxLength: 3, unicode: false),
                        Servico = c.String(maxLength: 100, unicode: false),
                        UF_Origem = c.String(maxLength: 2, unicode: false),
                        Recibo = c.String(maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.CertidaoProcuracaoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CertidaoProcuracao");
        }
    }
}
