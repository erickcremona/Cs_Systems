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
    public class NacionalidadesConfig: EntityTypeConfiguration<Nacionalidades>
    {
        public NacionalidadesConfig()
        {
            HasKey(p => p.NacionalidadeId);

            Property(p => p.NacionalidadeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Codigo)
                .IsRequired();

            Property(p => p.Pais)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.Nacionalidade)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            Property(p => p.AdjetivoPatrio)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            
        }
    }
}
