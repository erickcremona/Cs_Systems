namespace Cs_Gerencial.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAdicional : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Adicional", "Iss", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Adicional", "Iss");
        }
    }
}
