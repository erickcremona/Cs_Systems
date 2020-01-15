using Cs_IssPrefeitura.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_IssPrefeitura.Infra.Data.EntityConfig
{
    public class ApuracaoIssConfig: EntityTypeConfiguration<ApuracaoIss>
    {
        public ApuracaoIssConfig()
        {
            HasKey(p => p.ApuracaoIssId);

            Property(p => p.ApuracaoIssId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.DataFechamento)
                .HasColumnType("Date")
                .IsRequired();
            
            Property(p => p.NomeMes)
                .HasMaxLength(15)
                .IsRequired();

            Property(p => p.Mes)
                .IsRequired();

            Property(p => p.Ano)
                .IsRequired();

            Property(p => p.Periodo)
                .HasMaxLength(30)
                .IsRequired();

            Property(p => p.Mes)
                .IsRequired();

            Property(p => p.Livro)
                .IsRequired();

            Property(p => p.Folha)
                .IsRequired();

            Property(p => p.Recibo)
                .HasMaxLength(10)
                .IsRequired();

            Property(p => p.Serie)
                .IsRequired();

            Property(p => p.Numero)
                .IsRequired();

            Property(p => p.Cancelado)
                .HasMaxLength(10)
                .IsOptional();

            Property(p => p.Faturamento)
                .IsRequired();
            
            Property(p => p.FundosEspeciais)
                .IsRequired();

            Property(p => p.BaseCalculo)
                .IsRequired();

            Property(p => p.Aliquota)
                .IsRequired();

            Property(p => p.ValorIssRecolhido)
                .IsRequired();
                       
        }
    }
}
