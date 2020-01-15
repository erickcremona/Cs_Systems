namespace Cs_Notas.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Configuracoes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Configuracoes",
                c => new
                    {
                        ConfiguracoesId = c.Int(nullable: false, identity: true),
                        Mutua = c.Decimal(precision: 18, scale: 2),
                        Acoterj = c.Decimal(precision: 18, scale: 2),
                        Distribuicao = c.Decimal(precision: 18, scale: 2),
                        Indisponibilidade = c.Decimal(precision: 18, scale: 2),
                        PathXML = c.String(maxLength: 100, unicode: false),
                        PathModelo = c.String(maxLength: 100, unicode: false),
                        PathEscritura = c.String(maxLength: 100, unicode: false),
                        PathProcuracao = c.String(maxLength: 100, unicode: false),
                        PathTestamento = c.String(maxLength: 100, unicode: false),
                        PathDistribuicao = c.String(maxLength: 100, unicode: false),
                        PathImagem = c.String(maxLength: 100, unicode: false),
                        PathLogoTipo = c.String(maxLength: 100, unicode: false),
                        PathCensec = c.String(maxLength: 100, unicode: false),
                        PathRecibo = c.String(maxLength: 100, unicode: false),
                        PathRgi = c.String(maxLength: 100, unicode: false),
                        Recibo = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        MostrarCustas = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        Cabecalho = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        ImagemConfirmacao = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        CabecalhoConfirmacao = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        OcultarObjetoConfirmacao = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        ObjetoRsumo = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        ControlarDist = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        PerguntaImpressao = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        CodigoMovimento = c.Int(),
                        Tabela = c.Int(),
                        Cidades = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        ExportaRecibo = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        Impressora = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        ImprimirRecibo = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        DistribuicaoPara = c.String(maxLength: 200, unicode: false),
                        ConjugeDist = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        QualifResumoDist = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        SerieAtual = c.Int(),
                        SenhaMaster = c.String(maxLength: 30, unicode: false),
                        TabeliaoDistribuicao = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        DigitarSelo = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        VersaoMinuta = c.Int(),
                        EtiquetaCabecalho = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        EtiquetaAntes = c.Int(),
                        EtiquetaApos = c.Int(),
                        EtiquetaEsquerda = c.Int(),
                        EtiquetaAltura = c.String(maxLength: 10, unicode: false),
                        EtiquetaLargura = c.String(maxLength: 10, unicode: false),
                        EtiquetaNegrito = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        BlkaToDist = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        TipoDiligencia = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        Diligencia_Pmcmv = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        SeloCertLeft = c.Int(),
                        SeloCertTop = c.Int(),
                        Rgi = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                    })
                .PrimaryKey(t => t.ConfiguracoesId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Configuracoes");
        }
    }
}
