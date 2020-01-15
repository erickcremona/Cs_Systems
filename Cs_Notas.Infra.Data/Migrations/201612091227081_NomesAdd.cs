namespace Cs_Notas.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NomesAdd : DbMigration
    {
        public override void Up()
        {
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
                        DataNascimento = c.DateTime(nullable: false, storeType: "date"),
                        NomePai = c.String(maxLength: 100, unicode: false),
                        NomeMae = c.String(maxLength: 100, unicode: false),
                        Profissao = c.String(maxLength: 60, unicode: false),
                        Endereco = c.String(maxLength: 80, unicode: false),
                        Municipio = c.String(maxLength: 60, unicode: false),
                        Uf = c.String(maxLength: 2, unicode: false),
                        DataCasamento = c.DateTime(nullable: false, storeType: "date"),
                        Conjuge = c.String(maxLength: 100, unicode: false),
                        DataObito = c.DateTime(nullable: false, storeType: "date"),
                        LivroObito = c.String(maxLength: 20, unicode: false),
                        FolhasObito = c.String(maxLength: 20, unicode: false),
                        SeloObito = c.String(maxLength: 9, unicode: false),
                        Representa = c.String(maxLength: 1, unicode: false),
                        Bairro = c.String(maxLength: 80, unicode: false),
                        Participacao = c.Single(),
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
                    })
                .PrimaryKey(t => t.NomeId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Nomes");
        }
    }
}
