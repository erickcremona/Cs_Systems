using Cs_Gerencial.Dominio.Entities;
using Cs_Gerencial.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Gerencial.Infra.Data.Repositorios
{
    public class RepositorioPessoas: RepositorioBase<Pessoas>, IRepositorioPessoas
    {


        public RepositorioPessoas()
        {
            Db = new Contexto.Context();
        }

        public List<string> ObterListaOrgaoEmissor()
        {
            return Db.Pessoas.Select(p => p.OrgaoRG).Distinct().ToList();
        }


        public List<string> ObterListaProfissao()
        {
            return Db.Pessoas.Where(p => p.Profissao != "" && p.Profissao != null).Select(p => p.Profissao).Distinct().ToList();
        }


        public List<Pessoas> ObterListaPessoasPorCpfCnpj(string cpfCnpj)
        {
            Db = new Contexto.Context();
            return Db.Pessoas.Where(p => p.CpfCgc == cpfCnpj).OrderBy(p => p.DataCadastro).ToList();
        }


        public Pessoas SalvarAlteracao(Pessoas pessoa)
        {
            var salvar = Db.Pessoas.Where(p => p.PessoasId == pessoa.PessoasId).FirstOrDefault();

            salvar.Atualizado = pessoa.Atualizado;
            salvar.Bairro = pessoa.Bairro;
            salvar.Cep = pessoa.Cep;
            salvar.Cidade = pessoa.Cidade;
            salvar.CodigoMunicipioReside = pessoa.CodigoMunicipioReside;
            salvar.CodigoPais = pessoa.CodigoPais;
            salvar.CodigoPaisOnu = pessoa.CodigoPaisOnu;
            salvar.Conjuge = pessoa.Conjuge;
            salvar.CpfCgc = pessoa.CpfCgc;
            salvar.DataCadastro = pessoa.DataCadastro;
            salvar.DataCasamento = pessoa.DataCasamento;
            salvar.DataEmissaoRG = pessoa.DataEmissaoRG;
            salvar.DataNascimento = pessoa.DataNascimento;
            salvar.DataObito = pessoa.DataObito;
            salvar.Digitador = pessoa.Digitador;
            salvar.Digital = pessoa.Digital;
            salvar.Endereco = pessoa.Endereco;
            salvar.EsctadoCivil = pessoa.EsctadoCivil;
            salvar.FolhaObito = pessoa.FolhaObito;
            salvar.IfpDetran = pessoa.IfpDetran;
            salvar.Justificativa = pessoa.Justificativa;
            salvar.LivroObito = pessoa.LivroObito;
            salvar.Nacionalidade = pessoa.Nacionalidade;
            salvar.Naturalidade = pessoa.Naturalidade;
            salvar.Nome = pessoa.Nome;
            salvar.NomeMae = pessoa.NomeMae;
            salvar.NomePai = pessoa.NomePai;
            salvar.Observacao = pessoa.Observacao;
            salvar.OrgaoRG = pessoa.OrgaoRG;
            salvar.PaisReside = pessoa.PaisReside;
            salvar.Profissao = pessoa.Profissao;
            salvar.QtdFilhosMaiores = pessoa.QtdFilhosMaiores;
            salvar.RegimeBens = pessoa.RegimeBens;
            salvar.Rg = pessoa.Rg;
            salvar.SeloObito = pessoa.SeloObito;
            salvar.Sexo = pessoa.Sexo;
            salvar.Sobrenome = pessoa.Sobrenome;
            salvar.TipoEndereco = pessoa.TipoEndereco;
            salvar.TipoPessoa = pessoa.TipoPessoa;
            salvar.Uf = pessoa.Uf;
            salvar.UfNascimento = pessoa.UfNascimento;
            salvar.UfOab = pessoa.UfOab;
            salvar.UfPaisReside = pessoa.UfPaisReside;
            
            Update(salvar);
            return salvar;
        }
    }
}
