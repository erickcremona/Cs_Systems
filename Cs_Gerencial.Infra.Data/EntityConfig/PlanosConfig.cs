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
    public class PlanosConfig: EntityTypeConfiguration<Planos>
    {
        public PlanosConfig()
        {
            HasKey(p => p.PlanoId);

            Property(p => p.PlanoId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Descricao)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            Property(p => p.Principal)
                .HasColumnType("char")
                .HasMaxLength(1)
                .IsRequired();
        }
    }
}
