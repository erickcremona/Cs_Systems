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
    public class ParteConjuntosConfig: EntityTypeConfiguration<ParteConjuntos>
    {
        public ParteConjuntosConfig()
        {
            HasKey(p => p.ParteConjuntosId);

            Property(p => p.ParteConjuntosId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.IdEscritura)
                .IsOptional();

            Property(p => p.IdConjunto)
               .IsRequired();

            Property(p => p.IdNome)
               .IsRequired();
        }
    }
}
