namespace Cs_Notas.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Censec : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Censec",
                c => new
                    {
                        CensecId = c.Int(nullable: false, identity: true),
                        Codigo = c.Int(nullable: false),
                        Descricao = c.String(maxLength: 80, unicode: false),
                    })
                .PrimaryKey(t => t.CensecId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Censec");
        }
    }
}
