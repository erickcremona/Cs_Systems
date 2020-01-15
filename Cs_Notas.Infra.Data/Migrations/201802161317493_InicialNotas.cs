namespace Cs_Notas.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InicialNotas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AtoConjuntos",
                c => new
                    {
                        ConjuntoId = c.Int(nullable: false, identity: true),
                        IdAto = c.Int(),
                        Ordem = c.Int(),
                        TabelaCustas = c.String(maxLength: 100, unicode: false),
                        Natureza = c.Int(),
                        TipoAto = c.String(maxLength: 100, unicode: false),
                        LavradoRj = c.String(maxLength: 1, unicode: false),
                        UfOrigem = c.String(maxLength: 2, unicode: false),
                        CodigoServentia = c.Int(),
                        Serventia = c.String(maxLength: 150, unicode: false),
                        Selo = c.String(maxLength: 9, unicode: false),
                        Aleatorio = c.String(maxLength: 3, unicode: false),
                        IndSelo = c.String(maxLength: 1, unicode: false),
                        Data = c.DateTime(storeType: "date"),
                        TipoLivro = c.String(maxLength: 1, unicode: false),
                        Livro = c.String(maxLength: 18, unicode: false),
                        Folhas = c.String(maxLength: 10, unicode: false),
                        Ato = c.String(maxLength: 10, unicode: false),
                        Valor = c.Decimal(precision: 18, scale: 2),
                        Participantes = c.String(maxLength: 255, unicode: false),
                        Procuracao = c.String(maxLength: 1, unicode: false),
                        OrigemDataAto = c.DateTime(storeType: "date"),
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
                        IsChecked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ConjuntoId);
            
            CreateTable(
                "dbo.BensAtosConjuntos",
                c => new
                    {
                        BensAtosConjuntosID = c.Int(nullable: false, identity: true),
                        IdAto = c.Int(nullable: false),
                        IdImovel = c.Int(nullable: false),
                        IdAtoConjunto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BensAtosConjuntosID);
            
            CreateTable(
                "dbo.Cartorios",
                c => new
                    {
                        CartorioId = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.CartorioId);
            
            CreateTable(
                "dbo.Censec",
                c => new
                    {
                        CensecId = c.Int(nullable: false, identity: true),
                        Codigo = c.Int(nullable: false),
                        Descricao = c.String(maxLength: 80, unicode: false),
                    })
                .PrimaryKey(t => t.CensecId);
            
            CreateTable(
                "dbo.CertidaoProcuracao",
                c => new
                    {
                        CertidaoProcuracaoId = c.Int(nullable: false, identity: true),
                        IdReferencia = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false, storeType: "date"),
                        Selo = c.String(maxLength: 9, unicode: false),
                        Cpf1 = c.String(maxLength: 11, unicode: false),
                        Cpf2 = c.String(maxLength: 11, unicode: false),
                        Cpf3 = c.String(maxLength: 11, unicode: false),
                        TipoCobranca = c.String(maxLength: 2, unicode: false),
                        Emolumentos = c.Decimal(precision: 18, scale: 2),
                        Fetj = c.Decimal(precision: 18, scale: 2),
                        Fundperj = c.Decimal(precision: 18, scale: 2),
                        Funprj = c.Decimal(precision: 18, scale: 2),
                        Funarpen = c.Decimal(precision: 18, scale: 2),
                        Pmcmv = c.Decimal(precision: 18, scale: 2),
                        Iss = c.Decimal(precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Login = c.String(maxLength: 100, unicode: false),
                        DataModificado = c.DateTime(storeType: "date"),
                        HoraModificado = c.DateTime(precision: 0),
                        Aleatorio = c.String(maxLength: 3, unicode: false),
                        Servico = c.String(maxLength: 100, unicode: false),
                        UF_Origem = c.String(maxLength: 2, unicode: false),
                        Recibo = c.String(maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.CertidaoProcuracaoId);
            
            CreateTable(
                "dbo.CidadesIbge",
                c => new
                    {
                        CidadesIbgeId = c.Int(nullable: false, identity: true),
                        Codigo = c.Int(nullable: false),
                        Uf = c.String(maxLength: 2, unicode: false),
                        Nome = c.String(maxLength: 60, unicode: false),
                    })
                .PrimaryKey(t => t.CidadesIbgeId);
            
            CreateTable(
                "dbo.Complementos",
                c => new
                    {
                        ComplementoId = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(storeType: "date"),
                        Cct = c.String(maxLength: 9, unicode: false),
                        TipoCobranca = c.String(maxLength: 2, unicode: false),
                        IdAto = c.Int(),
                        DataPratica = c.DateTime(storeType: "date"),
                        Livro = c.Int(),
                        FolhaInicio = c.Int(),
                        FolhaFim = c.Int(),
                        NumeroAto = c.Int(),
                        Selo = c.String(maxLength: 9, unicode: false),
                        Aleatorio = c.String(maxLength: 3, unicode: false),
                        Emolumentos = c.Decimal(precision: 18, scale: 2),
                        Fetj = c.Decimal(precision: 18, scale: 2),
                        Fundperj = c.Decimal(precision: 18, scale: 2),
                        Funprj = c.Decimal(precision: 18, scale: 2),
                        Funarpen = c.Decimal(precision: 18, scale: 2),
                        Pmcmv = c.Decimal(precision: 18, scale: 2),
                        Iss = c.Decimal(precision: 18, scale: 2),
                        Total = c.Decimal(precision: 18, scale: 2),
                        NomeEscrevente = c.String(maxLength: 40, unicode: false),
                        CpfEscrevente = c.String(maxLength: 11, unicode: false),
                        Enviado = c.String(maxLength: 1, unicode: false),
                    })
                .PrimaryKey(t => t.ComplementoId);
            
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
                        TipoCensec = c.String(maxLength: 1, unicode: false),
                        TipoAtoCesdi = c.Int(),
                        NaturezaCensec = c.Int(),
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
                        IdCodigoTabelaCustas = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EscriturasId);
            
            CreateTable(
                "dbo.Imovel",
                c => new
                    {
                        ImovelId = c.Int(nullable: false, identity: true),
                        IdAto = c.Int(),
                        Ordem = c.Int(),
                        TipoRecolhimento = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        TipoImovel = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        InscricaoImobiliaria = c.String(maxLength: 20, unicode: false),
                        Local = c.String(maxLength: 20, unicode: false),
                        Incra = c.String(maxLength: 20, unicode: false),
                        Area = c.String(maxLength: 20, unicode: false),
                        Denominacao = c.String(maxLength: 20, unicode: false),
                        SRF = c.String(maxLength: 20, unicode: false),
                        Endereco = c.String(maxLength: 80, unicode: false),
                        Bairro = c.String(maxLength: 90, unicode: false),
                        Municipio = c.String(maxLength: 60, unicode: false),
                        Uf = c.String(maxLength: 2, fixedLength: true, unicode: false, storeType: "char"),
                        Guia = c.String(maxLength: 20, unicode: false),
                        Adquirente = c.String(maxLength: 15, unicode: false),
                        Cedente = c.String(maxLength: 20, unicode: false),
                        MaiorPorcao = c.String(maxLength: 20, unicode: false),
                        Valor = c.Decimal(precision: 18, scale: 2),
                        ParteTranferida = c.String(maxLength: 20, unicode: false),
                        TipoTransacao = c.String(maxLength: 15, unicode: false),
                        DescricaoTransacao = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        Retificacao = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        DataAlienacao = c.DateTime(nullable: false, storeType: "date"),
                        FormaAlienacao = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        ValorNaoConsta = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        ValorAlienacao = c.Decimal(precision: 18, scale: 2),
                        BaseItbiItcd = c.Decimal(precision: 18, scale: 2),
                        TipoImovelDoi = c.String(maxLength: 2, fixedLength: true, unicode: false, storeType: "char"),
                        DescricaoTipoImovel = c.String(maxLength: 100, unicode: false),
                        Construcao = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        AreaNaoConsta = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        Numero = c.Int(),
                        Cep = c.String(maxLength: 8, unicode: false),
                        ValorItbi = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        Matricula = c.String(maxLength: 20, unicode: false),
                        Complemento = c.String(maxLength: 100, unicode: false),
                        Rgi = c.String(maxLength: 100, unicode: false),
                        SubTipo = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        LocalTerreno = c.String(maxLength: 250, unicode: false),
                        ValorGuia = c.Decimal(precision: 18, scale: 2),
                        Temp = c.String(maxLength: 250, unicode: false),
                        Detalhes = c.String(maxLength: 250, unicode: false),
                        Situacao = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        CodigoMunicipio = c.Int(),
                        Unidade = c.Int(),
                        Serventia = c.Int(),
                        TipoImposto = c.String(maxLength: 4, unicode: false),
                        Principal = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        TipoBem = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        Objeto = c.String(maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.ImovelId);
            
            CreateTable(
                "dbo.ItensCustas",
                c => new
                    {
                        ItensCustasId = c.Int(nullable: false, identity: true),
                        IdAto = c.Int(nullable: false),
                        Tabela = c.String(maxLength: 20, unicode: false),
                        Item = c.String(maxLength: 20, unicode: false),
                        SubItem = c.String(maxLength: 20, unicode: false),
                        Quantidade = c.String(maxLength: 10, unicode: false),
                        Complemento = c.String(maxLength: 50, unicode: false),
                        Excessao = c.String(maxLength: 50, unicode: false),
                        Valor = c.Decimal(nullable: false, precision: 9, scale: 3),
                        Total = c.Decimal(nullable: false, precision: 9, scale: 3),
                        Descricao = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.ItensCustasId);
            
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
                "dbo.Naturezas",
                c => new
                    {
                        NaturezasId = c.Int(nullable: false, identity: true),
                        Codigo = c.Int(nullable: false),
                        Descricao = c.String(maxLength: 100, unicode: false),
                        Doi = c.String(maxLength: 1, unicode: false),
                        Censec = c.String(maxLength: 1, unicode: false),
                        Cep = c.Int(nullable: false),
                        Tipo = c.String(maxLength: 1, unicode: false),
                    })
                .PrimaryKey(t => t.NaturezasId);
            
            CreateTable(
                "dbo.Nomes",
                c => new
                    {
                        NomeId = c.Int(nullable: false, identity: true),
                        IdPessoa = c.Int(nullable: false),
                        IdAto = c.Int(nullable: false),
                        Ordem = c.Int(nullable: false),
                        Principal = c.String(maxLength: 1, unicode: false),
                        Nomenclatura = c.String(maxLength: 3, unicode: false),
                        Descricao = c.String(maxLength: 45, unicode: false),
                        Nome = c.String(maxLength: 100, unicode: false),
                        TipoPessoa = c.String(maxLength: 1, unicode: false),
                        Documento = c.String(maxLength: 15, unicode: false),
                        Rg = c.String(maxLength: 15, unicode: false),
                        DataEmissao = c.DateTime(storeType: "date"),
                        Orgao = c.String(maxLength: 60, unicode: false),
                        Nacionalidade = c.String(maxLength: 60, unicode: false),
                        EstadoCivil = c.String(maxLength: 1, unicode: false),
                        RegimeCasamento = c.String(maxLength: 40, unicode: false),
                        Justificativa = c.String(maxLength: 255, unicode: false),
                        DataNascimento = c.DateTime(storeType: "date"),
                        NomePai = c.String(maxLength: 100, unicode: false),
                        NomeMae = c.String(maxLength: 100, unicode: false),
                        Profissao = c.String(maxLength: 60, unicode: false),
                        Endereco = c.String(maxLength: 80, unicode: false),
                        Municipio = c.String(maxLength: 60, unicode: false),
                        Uf = c.String(maxLength: 2, unicode: false),
                        DataCasamento = c.DateTime(storeType: "date"),
                        Conjuge = c.String(maxLength: 100, unicode: false),
                        DataObito = c.DateTime(storeType: "date"),
                        LivroObito = c.String(maxLength: 20, unicode: false),
                        FolhasObito = c.String(maxLength: 20, unicode: false),
                        SeloObito = c.String(maxLength: 9, unicode: false),
                        Representa = c.String(maxLength: 1, unicode: false),
                        Bairro = c.String(maxLength: 80, unicode: false),
                        Participacao = c.Decimal(precision: 18, scale: 2),
                        Tipo = c.String(maxLength: 2, unicode: false),
                        Procurador = c.String(maxLength: 1, unicode: false),
                        CpfProcurador = c.String(maxLength: 20, unicode: false),
                        CnpjRepresenta = c.String(maxLength: 20, unicode: false),
                        TipoRepresenta = c.String(maxLength: 1, unicode: false),
                        NomeRepresenta = c.String(maxLength: 100, unicode: false),
                        NumeroBIB = c.String(maxLength: 16, unicode: false),
                        Ocultar = c.String(maxLength: 1, unicode: false),
                        Escritura = c.String(maxLength: 800, unicode: false),
                        OcultarDistribuicao = c.String(maxLength: 1, unicode: false),
                        NumeroCRE = c.String(maxLength: 16, unicode: false),
                        Qualidade = c.String(maxLength: 50, unicode: false),
                        Tpj = c.Int(),
                        Situacao = c.Int(),
                        OcultarXML = c.String(maxLength: 1, unicode: false),
                        Hash = c.String(maxLength: 50, unicode: false),
                        PreTeste = c.String(maxLength: 30, unicode: false),
                        NumeroConjuge = c.Int(),
                    })
                .PrimaryKey(t => t.NomeId);
            
            CreateTable(
                "dbo.ParteConjuntos",
                c => new
                    {
                        ParteConjuntosId = c.Int(nullable: false, identity: true),
                        IdAto = c.Int(nullable: false),
                        IdNome = c.Int(nullable: false),
                        IdConjunto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ParteConjuntosId);
            
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
            
            CreateTable(
                "dbo.Regimes",
                c => new
                    {
                        RegimesId = c.Int(nullable: false),
                        Descricao = c.String(maxLength: 30, unicode: false),
                        Censec = c.String(maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.RegimesId);
            
            CreateTable(
                "dbo.TipoImovel",
                c => new
                    {
                        TipoImovelId = c.Int(nullable: false, identity: true),
                        Codigo = c.Int(nullable: false),
                        Descricao = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.TipoImovelId);
            
            CreateTable(
                "dbo.TransacaoDoi",
                c => new
                    {
                        TransacaoDoiId = c.Int(nullable: false, identity: true),
                        Codigo = c.Int(nullable: false),
                        Descricao = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.TransacaoDoiId);
            
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
            DropTable("dbo.TransacaoDoi");
            DropTable("dbo.TipoImovel");
            DropTable("dbo.Regimes");
            DropTable("dbo.ProcuracaoEscritura");
            DropTable("dbo.ParteConjuntos");
            DropTable("dbo.Nomes");
            DropTable("dbo.Naturezas");
            DropTable("dbo.LogSistema");
            DropTable("dbo.ItensCustas");
            DropTable("dbo.Imovel");
            DropTable("dbo.Escrituras");
            DropTable("dbo.Configuracoes");
            DropTable("dbo.Complementos");
            DropTable("dbo.CidadesIbge");
            DropTable("dbo.CertidaoProcuracao");
            DropTable("dbo.Censec");
            DropTable("dbo.Cartorios");
            DropTable("dbo.BensAtosConjuntos");
            DropTable("dbo.AtoConjuntos");
        }
    }
}
