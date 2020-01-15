using Cs_IssPrefeitura.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_IssPrefeitura.Infra.Data.EntityConfig
{
    public class ConfiguracoesConfig: EntityTypeConfiguration<Config>
    {
        public ConfiguracoesConfig()
        {
            HasKey(p => p.ConfiguracoesId);

            Property(p => p.Titular)
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.CpfTitular)
                .HasMaxLength(14);

            Property(p => p.Substituto)
                .HasMaxLength(50)
                .IsOptional();

            Property(p => p.RazaoSocial)
                .HasMaxLength(100)
                .IsRequired();

            Property(p => p.Cnpj)
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.Cnpj)
                .HasMaxLength(20);

            Property(p => p.ProximoLivro)
                .IsRequired();

            Property(p => p.ProximaFolha)
               .IsRequired();

            Property(p => p.TipoCalculoIss)
                .HasMaxLength(15)
                .IsRequired();

            Property(p => p.ValorAliquota)
                .IsRequired();

            Property(p => p.TotalFolhasPorLivro)
                .IsRequired();

            Property(p => p.Bairro)
                .HasMaxLength(40)
                .IsOptional();

            Property(p => p.Cep)
                .HasMaxLength(10)
                .IsOptional();

            Property(p => p.Cidade)
                .HasMaxLength(30)
                .IsOptional();

            Property(p => p.Telefone1)
                .HasMaxLength(10)
                .IsOptional();

            Property(p => p.Telefone2)
                .HasMaxLength(10)
                .IsOptional();

            Property(p => p.Email)
                .HasMaxLength(40)
                .IsOptional();

            Property(p => p.Endereco)
                .HasMaxLength(60)
                .IsOptional();

            Property(p => p.Uf)
                .HasMaxLength(2)
                .IsOptional();

            Property(p => p.Codigo)
                .IsOptional();


            Property(p => p.NomeArquivoImportando)
                 .HasMaxLength(300);
        }
    }
}
