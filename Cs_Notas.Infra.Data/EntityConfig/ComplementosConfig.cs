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
    public class ComplementosConfig: EntityTypeConfiguration<Complementos>
    {
        public ComplementosConfig()
        {
            HasKey(p => p.ComplementoId);

            Property(p => p.ComplementoId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Data)
                .HasColumnType("Date")
                .IsOptional();

            Property(p => p.Cct)
                .HasMaxLength(9)
                .IsOptional();

            Property(p => p.TipoCobranca)
                .HasMaxLength(2)
                .IsOptional();

            Property(p => p.IdEscritura)
                .IsOptional();

            Property(p => p.DataPratica)
                .HasColumnType("Date")
                .IsOptional();

            Property(p => p.Livro)
                .IsOptional();

            Property(p => p.FolhaInicio)
                .IsOptional();

            Property(p => p.FolhaFim)
                .IsOptional();

            Property(p => p.NumeroAto)
                .IsOptional();

            Property(p => p.Selo)
                .HasMaxLength(9)
                .IsOptional();

            Property(p => p.Aleatorio)
                .HasMaxLength(3)
                .IsOptional();

            Property(p => p.Emolumentos)                
                .IsOptional();

            Property(p => p.Fetj)
                .IsOptional();

            Property(p => p.Fundperj)
                .IsOptional();

            Property(p => p.Funprj)
                .IsOptional();

            Property(p => p.Funarpen)
                .IsOptional();

            Property(p => p.Pmcmv)
                .IsOptional();

            Property(p => p.Iss)
                .IsOptional();

            Property(p => p.Total)
                .IsOptional();

            Property(p => p.NomeEscrevente)
                .HasMaxLength(40)
                .IsOptional();

            Property(p => p.CpfEscrevente)
                .HasMaxLength(11)
                .IsOptional();

            Property(p => p.Enviado)
                .HasMaxLength(1)
                .IsOptional();

        }
    }
}
