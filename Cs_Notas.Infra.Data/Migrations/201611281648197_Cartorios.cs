namespace Cs_Notas.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cartorios : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cartorios",
                c => new
                    {
                        CartorioId = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.CartorioId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cartorios");
        }
    }
}
