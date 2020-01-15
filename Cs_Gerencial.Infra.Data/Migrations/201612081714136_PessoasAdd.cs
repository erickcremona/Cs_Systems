namespace Cs_Gerencial.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PessoasAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pessoas",
                c => new
                    {
                        PessoasId = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 100, unicode: false),
                        TipoPessoa = c.String(nullable: false, maxLength: 1, unicode: false),
                        DataCadastro = c.DateTime(nullable: false, storeType: "date"),
                        CpfCgc = c.String(maxLength: 18, unicode: false),
                        Rg = c.String(maxLength: 25, unicode: false),
                        OrgaoRG = c.String(maxLength: 70, unicode: false),
                        DataEmissaoRG = c.DateTime(nullable: false, storeType: "date"),
                        Nacionalidade = c.String(maxLength: 30, unicode: false),
                        Endereco = c.String(maxLength: 100, unicode: false),
                        Bairro = c.String(maxLength: 100, unicode: false),
                        Cidade = c.String(maxLength: 100, unicode: false),
                        Uf = c.String(maxLength: 2, unicode: false),
                        Cep = c.String(maxLength: 10, unicode: false),
                        EsctadoCivil = c.Int(nullable: false),
                        Conjuge = c.String(maxLength: 100, unicode: false),
                        RegimeBens = c.String(maxLength: 30, unicode: false),
                        DataCasamento = c.DateTime(nullable: false, storeType: "date"),
                        DataObito = c.DateTime(nullable: false, storeType: "date"),
                        LivroObito = c.String(maxLength: 18, unicode: false),
                        FolhaObito = c.String(maxLength: 10, unicode: false),
                        SeloObito = c.String(maxLength: 9, unicode: false),
                        DataNascimento = c.DateTime(nullable: false, storeType: "date"),
                        NomePai = c.String(maxLength: 100, unicode: false),
                        NomeMae = c.String(maxLength: 100, unicode: false),
                        Profissao = c.String(maxLength: 100, unicode: false),
                        Justificativa = c.String(maxLength: 800, unicode: false),
                        Digital = c.String(maxLength: 800, unicode: false),
                        TipoEndereco = c.String(maxLength: 1, unicode: false),
                        Sexo = c.String(maxLength: 1, unicode: false),
                        Sobrenome = c.String(maxLength: 100, unicode: false),
                        IfpDetran = c.String(maxLength: 1, unicode: false),
                        Observacao = c.String(maxLength: 100, unicode: false),
                        Naturalidade = c.String(maxLength: 100, unicode: false),
                        Atualizado = c.String(maxLength: 1, unicode: false),
                        Digitador = c.String(maxLength: 10, unicode: false),
                        QtdFilhosMaiores = c.Int(),
                        UfNascimento = c.String(maxLength: 2, unicode: false),
                        PaisReside = c.String(maxLength: 30, unicode: false),
                        UfPaisReside = c.String(maxLength: 2, unicode: false),
                        CodigoMunicipioReside = c.Int(),
                        UfOab = c.String(maxLength: 2, unicode: false),
                        CodigoPais = c.Int(),
                        CodigoPaisOnu = c.Int(),
                    })
                .PrimaryKey(t => t.PessoasId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pessoas");
        }
    }
}
