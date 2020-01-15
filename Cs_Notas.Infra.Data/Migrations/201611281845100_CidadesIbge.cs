namespace Cs_Notas.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CidadesIbge : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CidadesIbge",
                c => new
                    {
                        CidadesIbgeId = c.Int(nullable: false, identity: true),
                        Codigo = c.Int(nullable: false),
                        Uf = c.String(maxLength: 2, unicode: false),
                        Nome = c.String(maxLength: 60, unicode: false),
                    })
                .PrimaryKey(t => t.CidadesIbgeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CidadesIbge");
        }
    }
}
