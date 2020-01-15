namespace Cs_Notas.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterarImovel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Imovel", "FormaAlienacao", c => c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"));
            AlterColumn("dbo.Imovel", "ValorNaoConsta", c => c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"));
            AlterColumn("dbo.Imovel", "Construcao", c => c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Imovel", "Construcao", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.Imovel", "ValorNaoConsta", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.Imovel", "FormaAlienacao", c => c.String(maxLength: 30, fixedLength: true, unicode: false, storeType: "char"));
        }
    }
}
