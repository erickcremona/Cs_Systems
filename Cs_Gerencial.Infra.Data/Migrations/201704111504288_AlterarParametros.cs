namespace Cs_Gerencial.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterarParametros : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parametros", "AlicotaIss", c => c.Decimal(nullable: false, precision: 9, scale: 3));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Parametros", "AlicotaIss");
        }
    }
}
