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
    public class ProcuracaoEscrituraConfig: EntityTypeConfiguration<ProcuracaoEscritura>
    {
        public ProcuracaoEscrituraConfig()
        {
            HasKey(p => p.ProcuracaoEscrituraId);

            Property(p => p.ProcuracaoEscrituraId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.IdEscritura)
                .IsOptional();

            Property(p => p.Data)
                .HasColumnType("Date");

            Property(p => p.Livro)
                .HasMaxLength(20);

            Property(p => p.Folhas)
                .HasMaxLength(10);

            Property(p => p.Ato)
                .HasMaxLength(10);

            Property(p => p.Selo)
                .HasMaxLength(9);

            Property(p => p.Aleatorio)
                .HasMaxLength(3);

            Property(p => p.Outorgantes)
                .HasMaxLength(600);

            Property(p => p.Outorgados)
                .HasMaxLength(600);

            Property(p => p.Lavrado)
                .HasMaxLength(1);

            Property(p => p.Serventia)
                .HasMaxLength(150);

            Property(p => p.UfOrigem)
                .HasMaxLength(2);

                
        }
    }
}
