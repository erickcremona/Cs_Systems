namespace Cs_Notas.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
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
            
            CreateTable(
                "dbo.Escrituras",
                c => new
                    {
                        EscriturasId = c.Int(nullable: false, identity: true),
                        CertidaoId = c.Int(nullable: false),
                        TipoAto = c.String(maxLength: 2, fixedLength: true, unicode: false, storeType: "char"),
                        DataAtoRegistro = c.DateTime(storeType: "date"),
                        CpfEscrevente = c.String(maxLength: 15, unicode: false),
                        EscreventeAtoRegistro = c.String(maxLength: 100, unicode: false),
                        DataAtoCertidao = c.DateTime(storeType: "date"),
                        EscreventeAtoCertidao = c.String(maxLength: 100, unicode: false),
                        SeloEscritura = c.String(maxLength: 9, unicode: false),
                        Aleatorio = c.String(maxLength: 3, unicode: false),
                        LivroEscritura = c.String(maxLength: 20, unicode: false),
                        FolhasInicio = c.Int(),
                        FolhasFim = c.Int(),
                        NumeroAto = c.Int(),
                        Recibo = c.String(maxLength: 20, unicode: false),
                        CodigoAto = c.Int(),
                        Natureza = c.String(maxLength: 3, unicode: false),
                        Descricao = c.String(maxLength: 100, unicode: false),
                        ValorEscritua = c.Decimal(precision: 18, scale: 2),
                        TipoCobranca = c.String(maxLength: 2, unicode: false),
                        Emolumentos = c.Decimal(precision: 18, scale: 2),
                        Fetj = c.Decimal(precision: 18, scale: 2),
                        Fundperj = c.Decimal(precision: 18, scale: 2),
                        Funprj = c.Decimal(precision: 18, scale: 2),
                        Funarpen = c.Decimal(precision: 18, scale: 2),
                        Pmcmv = c.Decimal(precision: 18, scale: 2),
                        Iss = c.Decimal(precision: 18, scale: 2),
                        Mutua = c.Decimal(precision: 18, scale: 2),
                        Acoterj = c.Decimal(precision: 18, scale: 2),
                        Distribuicao = c.Decimal(precision: 18, scale: 2),
                        Total = c.Decimal(precision: 18, scale: 2),
                        Paginas = c.Int(),
                        Unidades = c.Int(),
                        Diligencias = c.Int(),
                        IndProcuracao = c.String(maxLength: 1, unicode: false),
                        IndAlvara = c.String(maxLength: 1, unicode: false),
                        DataDistribuicao = c.DateTime(storeType: "date"),
                        NumeroDistribuicao = c.Int(nullable: false),
                        DistribuicaoEnviada = c.String(maxLength: 1, unicode: false),
                        Orcamento = c.Int(nullable: false),
                        Objeto = c.String(maxLength: 255, unicode: false),
                        Observacao = c.String(maxLength: 255, unicode: false),
                        OficioRecebido = c.String(maxLength: 20, unicode: false),
                        OficioGerado = c.String(maxLength: 20, unicode: false),
                        Censec = c.String(maxLength: 1, unicode: false),
                        TipoCensec = c.String(maxLength: 255, unicode: false),
                        TipoAtoCensec = c.String(maxLength: 100, unicode: false),
                        NaturezaCensec = c.String(maxLength: 100, unicode: false),
                        Desconhecido = c.String(maxLength: 100, unicode: false),
                        LivroReferencia = c.String(maxLength: 20, unicode: false),
                        FolhaReferencia = c.String(maxLength: 10, unicode: false),
                        UfReferencia = c.String(maxLength: 2, unicode: false),
                        CidadeReferencia = c.Int(),
                        CartorioReferencia = c.String(maxLength: 50, unicode: false),
                        CodigoServentia = c.Int(),
                        Serventia = c.String(maxLength: 100, unicode: false),
                        UfOrigem = c.String(maxLength: 2, unicode: false),
                        Path = c.String(maxLength: 100, unicode: false),
                        Cancelado = c.String(maxLength: 1, unicode: false),
                        Enviado = c.String(maxLength: 1, unicode: false),
                        Login = c.String(maxLength: 100, unicode: false),
                        DataModificacao = c.DateTime(storeType: "date"),
                        HoraModificacao = c.DateTime(precision: 0),
                        QtdFilhosMenores = c.Int(),
                        ResponsavelFilhosMenores = c.Int(),
                        Letra = c.String(maxLength: 5, unicode: false),
                    })
                .PrimaryKey(t => t.EscriturasId);
            
            CreateTable(
                "dbo.LogSistema",
                c => new
                    {
                        LogId = c.Int(nullable: false, identity: true),
                        Tela = c.String(maxLength: 50, unicode: false),
                        Data = c.DateTime(storeType: "date"),
                        Hora = c.String(maxLength: 10, unicode: false),
                        Descricao = c.String(maxLength: 255, unicode: false),
                        IdUsuario = c.Int(),
                        Usuario = c.String(maxLength: 100, unicode: false),
                        Maquina = c.String(maxLength: 50, unicode: false),
                        IdAto = c.Int(),
                        HoraClose = c.String(maxLength: 10, unicode: false),
                        InicioTela = c.String(maxLength: 255, unicode: false),
                        FimTela = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.LogId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 150, unicode: false),
                        Cpf = c.String(maxLength: 14, unicode: false),
                        Qualificacao = c.String(maxLength: 100, unicode: false),
                        Matricula = c.String(maxLength: 15, unicode: false),
                        Senha = c.String(nullable: false, maxLength: 30, unicode: false),
                        Master = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        AlterarAto = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        ExcluirAto = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        SelarAto = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        LiberarSelo = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        ReservarSelo = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        AlterarSelo = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        AlterarEmolumentos = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Usuario");
            DropTable("dbo.LogSistema");
            DropTable("dbo.Escrituras");
            DropTable("dbo.Configuracoes");
        }
    }
}
