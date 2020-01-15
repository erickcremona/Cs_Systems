namespace Cs_Notas.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterarEscritura1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Escrituras", "IdCodigoTabelaCustas", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Escrituras", "IdCodigoTabelaCustas");
        }
    }
}
