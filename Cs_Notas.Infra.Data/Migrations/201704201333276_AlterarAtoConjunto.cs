namespace Cs_Notas.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterarAtoConjunto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AtoConjuntos", "TabelaCustas", c => c.String(maxLength: 100, unicode: false));
            DropColumn("dbo.AtoConjuntos", "Codigo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AtoConjuntos", "Codigo", c => c.Int());
            DropColumn("dbo.AtoConjuntos", "TabelaCustas");
        }
    }
}
