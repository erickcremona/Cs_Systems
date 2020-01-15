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
    public class CidadesIbgeConfig: EntityTypeConfiguration<CidadesIbge>
    {
        public CidadesIbgeConfig()
        {
            HasKey(p => p.CidadesIbgeId);

            Property(p => p.CidadesIbgeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Codigo)
                .IsRequired();

            Property(p => p.Uf)
                .HasMaxLength(2);

            Property(p => p.Nome)
                .HasMaxLength(60);
        }
    }
}
