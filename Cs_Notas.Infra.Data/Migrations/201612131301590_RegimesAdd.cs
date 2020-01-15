namespace Cs_Notas.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RegimesAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Regimes",
                c => new
                    {
                        RegimesId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 30, unicode: false),
                        Censec = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.RegimesId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Regimes");
        }
    }
}
