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
    public class RevogadosConfig: EntityTypeConfiguration<Revogados>
    {
        public RevogadosConfig()
        {
            HasKey(p => p.RevogadosId);

            Property(p => p.RevogadosId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


            Property(p => p.IdTestamento)
                .IsOptional();

            Property(p => p.LavradoRio)
                .HasColumnType("char")
                .HasMaxLength(1)
                .IsOptional();

            Property(p => p.Selo)
                .HasMaxLength(9)
                .IsOptional();

            Property(p => p.Serventia)
               .HasMaxLength(60)
               .IsOptional();

            Property(p => p.Data)
               .HasColumnType("Date")
               .IsOptional();

            Property(p => p.Livro)
              .HasMaxLength(18)
              .IsOptional();

            Property(p => p.Ato)
               .IsOptional();


            Property(p => p.Uf)
                .HasColumnType("char")
                .HasMaxLength(2)
                .IsOptional();

            Property(p => p.CodigoServentia)
               .IsOptional();

            Property(p => p.Aleatorio)
             .HasMaxLength(3)
             .IsOptional();

            Property(p => p.Eletronico)
               .HasColumnType("char")
               .HasMaxLength(1)
               .IsOptional();
        }
    }
}
