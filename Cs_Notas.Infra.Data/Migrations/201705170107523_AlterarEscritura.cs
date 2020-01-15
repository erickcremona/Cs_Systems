namespace Cs_Notas.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterarEscritura : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Escrituras", "TipoAtoCesdi", c => c.Int());
            AlterColumn("dbo.Escrituras", "NaturezaCensec", c => c.Int());
            DropColumn("dbo.Escrituras", "TipoAtoCensec");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Escrituras", "TipoAtoCensec", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.Escrituras", "NaturezaCensec", c => c.String(maxLength: 100, unicode: false));
            DropColumn("dbo.Escrituras", "TipoAtoCesdi");
        }
    }
}
