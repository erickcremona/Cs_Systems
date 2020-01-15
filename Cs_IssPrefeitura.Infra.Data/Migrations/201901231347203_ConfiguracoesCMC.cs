namespace Cs_IssPrefeitura.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConfiguracoesCMC : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Config", "Cmc", c => c.String(maxLength: 100, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Config", "Cmc");
        }
    }
}
