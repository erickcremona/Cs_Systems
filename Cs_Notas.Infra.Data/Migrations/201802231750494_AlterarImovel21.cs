namespace Cs_Notas.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterarImovel21 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Imovel", "DescricaoTransacao", c => c.String(maxLength: 60, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Imovel", "DescricaoTransacao", c => c.String(maxLength: 15, unicode: false));
        }
    }
}
