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
    public class NacionalidadesOnuConfig : EntityTypeConfiguration<NacionalidadesOnu>
    {
        public NacionalidadesOnuConfig()
        {
            HasKey(p => p.NacionalidadeOnuId);

            Property(p => p.NacionalidadeOnuId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Codigo)
                .IsRequired();

            Property(p => p.Pais)
                .HasColumnType("varchar")
                .HasMaxLength(60)
                .IsRequired();
        }

    }
}
