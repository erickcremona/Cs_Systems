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
    public class SeriesConfig: EntityTypeConfiguration<Series>
    {
        public SeriesConfig()
        {
            HasKey(p => p.SerieId);

            Property(p => p.SerieId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            
            Property(p => p.IdCompra)
                .IsRequired();

            Property(p => p.Letra)
                .IsRequired()
                .HasMaxLength(4);

           
        }
    }
}
