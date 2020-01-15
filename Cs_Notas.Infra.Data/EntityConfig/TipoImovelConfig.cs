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
    public class TipoImovelConfig: EntityTypeConfiguration<TipoImovel>
    {
        public TipoImovelConfig()
        {
            HasKey(p => p.TipoImovelId)
                .Property(p => p.TipoImovelId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Descricao)
                .HasMaxLength(50);

        }
    }
}
