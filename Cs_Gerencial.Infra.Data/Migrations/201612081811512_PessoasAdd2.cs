namespace Cs_Gerencial.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PessoasAdd2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pessoas", "DataCadastro", c => c.DateTime(storeType: "date"));
            AlterColumn("dbo.Pessoas", "DataEmissaoRG", c => c.DateTime(storeType: "date"));
            AlterColumn("dbo.Pessoas", "EsctadoCivil", c => c.Int());
            AlterColumn("dbo.Pessoas", "DataCasamento", c => c.DateTime(storeType: "date"));
            AlterColumn("dbo.Pessoas", "DataObito", c => c.DateTime(storeType: "date"));
            AlterColumn("dbo.Pessoas", "DataNascimento", c => c.DateTime(storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pessoas", "DataNascimento", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Pessoas", "DataObito", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Pessoas", "DataCasamento", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Pessoas", "EsctadoCivil", c => c.Int(nullable: false));
            AlterColumn("dbo.Pessoas", "DataEmissaoRG", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Pessoas", "DataCadastro", c => c.DateTime(nullable: false, storeType: "date"));
        }
    }
}
