namespace Cs_Notas.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Complemento2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Complementos", "Enviado", c => c.String(maxLength: 1, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Complementos", "Enviado");
        }
    }
}
