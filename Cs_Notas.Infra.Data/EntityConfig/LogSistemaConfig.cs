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
    public class LogSistemaConfig : EntityTypeConfiguration<LogSistema>
    {
        public LogSistemaConfig()
        {
            HasKey(p => p.LogId);

            Property(p => p.LogId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.IdEscritura)
                .IsOptional();

            Property(p => p.Tela)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsOptional();

            Property(p => p.Data)
                .HasColumnType("Date")
                .IsOptional();

            Property(p => p.Hora)
                .HasColumnType("varchar")
                .HasMaxLength(10)
                .IsOptional();

            Property(p => p.Descricao)
                .HasColumnType("varchar")
                .HasMaxLength(255)
                .IsOptional();

            Property(p => p.IdUsuario)
                .IsOptional();

            Property(p => p.Usuario)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsOptional();

            Property(p => p.Maquina)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsOptional();

            Property(p => p.IdEscritura)
                .IsOptional();

            Property(p => p.HoraClose)
                .HasColumnType("varchar")
                .HasMaxLength(10)
                .IsOptional();

            Property(p => p.InicioTela)
                .HasColumnType("varchar")
                .HasMaxLength(255)
                .IsOptional();

            Property(p => p.FimTela)
               .HasColumnType("varchar")
               .HasMaxLength(255)
               .IsOptional();
        }
    }
}
