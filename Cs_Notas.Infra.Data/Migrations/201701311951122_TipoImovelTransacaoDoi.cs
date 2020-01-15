namespace Cs_Notas.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TipoImovelTransacaoDoi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TipoImovel",
                c => new
                    {
                        TipoImovelId = c.Int(nullable: false, identity: true),
                        Codigo = c.Int(nullable: false),
                        Descricao = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.TipoImovelId);
            
            CreateTable(
                "dbo.TransacaoDoi",
                c => new
                    {
                        TransacaoDoiId = c.Int(nullable: false, identity: true),
                        Codigo = c.Int(nullable: false),
                        Descricao = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.TransacaoDoiId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TransacaoDoi");
            DropTable("dbo.TipoImovel");
        }
    }
}
