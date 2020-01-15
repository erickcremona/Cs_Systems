namespace Cs_Notas.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterarIdAtoIdEscrituraNull : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AtoConjuntos", "IdEscritura", c => c.Int());
            AddColumn("dbo.ProcuracaoEscritura", "IdEscritura", c => c.Int());
            AlterColumn("dbo.BensAtosConjuntos", "IdEscritura", c => c.Int());
            AlterColumn("dbo.ItensCustas", "IdEscritura", c => c.Int());
            AlterColumn("dbo.Nomes", "IdEscritura", c => c.Int());
            AlterColumn("dbo.ParteConjuntos", "IdEscritura", c => c.Int());
            DropColumn("dbo.AtoConjuntos", "IdAto");
            DropColumn("dbo.ProcuracaoEscritura", "IdAto");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProcuracaoEscritura", "IdAto", c => c.Int(nullable: false));
            AddColumn("dbo.AtoConjuntos", "IdAto", c => c.Int());
            AlterColumn("dbo.ParteConjuntos", "IdEscritura", c => c.Int(nullable: false));
            AlterColumn("dbo.Nomes", "IdEscritura", c => c.Int(nullable: false));
            AlterColumn("dbo.ItensCustas", "IdEscritura", c => c.Int(nullable: false));
            AlterColumn("dbo.BensAtosConjuntos", "IdEscritura", c => c.Int(nullable: false));
            DropColumn("dbo.ProcuracaoEscritura", "IdEscritura");
            DropColumn("dbo.AtoConjuntos", "IdEscritura");
        }
    }
}
