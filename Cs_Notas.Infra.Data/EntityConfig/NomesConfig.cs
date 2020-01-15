using Cs_Notas.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Infra.Data.EntityConfig
{
    public class NomesConfig: EntityTypeConfiguration<Nomes>
    {
        public NomesConfig()
        {

            HasKey(p => p.NomeId)
                .Property(p => p.NomeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


            Property(p => p.IdEscritura)
                .IsOptional();

            Property(p => p.IdProcuracao)
               .IsOptional();

            Property(p => p.IdTestamento)
               .IsOptional();

            Property(p => p.Ordem)
              .IsOptional();

            Property(p => p.Principal)
                .HasMaxLength(1);

            Property(p => p.Nomenclatura)
                .HasMaxLength(3);

            Property(p => p.Descricao)
                .HasMaxLength(45);

            Property(p => p.TipoPessoa)
                .HasMaxLength(1);

            Property(p => p.Documento)
                .HasMaxLength(15);

            Property(p => p.Rg)
                .HasMaxLength(15);

            Property(p => p.DataEmissao)
                .HasColumnType("Date")
                .IsOptional();

            Property(p => p.Orgao)
                .HasMaxLength(60);

            Property(p => p.Nacionalidade)
                .HasMaxLength(60);

            Property(p => p.EstadoCivil)
                .HasMaxLength(1);

            Property(p => p.RegimeCasamento)
                .HasMaxLength(40);

            Property(p => p.Justificativa)
                .HasMaxLength(255);

            Property(p => p.DataNascimento)
                .HasColumnType("Date")
                .IsOptional();
            

            Property(p => p.Profissao)
                .HasMaxLength(60);

            Property(p => p.Endereco)
                .HasMaxLength(80);

            Property(p => p.Municipio)
                .HasMaxLength(60);

            Property(p => p.Uf)
                .HasMaxLength(2);

            Property(p => p.DataCasamento)
                .HasColumnType("Date")
                .IsOptional();

            Property(p => p.DataObito)
                .HasColumnType("Date")
                .IsOptional();

            Property(p => p.LivroObito)
                .HasMaxLength(20);

            Property(p => p.FolhasObito)
                .HasMaxLength(20);

            Property(p => p.SeloObito)
                .HasMaxLength(9);

            Property(p => p.Representa)
                .HasMaxLength(1);

            Property(p => p.Bairro)
                .HasMaxLength(80);

            Property(p => p.Participacao)
                .IsOptional();

            Property(p => p.Tipo)
                .HasMaxLength(2);

            Property(p => p.Procurador)
                .HasMaxLength(1);

            Property(p => p.CpfProcurador)
                .HasMaxLength(20);

            Property(p => p.CnpjRepresenta)
                .HasMaxLength(20);

            Property(p => p.TipoRepresenta)
                .HasMaxLength(1);

            Property(p => p.NumeroBIB)
                .HasMaxLength(16);

            Property(p => p.Ocultar)
                .HasMaxLength(1);

            Property(p => p.Escritura)
                .HasMaxLength(800);

            Property(p => p.OcultarDistribuicao)
                .HasMaxLength(1);

            Property(p => p.NumeroCRE)
                .HasMaxLength(16);

            Property(p => p.Qualidade)
                .HasMaxLength(50);

            Property(p => p.Tpj)
                .IsOptional();

            Property(p => p.Situacao)
                .IsOptional();

            Property(p => p.OcultarXML)
                .HasMaxLength(1);

            Property(p => p.Hash)
               .HasMaxLength(50);

            Property(p => p.PreTeste)
               .HasMaxLength(30);

            Property(p => p.NumeroConjuge)
                .IsOptional();

        }
    }
}
