namespace Cs_Notas.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterarUsuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Usuario", "LiberarSelo", c => c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"));
            DropColumn("dbo.Usuario", "LiberarAto");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Usuario", "LiberarAto", c => c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"));
            DropColumn("dbo.Usuario", "LiberarSelo");
        }
    }
}
