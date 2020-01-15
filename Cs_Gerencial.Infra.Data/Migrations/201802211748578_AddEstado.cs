namespace Cs_Gerencial.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEstado : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Serventia", "Estado", c => c.String(maxLength: 100, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Serventia", "Estado");
        }
    }
}
