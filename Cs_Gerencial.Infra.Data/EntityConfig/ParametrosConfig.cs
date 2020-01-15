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
    public class ParametrosConfig: EntityTypeConfiguration<Parametros>
    {
        public ParametrosConfig()
        {
            HasKey(p => p.ParametrosId);

            Property(p => p.ParametrosId)
               .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.PathSelosImportados)
                .HasColumnType("varchar")
                .HasMaxLength(255);

            Property(p => p.PathSelosNaoImportados)
                .HasColumnType("varchar")
                .HasMaxLength(255);

            Property(p => p.SenhaMaster)
                .HasColumnType("varchar")
                .HasMaxLength(30);

            Property(p => p.PathSelosCenib)
               .HasColumnType("varchar")
               .HasMaxLength(255);

            Property(p => p.AlicotaIss)
               .HasPrecision(9,3);
        }
    }
}
