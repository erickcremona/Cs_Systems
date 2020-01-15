using Cs_Gerencial.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Gerencial.Infra.Data.EntityConfig
{
    public class PessoasConfig: EntityTypeConfiguration<Pessoas>
    {
        public PessoasConfig()
        {
            HasKey(p => p.PessoasId)
                .Property(p => p.PessoasId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.TipoPessoa)
                .HasMaxLength(1)
                .IsRequired();

            Property(p => p.DataCadastro)
                .HasColumnType("Date")
                .IsOptional();
            

            Property(p => p.CpfCgc)
                .HasMaxLength(18);

            Property(p => p.Rg)
                .HasMaxLength(25);

            Property(p => p.OrgaoRG)
                .HasMaxLength(70);

            Property(p => p.DataEmissaoRG)
                .HasColumnType("Date")
                .IsOptional();

            Property(p => p.Nacionalidade)
                .HasMaxLength(30);

            Property(p => p.Uf)
                .HasMaxLength(2);

            Property(p => p.Cep)
                .HasMaxLength(10);

            Property(p => p.RegimeBens)
                .HasMaxLength(30);

            Property(p => p.DataCasamento)
                .HasColumnType("Date")
                .IsOptional();

            Property(p => p.DataObito)
                .HasColumnType("Date")
                .IsOptional();

            Property(p => p.LivroObito)
               .HasMaxLength(18);

            Property(p => p.FolhaObito)
               .HasMaxLength(10);

            Property(p => p.SeloObito)
               .HasMaxLength(9);

            Property(p => p.DataNascimento)
               .HasColumnType("Date")
               .IsOptional();

            Property(p => p.Justificativa)
               .HasMaxLength(800);

            Property(p => p.Digital)
               .HasMaxLength(800);

            Property(p => p.TipoEndereco)
               .HasMaxLength(1);

            Property(p => p.Sexo)
               .HasMaxLength(1);

            Property(p => p.IfpDetran)
               .HasMaxLength(1);

            Property(p => p.Atualizado)
               .HasMaxLength(1);

            Property(p => p.Digitador)
               .HasMaxLength(10);

            Property(p => p.QtdFilhosMaiores)
               .IsOptional();

            Property(p => p.UfNascimento)
               .HasMaxLength(2);

            Property(p => p.PaisReside)
               .HasMaxLength(30);

            Property(p => p.UfPaisReside)
               .HasMaxLength(2);

            Property(p => p.CodigoMunicipioReside)
               .IsOptional();

            Property(p => p.UfOab)
               .HasMaxLength(2);

            Property(p => p.CodigoPais)
               .IsOptional();

            Property(p => p.CodigoPaisOnu)
               .IsOptional();

            Property(p => p.EsctadoCivil)
                .IsOptional();
        }
    }
}
