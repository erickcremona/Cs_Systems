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
    public class CompraSeloConfig : EntityTypeConfiguration<CompraSelo>
    {
        public CompraSeloConfig()
        {
            HasKey(c => c.CompraSeloId);

            this.Property(c => c.CompraSeloId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(c => c.DataPedido)
                .HasColumnType("Date");

            Property(c => c.HoraPedido)
                .HasColumnType("varchar")
                .HasMaxLength(10);

            Property(c => c.Grerj)
                .HasMaxLength(15);

            Property(c => c.DataPagamento)
                .HasColumnType("Date");

            Property(c => c.HoraPagamento)
                .HasColumnType("varchar")
                .HasMaxLength(10);

            Property(c => c.CpfSolicitante)
                .HasMaxLength(11);

            Property(c => c.DataGeracao)
                .HasColumnType("Date");

            Property(c => c.HoraGeracao)
                .HasColumnType("varchar")
                .HasMaxLength(10);
        }
    }
}
