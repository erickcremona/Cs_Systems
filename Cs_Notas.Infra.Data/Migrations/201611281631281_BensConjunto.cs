namespace Cs_Notas.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BensConjunto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BensAtosConjuntos",
                c => new
                    {
                        BensAtosConjuntosID = c.Int(nullable: false, identity: true),
                        IdAto = c.Int(nullable: false),
                        IdImovel = c.Int(nullable: false),
                        IdAtoConjunto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BensAtosConjuntosID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BensAtosConjuntos");
        }
    }
}
