namespace Cs_Gerencial.Infra.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Atribuicoes",
                c => new
                    {
                        AtribuicaoId = c.Int(nullable: false, identity: true),
                        Codigo = c.Int(nullable: false),
                        Descricao = c.String(maxLength: 40, unicode: false),
                    })
                .PrimaryKey(t => t.AtribuicaoId);
            
            CreateTable(
                "dbo.Bancos",
                c => new
                    {
                        BancosId = c.Int(nullable: false, identity: true),
                        Codigo = c.String(maxLength: 10, unicode: false),
                        Nome = c.String(maxLength: 60, unicode: false),
                        Agencia = c.String(maxLength: 20, unicode: false),
                        Conta = c.String(maxLength: 20, unicode: false),
                    })
                .PrimaryKey(t => t.BancosId);
            
            CreateTable(
                "dbo.CompraSelo",
                c => new
                    {
                        CompraSeloId = c.Int(nullable: false, identity: true),
                        PedidoId = c.Int(nullable: false),
                        DataPedido = c.DateTime(nullable: false, storeType: "date"),
                        HoraPedido = c.String(maxLength: 10, unicode: false),
                        Quantidade = c.Int(nullable: false),
                        Grerj = c.String(maxLength: 15, unicode: false),
                        DataPagamento = c.DateTime(nullable: false, storeType: "date"),
                        HoraPagamento = c.String(maxLength: 10, unicode: false),
                        CpfSolicitante = c.String(maxLength: 11, unicode: false),
                        NomeSolicitante = c.String(maxLength: 100, unicode: false),
                        DataGeracao = c.DateTime(nullable: false, storeType: "date"),
                        HoraGeracao = c.String(maxLength: 10, unicode: false),
                        Arquivo = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.CompraSeloId);
            
            CreateTable(
                "dbo.Conjuntos",
                c => new
                    {
                        ConjuntoId = c.Int(nullable: false, identity: true),
                        Selo = c.String(nullable: false, maxLength: 9, unicode: false),
                        Letra = c.String(nullable: false, maxLength: 4, unicode: false),
                        Numero = c.Int(nullable: false),
                        Aleatorio = c.String(nullable: false, maxLength: 3, unicode: false),
                    })
                .PrimaryKey(t => t.ConjuntoId);
            
            CreateTable(
                "dbo.Contas",
                c => new
                    {
                        ContaId = c.Int(nullable: false, identity: true),
                        IdFornecedor = c.Int(),
                        IdBanco = c.Int(),
                        IdPlano = c.Int(),
                        IdAto = c.Int(),
                        Atribuicao = c.Int(),
                        Livro = c.String(maxLength: 25, unicode: false),
                        FolhaInicial = c.Int(),
                        FolhaFinal = c.Int(),
                        Protocolo = c.Int(),
                        Matricula = c.String(maxLength: 25, unicode: false),
                        Recibo = c.Int(),
                        Letra = c.String(maxLength: 4, unicode: false),
                        Numero = c.Int(),
                        Aleatorio = c.String(maxLength: 3, unicode: false),
                        Codigo = c.Int(),
                        Fornecedor = c.String(maxLength: 60, unicode: false),
                        Banco = c.String(maxLength: 60, unicode: false),
                        Plano = c.String(maxLength: 60, unicode: false),
                        Documento = c.String(maxLength: 30, unicode: false),
                        Tipo = c.String(maxLength: 2, fixedLength: true, unicode: false, storeType: "char"),
                        DataMovimento = c.DateTime(nullable: false, storeType: "date"),
                        DataPagamento = c.DateTime(nullable: false, storeType: "date"),
                        Descricao = c.String(maxLength: 100, unicode: false),
                        Total = c.Decimal(nullable: false, precision: 9, scale: 3),
                        FormaPagamento = c.String(maxLength: 20, unicode: false),
                        NumeroCheque = c.String(maxLength: 10, unicode: false),
                        Deposito = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                    })
                .PrimaryKey(t => t.ContaId);
            
            CreateTable(
                "dbo.Fornecedores",
                c => new
                    {
                        FornecedorId = c.Int(nullable: false, identity: true),
                        RazaoSocial = c.String(maxLength: 120, unicode: false),
                        NomeFantasia = c.String(maxLength: 100, unicode: false),
                        Cnpj = c.String(maxLength: 14, unicode: false),
                    })
                .PrimaryKey(t => t.FornecedorId);
            
            CreateTable(
                "dbo.Indisponibilidades",
                c => new
                    {
                        IndisponibilidadeId = c.Int(nullable: false, identity: true),
                        Protocolo = c.String(maxLength: 40, unicode: false),
                        DataPedido = c.DateTime(storeType: "date"),
                        HoraPedido = c.String(maxLength: 10, unicode: false),
                        NumeroProcesso = c.String(maxLength: 250, unicode: false),
                        Telefone = c.String(maxLength: 15, unicode: false),
                        NomeInstituicao = c.String(maxLength: 250, unicode: false),
                        ForumVara = c.String(maxLength: 200, unicode: false),
                        Usuario = c.String(maxLength: 250, unicode: false),
                        Email = c.String(maxLength: 250, unicode: false),
                        NomeIndividuo = c.String(maxLength: 250, unicode: false),
                        CpfCnpj = c.String(maxLength: 35, unicode: false),
                        Cancelado = c.String(maxLength: 1, unicode: false),
                        Cancelamento = c.String(maxLength: 40, unicode: false),
                        TipoCancelamento = c.Int(),
                        DataCancelamento = c.String(maxLength: 19, unicode: false),
                        HoraCancelamento = c.String(maxLength: 10, unicode: false),
                        Origem = c.String(maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.IndisponibilidadeId);
            
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
                    })
                .PrimaryKey(t => t.LogId);
            
            CreateTable(
                "dbo.Municipios",
                c => new
                    {
                        MunicipioId = c.Int(nullable: false, identity: true),
                        Codigo = c.Int(nullable: false),
                        Uf = c.String(nullable: false, maxLength: 2, fixedLength: true, unicode: false, storeType: "char"),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.MunicipioId);
            
            CreateTable(
                "dbo.MunicipiosCensec",
                c => new
                    {
                        MunicipioCensecId = c.Int(nullable: false, identity: true),
                        Codigo = c.Int(nullable: false),
                        Uf = c.String(maxLength: 2, fixedLength: true, unicode: false, storeType: "char"),
                        Nome = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.MunicipioCensecId);
            
            CreateTable(
                "dbo.Nacionalidades",
                c => new
                    {
                        NacionalidadeId = c.Int(nullable: false, identity: true),
                        Codigo = c.Int(nullable: false),
                        Pais = c.String(nullable: false, maxLength: 50, unicode: false),
                        Nacionalidade = c.String(nullable: false, maxLength: 50, unicode: false),
                        AdjetivoPatrio = c.String(nullable: false, maxLength: 50, unicode: false),
                        Onu = c.Int(),
                    })
                .PrimaryKey(t => t.NacionalidadeId);
            
            CreateTable(
                "dbo.NacionalidadesOnu",
                c => new
                    {
                        NacionalidadeOnuId = c.Int(nullable: false, identity: true),
                        Codigo = c.Int(nullable: false),
                        Pais = c.String(nullable: false, maxLength: 60, unicode: false),
                    })
                .PrimaryKey(t => t.NacionalidadeOnuId);
            
            CreateTable(
                "dbo.Parametros",
                c => new
                    {
                        ParametrosId = c.Int(nullable: false, identity: true),
                        PathSelosNaoImportados = c.String(maxLength: 255, unicode: false),
                        PathSelosImportados = c.String(maxLength: 255, unicode: false),
                        SenhaMaster = c.String(maxLength: 30, unicode: false),
                        PathSelosCenib = c.String(maxLength: 255, unicode: false),
                    })
                .PrimaryKey(t => t.ParametrosId);
            
            CreateTable(
                "dbo.Planos",
                c => new
                    {
                        PlanoId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 100, unicode: false),
                        Principal = c.String(nullable: false, maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                    })
                .PrimaryKey(t => t.PlanoId);
            
            CreateTable(
                "dbo.Selos",
                c => new
                    {
                        SeloId = c.Int(nullable: false, identity: true),
                        Letra = c.String(nullable: false, maxLength: 4, unicode: false),
                        Numero = c.Int(nullable: false),
                        Aleatorio = c.String(maxLength: 3, unicode: false),
                        Cct = c.String(nullable: false, maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        IdCompra = c.Int(nullable: false),
                        IdSerie = c.Int(nullable: false),
                        Status = c.String(nullable: false, maxLength: 20, unicode: false),
                        Sistema = c.String(maxLength: 20, unicode: false),
                        IdReservado = c.Int(),
                        Reservado = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        DataReservado = c.DateTime(storeType: "date"),
                        IdUsuarioReservado = c.Int(),
                        UsuarioReservado = c.String(maxLength: 70, unicode: false),
                        FormReservado = c.String(maxLength: 30, unicode: false),
                        FormUtilizado = c.String(maxLength: 30, unicode: false),
                        IdAto = c.Int(),
                        idReferencia = c.Int(),
                        Atribuicao = c.Int(),
                        DataPratica = c.DateTime(storeType: "date"),
                        Matricula = c.String(maxLength: 25, unicode: false),
                        Livro = c.String(maxLength: 25, unicode: false),
                        FolhaInicial = c.Int(),
                        FolhaFinal = c.Int(),
                        NumeroAto = c.Int(),
                        Protocolo = c.Int(),
                        Recibo = c.Int(),
                        Codigo = c.Int(),
                        Conjunto = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        Natureza = c.String(maxLength: 100, unicode: false),
                        Escrevente = c.String(maxLength: 100, unicode: false),
                        Convenio = c.String(maxLength: 1, fixedLength: true, unicode: false, storeType: "char"),
                        TipoCobranca = c.String(maxLength: 2, fixedLength: true, unicode: false, storeType: "char"),
                        Emolumentos = c.Decimal(precision: 9, scale: 3,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "Emolumentos",
                                    new AnnotationValues(oldValue: null, newValue: "0")
                                },
                            }),
                        Fetj = c.Decimal(precision: 9, scale: 3,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "Fetj",
                                    new AnnotationValues(oldValue: null, newValue: "0")
                                },
                            }),
                        Fundperj = c.Decimal(precision: 9, scale: 3,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "Fundperj",
                                    new AnnotationValues(oldValue: null, newValue: "0")
                                },
                            }),
                        Funperj = c.Decimal(precision: 9, scale: 3,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "Funperj",
                                    new AnnotationValues(oldValue: null, newValue: "0")
                                },
                            }),
                        Funarpen = c.Decimal(precision: 9, scale: 3,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "Funarpen",
                                    new AnnotationValues(oldValue: null, newValue: "0")
                                },
                            }),
                        Pmcmv = c.Decimal(precision: 9, scale: 3,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "Pmcmv",
                                    new AnnotationValues(oldValue: null, newValue: "0")
                                },
                            }),
                        Iss = c.Decimal(precision: 9, scale: 3,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "Iss",
                                    new AnnotationValues(oldValue: null, newValue: "0")
                                },
                            }),
                        Mutua = c.Decimal(precision: 9, scale: 3,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "Mutua",
                                    new AnnotationValues(oldValue: null, newValue: "0")
                                },
                            }),
                        Acoterj = c.Decimal(precision: 9, scale: 3,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "Acoterj",
                                    new AnnotationValues(oldValue: null, newValue: "0")
                                },
                            }),
                        Distribuicao = c.Decimal(precision: 9, scale: 3,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "Distribuicao",
                                    new AnnotationValues(oldValue: null, newValue: "0")
                                },
                            }),
                        Indisponibilidade = c.Decimal(precision: 9, scale: 3,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "Indisponibilidade",
                                    new AnnotationValues(oldValue: null, newValue: "0")
                                },
                            }),
                        Prenotacao = c.Decimal(precision: 9, scale: 3,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "Prenotacao",
                                    new AnnotationValues(oldValue: null, newValue: "0")
                                },
                            }),
                        Ar = c.Decimal(precision: 9, scale: 3,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "Ar",
                                    new AnnotationValues(oldValue: null, newValue: "0")
                                },
                            }),
                        TarifaBancaria = c.Decimal(precision: 9, scale: 3,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "TarifaBancaria",
                                    new AnnotationValues(oldValue: null, newValue: "0")
                                },
                            }),
                        Total = c.Decimal(precision: 9, scale: 3,
                            annotations: new Dictionary<string, AnnotationValues>
                            {
                                { 
                                    "Total",
                                    new AnnotationValues(oldValue: null, newValue: "0")
                                },
                            }),
                        Check = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.SeloId)
                .ForeignKey("dbo.CompraSelo", t => t.IdCompra)
                .ForeignKey("dbo.Series", t => t.IdSerie)
                .Index(t => t.IdCompra)
                .Index(t => t.IdSerie);
            
            CreateTable(
                "dbo.Series",
                c => new
                    {
                        SerieId = c.Int(nullable: false, identity: true),
                        IdCompra = c.Int(nullable: false),
                        Letra = c.String(nullable: false, maxLength: 4, unicode: false),
                        Inicial = c.Int(nullable: false),
                        Final = c.Int(nullable: false),
                        Quantidade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SerieId);
            
            CreateTable(
                "dbo.Serventia",
                c => new
                    {
                        ServentiaId = c.Int(nullable: false),
                        CodigoServentia = c.Int(nullable: false),
                        Descricao = c.String(maxLength: 100, unicode: false),
                        Endereco = c.String(maxLength: 100, unicode: false),
                        Bairro = c.String(maxLength: 40, unicode: false),
                        Cidade = c.String(maxLength: 100, unicode: false),
                        Uf = c.String(maxLength: 2, fixedLength: true, unicode: false, storeType: "char"),
                        Cep = c.String(maxLength: 8, unicode: false),
                        Telefone = c.String(maxLength: 14, unicode: false),
                        Telefone2 = c.String(maxLength: 14, unicode: false),
                        Email = c.String(maxLength: 60, unicode: false),
                        Responsavel = c.String(maxLength: 100, unicode: false),
                        Titular = c.String(maxLength: 100, unicode: false),
                        Substituto = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.ServentiaId);
            
            CreateTable(
                "dbo.ServentiasOutras",
                c => new
                    {
                        ServentiasOutrasId = c.Int(nullable: false, identity: true),
                        CodigoServentia = c.Int(nullable: false),
                        Descricao = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.ServentiasOutrasId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        NomeUsuario = c.String(nullable: false, maxLength: 150, unicode: false),
                        Senha = c.String(nullable: false, maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.UsuarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Selos", "IdSerie", "dbo.Series");
            DropForeignKey("dbo.Selos", "IdCompra", "dbo.CompraSelo");
            DropIndex("dbo.Selos", new[] { "IdSerie" });
            DropIndex("dbo.Selos", new[] { "IdCompra" });
            DropTable("dbo.Usuario");
            DropTable("dbo.ServentiasOutras");
            DropTable("dbo.Serventia");
            DropTable("dbo.Series");
            DropTable("dbo.Selos",
                removedColumnAnnotations: new Dictionary<string, IDictionary<string, object>>
                {
                    {
                        "Acoterj",
                        new Dictionary<string, object>
                        {
                            { "Acoterj", "0" },
                        }
                    },
                    {
                        "Ar",
                        new Dictionary<string, object>
                        {
                            { "Ar", "0" },
                        }
                    },
                    {
                        "Distribuicao",
                        new Dictionary<string, object>
                        {
                            { "Distribuicao", "0" },
                        }
                    },
                    {
                        "Emolumentos",
                        new Dictionary<string, object>
                        {
                            { "Emolumentos", "0" },
                        }
                    },
                    {
                        "Fetj",
                        new Dictionary<string, object>
                        {
                            { "Fetj", "0" },
                        }
                    },
                    {
                        "Funarpen",
                        new Dictionary<string, object>
                        {
                            { "Funarpen", "0" },
                        }
                    },
                    {
                        "Fundperj",
                        new Dictionary<string, object>
                        {
                            { "Fundperj", "0" },
                        }
                    },
                    {
                        "Funperj",
                        new Dictionary<string, object>
                        {
                            { "Funperj", "0" },
                        }
                    },
                    {
                        "Indisponibilidade",
                        new Dictionary<string, object>
                        {
                            { "Indisponibilidade", "0" },
                        }
                    },
                    {
                        "Iss",
                        new Dictionary<string, object>
                        {
                            { "Iss", "0" },
                        }
                    },
                    {
                        "Mutua",
                        new Dictionary<string, object>
                        {
                            { "Mutua", "0" },
                        }
                    },
                    {
                        "Pmcmv",
                        new Dictionary<string, object>
                        {
                            { "Pmcmv", "0" },
                        }
                    },
                    {
                        "Prenotacao",
                        new Dictionary<string, object>
                        {
                            { "Prenotacao", "0" },
                        }
                    },
                    {
                        "TarifaBancaria",
                        new Dictionary<string, object>
                        {
                            { "TarifaBancaria", "0" },
                        }
                    },
                    {
                        "Total",
                        new Dictionary<string, object>
                        {
                            { "Total", "0" },
                        }
                    },
                });
            DropTable("dbo.Planos");
            DropTable("dbo.Parametros");
            DropTable("dbo.NacionalidadesOnu");
            DropTable("dbo.Nacionalidades");
            DropTable("dbo.MunicipiosCensec");
            DropTable("dbo.Municipios");
            DropTable("dbo.LogSistema");
            DropTable("dbo.Indisponibilidades");
            DropTable("dbo.Fornecedores");
            DropTable("dbo.Contas");
            DropTable("dbo.Conjuntos");
            DropTable("dbo.CompraSelo");
            DropTable("dbo.Bancos");
            DropTable("dbo.Atribuicoes");
        }
    }
}
