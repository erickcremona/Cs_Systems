namespace Cs_Notas.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Conjuntos2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Conjuntos", "IdAto", c => c.Int());
            AlterColumn("dbo.Conjuntos", "Ordem", c => c.Int());
            AlterColumn("dbo.Conjuntos", "Codigo", c => c.Int());
            AlterColumn("dbo.Conjuntos", "Natureza", c => c.Int());
            AlterColumn("dbo.Conjuntos", "CodigoServentia", c => c.Int());
            AlterColumn("dbo.Conjuntos", "Data", c => c.DateTime(storeType: "date"));
            AlterColumn("dbo.Conjuntos", "Valor", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Conjuntos", "OrigemDataAto", c => c.DateTime(storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Conjuntos", "OrigemDataAto", c => c.DateTime(nullable: false, precision: 0));
            AlterColumn("dbo.Conjuntos", "Valor", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Conjuntos", "Data", c => c.DateTime(nullable: false, precision: 0));
            AlterColumn("dbo.Conjuntos", "CodigoServentia", c => c.Int(nullable: false));
            AlterColumn("dbo.Conjuntos", "Natureza", c => c.Int(nullable: false));
            AlterColumn("dbo.Conjuntos", "Codigo", c => c.Int(nullable: false));
            AlterColumn("dbo.Conjuntos", "Ordem", c => c.Int(nullable: false));
            AlterColumn("dbo.Conjuntos", "IdAto", c => c.Int(nullable: false));
        }
    }
}
