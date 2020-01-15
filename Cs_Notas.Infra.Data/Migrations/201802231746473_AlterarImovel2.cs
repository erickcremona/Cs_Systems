namespace Cs_Notas.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterarImovel2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Imovel", "TipoTransacao", c => c.String(maxLength: 2, fixedLength: true, unicode: false, storeType: "char"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Imovel", "TipoTransacao", c => c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"));
        }
    }
}
