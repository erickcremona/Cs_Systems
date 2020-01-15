namespace Cs_Gerencial.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TabelaCustas", "Ano", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TabelaCustas", "Ano");
        }
    }
}
