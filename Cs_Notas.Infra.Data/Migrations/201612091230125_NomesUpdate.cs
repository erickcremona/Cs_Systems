namespace Cs_Notas.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NomesUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Nomes", "DataNascimento", c => c.DateTime(storeType: "date"));
            AlterColumn("dbo.Nomes", "DataCasamento", c => c.DateTime(storeType: "date"));
            AlterColumn("dbo.Nomes", "DataObito", c => c.DateTime(storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Nomes", "DataObito", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Nomes", "DataCasamento", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Nomes", "DataNascimento", c => c.DateTime(nullable: false, storeType: "date"));
        }
    }
}
