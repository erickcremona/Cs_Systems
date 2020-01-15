namespace Cs_Gerencial.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TabelaCustas",
                c => new
                    {
                        TabelaCustasId = c.Int(nullable: false, identity: true),
                        Atribuicao = c.Int(nullable: false),
                        Ordem = c.Int(nullable: false),
                        Tabela = c.String(maxLength: 20, unicode: false),
                        Item = c.String(maxLength: 20, unicode: false),
                        SubItem = c.String(maxLength: 20, unicode: false),
                        Descricao = c.String(maxLength: 100, unicode: false),
                        Valor = c.Decimal(nullable: false, precision: 9, scale: 3),
                    })
                .PrimaryKey(t => t.TabelaCustasId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TabelaCustas");
        }
    }
}
