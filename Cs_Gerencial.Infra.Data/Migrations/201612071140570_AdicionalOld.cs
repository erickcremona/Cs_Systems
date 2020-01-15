namespace Cs_Gerencial.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionalOld : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Adicional", "Nomes");
            DropColumn("dbo.Adicional", "Paginas");
            DropColumn("dbo.Adicional", "Vias");
            DropColumn("dbo.Adicional", "Diligencias");
            DropColumn("dbo.Adicional", "Mapa");
            DropColumn("dbo.Adicional", "Recalcular");
            DropColumn("dbo.Adicional", "Exportar");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Adicional", "Exportar", c => c.String(maxLength: 1, unicode: false));
            AddColumn("dbo.Adicional", "Recalcular", c => c.String(maxLength: 1, unicode: false));
            AddColumn("dbo.Adicional", "Mapa", c => c.String(maxLength: 1, unicode: false));
            AddColumn("dbo.Adicional", "Diligencias", c => c.Int());
            AddColumn("dbo.Adicional", "Vias", c => c.Int());
            AddColumn("dbo.Adicional", "Paginas", c => c.Int());
            AddColumn("dbo.Adicional", "Nomes", c => c.Int());
        }
    }
}
