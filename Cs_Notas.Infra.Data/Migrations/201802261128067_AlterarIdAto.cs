namespace Cs_Notas.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterarIdAto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Nomes", "IdEscritura", c => c.Int(nullable: false));
            DropColumn("dbo.Nomes", "IdAto");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Nomes", "IdAto", c => c.Int(nullable: false));
            DropColumn("dbo.Nomes", "IdEscritura");
        }
    }
}
