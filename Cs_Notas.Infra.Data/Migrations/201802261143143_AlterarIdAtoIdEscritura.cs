namespace Cs_Notas.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterarIdAtoIdEscritura : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BensAtosConjuntos", "IdEscritura", c => c.Int(nullable: false));
            AddColumn("dbo.Complementos", "IdEscritura", c => c.Int());
            AddColumn("dbo.Imovel", "IdEscritura", c => c.Int());
            AddColumn("dbo.ItensCustas", "IdEscritura", c => c.Int(nullable: false));
            AddColumn("dbo.LogSistema", "IdEscritura", c => c.Int());
            AddColumn("dbo.ParteConjuntos", "IdEscritura", c => c.Int(nullable: false));
            DropColumn("dbo.BensAtosConjuntos", "IdAto");
            DropColumn("dbo.Complementos", "IdAto");
            DropColumn("dbo.Imovel", "IdAto");
            DropColumn("dbo.ItensCustas", "IdAto");
            DropColumn("dbo.LogSistema", "IdAto");
            DropColumn("dbo.ParteConjuntos", "IdAto");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ParteConjuntos", "IdAto", c => c.Int(nullable: false));
            AddColumn("dbo.LogSistema", "IdAto", c => c.Int());
            AddColumn("dbo.ItensCustas", "IdAto", c => c.Int(nullable: false));
            AddColumn("dbo.Imovel", "IdAto", c => c.Int());
            AddColumn("dbo.Complementos", "IdAto", c => c.Int());
            AddColumn("dbo.BensAtosConjuntos", "IdAto", c => c.Int(nullable: false));
            DropColumn("dbo.ParteConjuntos", "IdEscritura");
            DropColumn("dbo.LogSistema", "IdEscritura");
            DropColumn("dbo.ItensCustas", "IdEscritura");
            DropColumn("dbo.Imovel", "IdEscritura");
            DropColumn("dbo.Complementos", "IdEscritura");
            DropColumn("dbo.BensAtosConjuntos", "IdEscritura");
        }
    }
}
