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
    public class TabelaCustasConfig: EntityTypeConfiguration<TabelaCustas>
    {
        public TabelaCustasConfig()
        {
            HasKey(p => p.TabelaCustasId);

            Property(p => p.TabelaCustasId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Tabela)
                .HasMaxLength(20);

            Property(p => p.Item)
                .HasMaxLength(20);

            Property(p => p.SubItem)
                .HasMaxLength(20);

            Property(p => p.Descricao)
                .HasMaxLength(100);

            Property(p => p.Valor)
           .HasPrecision(9, 3);
        }
    }
}
