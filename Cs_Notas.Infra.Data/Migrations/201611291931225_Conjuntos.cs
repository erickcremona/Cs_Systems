namespace Cs_Notas.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Conjuntos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Conjuntos",
                c => new
                    {
                        ConjuntoId = c.Int(nullable: false, identity: true),
                        IdAto = c.Int(nullable: false),
                        Ordem = c.Int(nullable: false),
                        Codigo = c.Int(nullable: false),
                        Natureza = c.Int(nullable: false),
                        TipoAto = c.String(maxLength: 100, unicode: false),
                        LavradoRj = c.String(maxLength: 1, unicode: false),
                        UfOrigem = c.String(maxLength: 2, unicode: false),
                        CodigoServentia = c.Int(nullable: false),
                        Serventia = c.String(maxLength: 150, unicode: false),
                        Selo = c.String(maxLength: 9, unicode: false),
                        Aleatorio = c.String(maxLength: 3, unicode: false),
                        IndSelo = c.String(maxLength: 1, unicode: false),
                        Data = c.DateTime(nullable: false, precision: 0),
                        TipoLivro = c.String(maxLength: 1, unicode: false),
                        Livro = c.String(maxLength: 18, unicode: false),
                        Folhas = c.String(maxLength: 10, unicode: false),
                        Ato = c.String(maxLength: 10, unicode: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Participantes = c.String(maxLength: 255, unicode: false),
                        Procuracao = c.String(maxLength: 1, unicode: false),
                        OrigemDataAto = c.DateTime(nullable: false, precision: 0),
                        OrigemLivro = c.String(maxLength: 25, unicode: false),
                        OrigemFolhaInicio = c.String(maxLength: 25, unicode: false),
                        OrigemFolhaFim = c.String(maxLength: 25, unicode: false),
                        OrigemNumeroAto = c.String(maxLength: 25, unicode: false),
                        OrigemLavrado = c.String(maxLength: 2, unicode: false),
                        OrigemTipoLivro = c.String(maxLength: 100, unicode: false),
                        OrigemOutorgado = c.String(maxLength: 1, unicode: false),
                        OrigemServentia = c.String(maxLength: 250, unicode: false),
                        OrigemUf = c.String(maxLength: 250, unicode: false),
                        OrigemNotificacao = c.String(maxLength: 25, unicode: false),
                    })
                .PrimaryKey(t => t.ConjuntoId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Conjuntos");
        }
    }
}
