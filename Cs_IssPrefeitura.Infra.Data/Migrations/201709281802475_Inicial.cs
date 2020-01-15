namespace Cs_IssPrefeitura.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApuracaoIss",
                c => new
                    {
                        ApuracaoIssId = c.Int(nullable: false, identity: true),
                        DataFechamento = c.DateTime(nullable: false, storeType: "date"),
                        Mes = c.Int(nullable: false),
                        NomeMes = c.String(nullable: false, maxLength: 15, unicode: false),
                        Ano = c.Int(nullable: false),
                        Periodo = c.String(nullable: false, maxLength: 30, unicode: false),
                        Livro = c.Int(nullable: false),
                        Folha = c.Int(nullable: false),
                        Recibo = c.String(nullable: false, maxLength: 10, unicode: false),
                        Serie = c.Int(nullable: false),
                        Numero = c.Int(nullable: false),
                        Cancelado = c.String(maxLength: 10, unicode: false),
                        Faturamento = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FundosEspeciais = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BaseCalculo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Aliquota = c.Single(nullable: false),
                        ValorIssRecolhido = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ApuracaoIssId);
            
            CreateTable(
                "dbo.AtoIss",
                c => new
                    {
                        AtoIssId = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false, storeType: "date"),
                        Atribuicao = c.String(nullable: false, maxLength: 80, unicode: false),
                        TipoAto = c.String(nullable: false, maxLength: 80, unicode: false),
                        Selo = c.String(nullable: false, maxLength: 9, unicode: false),
                        Aleatorio = c.String(maxLength: 3, unicode: false),
                        TipoCobranca = c.String(maxLength: 2, unicode: false),
                        Emolumentos = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fetj = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fundperj = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Funperj = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Funarpen = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Ressag = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Mutua = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Acoterj = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Distribuidor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Iss = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdApuracaoIss = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AtoIssId);
            
            CreateTable(
                "dbo.Config",
                c => new
                    {
                        ConfiguracoesId = c.Int(nullable: false, identity: true),
                        Titular = c.String(nullable: false, maxLength: 50, unicode: false),
                        Substituto = c.String(maxLength: 50, unicode: false),
                        Codigo = c.Int(),
                        RazaoSocial = c.String(nullable: false, maxLength: 100, unicode: false),
                        Endereco = c.String(maxLength: 60, unicode: false),
                        Bairro = c.String(maxLength: 40, unicode: false),
                        Cidade = c.String(maxLength: 30, unicode: false),
                        Uf = c.String(maxLength: 2, unicode: false),
                        Cep = c.String(maxLength: 10, unicode: false),
                        Telefone1 = c.String(maxLength: 10, unicode: false),
                        Telefone2 = c.String(maxLength: 10, unicode: false),
                        Email = c.String(maxLength: 40, unicode: false),
                        Cnpj = c.String(nullable: false, maxLength: 50, unicode: false),
                        ProximoLivro = c.Int(nullable: false),
                        ProximaFolha = c.Int(nullable: false),
                        TipoCalculoIss = c.String(nullable: false, maxLength: 15, unicode: false),
                        ValorAliquota = c.Double(nullable: false),
                        TotalFolhasPorLivro = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ConfiguracoesId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 70, unicode: false),
                        Senha = c.String(nullable: false, maxLength: 70, unicode: false),
                        ImportarMas = c.Boolean(nullable: false),
                        FechamentoMes = c.Boolean(nullable: false),
                        AlterarAtos = c.Boolean(nullable: false),
                        AbrirFecharLivro = c.Boolean(nullable: false),
                        ImprimirFechamentoMes = c.Boolean(nullable: false),
                        UsuarioMaster = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuario");
            DropTable("dbo.Config");
            DropTable("dbo.AtoIss");
            DropTable("dbo.ApuracaoIss");
        }
    }
}
