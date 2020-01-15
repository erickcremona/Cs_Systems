namespace Cs_Notas.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Naturezas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Naturezas",
                c => new
                    {
                        NaturezasId = c.Int(nullable: false, identity: true),
                        Codigo = c.Int(nullable: false),
                        Descricao = c.String(maxLength: 100, unicode: false),
                        Doi = c.String(maxLength: 1, unicode: false),
                        Censec = c.String(maxLength: 1, unicode: false),
                        Cep = c.Int(nullable: false),
                        Tipo = c.String(maxLength: 1, unicode: false),
                    })
                .PrimaryKey(t => t.NaturezasId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Naturezas");
        }
    }
}
