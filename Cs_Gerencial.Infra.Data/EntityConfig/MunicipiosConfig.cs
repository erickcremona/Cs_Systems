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
    public class MunicipiosConfig : EntityTypeConfiguration<Municipios>
    {
        public MunicipiosConfig()
        {
            HasKey(p => p.MunicipioId);

            Property(p => p.MunicipioId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Codigo)
                .IsRequired();

            Property(p => p.Uf)
                .HasColumnType("char")
                .HasMaxLength(2)
                .IsRequired();

            Property(p => p.Nome)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();
        }

    }
}
