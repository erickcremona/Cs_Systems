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
    public class ContasConfig : EntityTypeConfiguration<Contas>
    {

        public ContasConfig()
        {
            HasKey(p => p.ContaId);

            Property(p => p.ContaId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.IdFornecedor)
                 .IsOptional();

            Property(p => p.IdBanco)
                .IsOptional();

            Property(p => p.IdPlano)
               .IsOptional();

            Property(p => p.IdAto)
               .IsOptional();

            Property(p => p.Atribuicao)
               .IsOptional();
                       
            Property(p => p.Livro)
                .HasColumnType("varchar")
                .HasMaxLength(25);

            Property(p => p.FolhaInicial)
              .IsOptional();

            Property(p => p.FolhaFinal)
               .IsOptional();

            Property(p => p.Protocolo)
               .IsOptional();

            Property(p => p.Matricula)
               .HasColumnType("varchar")
                .HasMaxLength(25);

            Property(p => p.Recibo)
               .IsOptional();
                       
            Property(p => p.Letra)
                .HasColumnType("varchar")
                .HasMaxLength(4);

            Property(p => p.Numero)
              .IsOptional();
                        
            Property(p => p.Aleatorio)
               .HasColumnType("varchar")
               .HasMaxLength(3);

            Property(p => p.Codigo)
              .IsOptional();
            
            Property(p => p.Fornecedor)
               .HasColumnType("varchar")
               .HasMaxLength(60);

            Property(p => p.Banco)
               .HasColumnType("varchar")
               .HasMaxLength(60);

            Property(p => p.Plano)
               .HasColumnType("varchar")
               .HasMaxLength(60);

            Property(p => p.Documento)
               .HasColumnType("varchar")
               .HasMaxLength(30);

            Property(p => p.Tipo)
               .HasColumnType("char")
               .HasMaxLength(2);

            Property(p => p.DataMovimento)
               .HasColumnType("Date");

            Property(p => p.DataPagamento)
               .HasColumnType("Date");

            Property(p => p.Total)
               .HasPrecision(9, 3);

            Property(p => p.FormaPagamento)
               .HasColumnType("varchar")
               .HasMaxLength(20);

            Property(p => p.NumeroCheque)
               .HasColumnType("varchar")
               .HasMaxLength(10);

            Property(p => p.Deposito)
               .HasColumnType("char")
               .HasMaxLength(1);
        }
    }
}
