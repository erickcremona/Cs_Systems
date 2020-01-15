namespace Cs_Notas.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NomeUpdate1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Nomes", "NumeroConjuge", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Nomes", "NumeroConjuge");
        }
    }
}
