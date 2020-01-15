namespace Cs_Notas.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updadeCheckd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AtoConjuntos", "IsChecked", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AtoConjuntos", "IsChecked");
        }
    }
}
