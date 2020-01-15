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
    public class RegimesConfig: EntityTypeConfiguration<Regimes>
    {
        public RegimesConfig()
        {
            HasKey(p => p.RegimesId)
                .Property(p => p.RegimesId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(p => p.Descricao)
                .HasMaxLength(30);

            Property(p => p.Censec)
                .HasMaxLength(30);

        }
    }
}
