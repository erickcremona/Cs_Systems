namespace Cs_IssPrefeitura.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NomeArquivoConfig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Config", "NomeArquivoImportando", c => c.String(maxLength: 300, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Config", "NomeArquivoImportando");
        }
    }
}
