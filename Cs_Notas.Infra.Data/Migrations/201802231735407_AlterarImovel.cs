namespace Cs_Notas.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterarImovel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Imovel", "TipoTransacao", c => c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"));
            AlterColumn("dbo.Imovel", "DescricaoTransacao", c => c.String(maxLength: 15, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Imovel", "DescricaoTransacao", c => c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"));
            AlterColumn("dbo.Imovel", "TipoTransacao", c => c.String(maxLength: 15, unicode: false));
        }
    }
}
