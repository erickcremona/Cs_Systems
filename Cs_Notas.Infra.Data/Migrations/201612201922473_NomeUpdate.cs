namespace Cs_Notas.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NomeUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Nomes", "Participacao", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Nomes", "Participacao", c => c.Single());
        }
    }
}
