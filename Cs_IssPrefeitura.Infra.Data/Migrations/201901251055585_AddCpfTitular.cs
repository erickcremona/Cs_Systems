namespace Cs_IssPrefeitura.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCpfTitular : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Config", "CpfTitular", c => c.String(maxLength: 14, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Config", "CpfTitular");
        }
    }
}
