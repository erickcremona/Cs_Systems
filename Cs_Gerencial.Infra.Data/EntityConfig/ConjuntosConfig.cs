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
    class ConjuntosConfig : EntityTypeConfiguration<Conjuntos>
    {
        public ConjuntosConfig()
        {
            HasKey(p => p.ConjuntoId);

            Property(p => p.ConjuntoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Selo)
                .HasMaxLength(9)
                .HasColumnType("varchar")
                .IsRequired();

            Property(p => p.Letra)
                .HasMaxLength(4)
                .HasColumnType("varchar")
                .IsRequired();

            Property(p => p.Aleatorio)
                .HasMaxLength(3)
                .HasColumnType("varchar")
                .IsRequired();
        }
    }
}
