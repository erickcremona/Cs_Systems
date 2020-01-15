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
    public class CensecConfig: EntityTypeConfiguration<Censec>
    {
        public CensecConfig()
        {
            HasKey(p => p.CensecId);

            Property(p => p.CensecId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Codigo)
                .IsRequired();

            Property(p => p.Descricao)
                .HasMaxLength(80);
        }
    }
}
