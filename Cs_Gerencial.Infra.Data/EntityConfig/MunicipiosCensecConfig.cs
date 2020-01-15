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
    public class MunicipiosCensecConfig : EntityTypeConfiguration<MunicipiosCensec>
    {
        public MunicipiosCensecConfig()
        {
            HasKey(p => p.MunicipioCensecId);

            Property(p => p.MunicipioCensecId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Codigo)
                .IsRequired();

            Property(p => p.Uf)
                .HasColumnType("char")
                .HasMaxLength(2);


            Property(p => p.Nome)
                .HasColumnType("varchar")
                .HasMaxLength(100);
        }
    }
}
