namespace Cs_Notas.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProcEscritura : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProcuracaoEscritura",
                c => new
                    {
                        ProcuracaoEscrituraId = c.Int(nullable: false, identity: true),
                        IdAto = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false, storeType: "date"),
                        Livro = c.String(maxLength: 20, unicode: false),
                        Folhas = c.String(maxLength: 10, unicode: false),
                        Ato = c.String(maxLength: 10, unicode: false),
                        Selo = c.String(maxLength: 9, unicode: false),
                        Aleatorio = c.String(maxLength: 3, unicode: false),
                        Outorgantes = c.String(maxLength: 600, unicode: false),
                        Outorgados = c.String(maxLength: 600, unicode: false),
                        Lavrado = c.String(maxLength: 1, unicode: false),
                        CodigoServentia = c.Int(nullable: false),
                        Serventia = c.String(maxLength: 150, unicode: false),
                        UfOrigem = c.String(maxLength: 2, unicode: false),
                    })
                .PrimaryKey(t => t.ProcuracaoEscrituraId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProcuracaoEscritura");
        }
    }
}
