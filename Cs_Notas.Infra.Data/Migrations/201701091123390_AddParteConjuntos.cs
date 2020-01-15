namespace Cs_Notas.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddParteConjuntos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ParteConjuntos",
                c => new
                    {
                        ParteConjuntosId = c.Int(nullable: false, identity: true),
                        IdAto = c.Int(nullable: false),
                        IdNome = c.Int(nullable: false),
                        IdConjunto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ParteConjuntosId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ParteConjuntos");
        }
    }
}
