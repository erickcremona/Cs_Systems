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
    public class NaturezasConfig: EntityTypeConfiguration<Naturezas>
    {
        public NaturezasConfig()
        {
            HasKey(p => p.NaturezasId);

            Property(p => p.NaturezasId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Doi)
                .HasMaxLength(1);

            Property(p => p.Censec)
                .HasMaxLength(1);

            Property(p => p.Tipo)
                .HasMaxLength(1);
        }
    }
}
