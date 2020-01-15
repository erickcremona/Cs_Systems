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
    public class BensAtosConjuntosConfig: EntityTypeConfiguration<BensAtosConjuntos>
    {
        public BensAtosConjuntosConfig()
        {
            HasKey(p => p.BensAtosConjuntosID);

            Property(p => p.BensAtosConjuntosID)
                 .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


            Property(p => p.IdEscritura)
                .IsOptional();
        }
    }
}
