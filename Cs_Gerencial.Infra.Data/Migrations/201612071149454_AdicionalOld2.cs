namespace Cs_Gerencial.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionalOld2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Adicional", "Iss");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Adicional", "Iss", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
