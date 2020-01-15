namespace Cs_Gerencial.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionalAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adicional",
                c => new
                    {
                        AdicionalId = c.Int(nullable: false, identity: true),
                        Ativo = c.String(maxLength: 1, unicode: false),
                        Ordem = c.Int(),
                        Atribuicao = c.Int(),
                        Codigo = c.Int(),
                        Tipo = c.String(maxLength: 2, unicode: false),
                        Descricao = c.String(maxLength: 250, unicode: false),
                        Emolumentos = c.Decimal(precision: 18, scale: 2),
                        Fetj = c.Decimal(precision: 18, scale: 2),
                        Fundperj = c.Decimal(precision: 18, scale: 2),
                        Funperj = c.Decimal(precision: 18, scale: 2),
                        Funarpen = c.Decimal(precision: 18, scale: 2),
                        Pmcmv = c.Decimal(precision: 18, scale: 2),
                        Mutua = c.Decimal(precision: 18, scale: 2),
                        Iss = c.Decimal(precision: 18, scale: 2),
                        Acoterj = c.Decimal(precision: 18, scale: 2),
                        Distribuicao = c.Decimal(precision: 18, scale: 2),
                        Total = c.Decimal(precision: 18, scale: 2),
                        Minimo = c.Decimal(precision: 18, scale: 2),
                        Maximo = c.Decimal(precision: 18, scale: 2),
                        Dias = c.Int(),
                        Convenio = c.String(maxLength: 1, unicode: false),
                        Nomes = c.Int(),
                        Paginas = c.Int(),
                        Vias = c.Int(),
                        Diligencias = c.Int(),
                        Mapa = c.String(maxLength: 1, unicode: false),
                        Recalcular = c.String(maxLength: 1, unicode: false),
                        Exportar = c.String(maxLength: 1, unicode: false),
                    })
                .PrimaryKey(t => t.AdicionalId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Adicional");
        }
    }
}
