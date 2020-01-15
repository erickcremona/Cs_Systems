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
    public class ServentiaConfig: EntityTypeConfiguration<Serventia>
    {
        public ServentiaConfig()
        {
            HasKey(c => c.ServentiaId);

            this.Property(c => c.ServentiaId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            

            Property(p => p.Bairro)
                .HasMaxLength(40);

            Property(p => p.Uf)
                .HasMaxLength(2)
                .HasColumnType("char");

            Property(p => p.Cep)
                .HasMaxLength(8);

            Property(p => p.Telefone)
                .HasMaxLength(14);

            Property(p => p.Telefone2)
                .HasMaxLength(14);

            Property(p => p.Email)
                .HasMaxLength(60);

            
            
        }
    }
}
