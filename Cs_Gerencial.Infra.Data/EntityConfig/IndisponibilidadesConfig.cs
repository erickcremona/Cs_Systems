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
    public class IndisponibilidadesConfig: EntityTypeConfiguration<Indisponibilidades>
    {
        public IndisponibilidadesConfig()
        {
            HasKey(p => p.IndisponibilidadeId);

            Property(p => p.IndisponibilidadeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Protocolo)
                .HasColumnType("varchar")
                .HasMaxLength(40)
                .IsOptional();

            Property(p => p.DataPedido)
                .HasColumnType("Date")
                .IsOptional();

            Property(p => p.HoraPedido)
                .HasColumnType("varchar")
                .HasMaxLength(10)
                .IsOptional();

            Property(p => p.NumeroProcesso)
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .IsOptional();

            Property(p => p.Telefone)
               .HasColumnType("varchar")
               .HasMaxLength(15)
               .IsOptional();

            Property(p => p.NomeInstituicao)
               .HasColumnType("varchar")
               .HasMaxLength(250)
               .IsOptional();

            Property(p => p.ForumVara)
               .HasColumnType("varchar")
               .HasMaxLength(200)
               .IsOptional();

            Property(p => p.Usuario)
               .HasColumnType("varchar")
               .HasMaxLength(250)
               .IsOptional();

            Property(p => p.Email)
               .HasColumnType("varchar")
               .HasMaxLength(250)
               .IsOptional();

            Property(p => p.NomeIndividuo)
               .HasColumnType("varchar")
               .HasMaxLength(250)
               .IsOptional();

            Property(p => p.CpfCnpj)
               .HasColumnType("varchar")
               .HasMaxLength(35)
               .IsOptional();

            Property(p => p.Cancelado)
               .HasColumnType("varchar")
               .HasMaxLength(1)
               .IsOptional();

            Property(p => p.Cancelamento)
               .HasColumnType("varchar")
               .HasMaxLength(40)
               .IsOptional();

            Property(p => p.TipoCancelamento)
               .IsOptional();

            Property(p => p.DataCancelamento)
               .HasColumnType("varchar")
               .HasMaxLength(19)
               .IsOptional();

            Property(p => p.HoraCancelamento)
               .HasColumnType("varchar")
                .HasMaxLength(10)
                .IsOptional();

            Property(p => p.Origem)
               .HasColumnType("varchar")
               .HasMaxLength(250)
               .IsOptional();

        }

    }
}
