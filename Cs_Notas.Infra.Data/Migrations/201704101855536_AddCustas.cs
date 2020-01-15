namespace Cs_Notas.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItensCustas",
                c => new
                    {
                        ItensCustasId = c.Int(nullable: false, identity: true),
                        IdAto = c.Int(nullable: false),
                        Tabela = c.String(maxLength: 20, unicode: false),
                        Item = c.String(maxLength: 20, unicode: false),
                        SubItem = c.String(maxLength: 20, unicode: false),
                        Quantidade = c.String(maxLength: 10, unicode: false),
                        Complemento = c.String(maxLength: 50, unicode: false),
                        Excessao = c.String(maxLength: 50, unicode: false),
                        Valor = c.Decimal(nullable: false, precision: 9, scale: 3),
                        Total = c.Decimal(nullable: false, precision: 9, scale: 3),
                        Descricao = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.ItensCustasId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ItensCustas");
        }
    }
}
