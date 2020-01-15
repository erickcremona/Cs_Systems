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
    public class CartoriosConfig: EntityTypeConfiguration<Cartorios>
    {
        public CartoriosConfig()
        {
            HasKey(p => p.CartorioId);

            Property(p => p.CartorioId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Nome)
                .HasMaxLength(50);
            
        }
    }
}
