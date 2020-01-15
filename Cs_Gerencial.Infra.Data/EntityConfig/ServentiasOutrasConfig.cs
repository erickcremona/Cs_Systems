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
    public class ServentiasOutrasConfig: EntityTypeConfiguration<ServentiasOutras>
    {
        public ServentiasOutrasConfig()
        {
            HasKey(p => p.ServentiasOutrasId);

            Property(p => p.ServentiasOutrasId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Descricao)
                .IsRequired();
        }
    }
}
