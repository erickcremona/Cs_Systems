namespace Cs_Gerencial.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateServentiasOutras : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServentiasOutras", "Codigo", c => c.Int(nullable: false));
            DropColumn("dbo.ServentiasOutras", "CodigoServentia");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ServentiasOutras", "CodigoServentia", c => c.Int(nullable: false));
            DropColumn("dbo.ServentiasOutras", "Codigo");
        }
    }
}
