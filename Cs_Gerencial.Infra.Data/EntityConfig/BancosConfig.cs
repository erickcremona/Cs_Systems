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
    public class BancosConfig: EntityTypeConfiguration<Bancos>
    {
        public BancosConfig()
        {
            HasKey(c => c.BancosId);

            Property(c => c.Codigo)
                .HasMaxLength(10);

            Property(c => c.Nome)
                .HasMaxLength(60);

            Property(c => c.Agencia)
                .HasMaxLength(20);

            Property(c => c.Conta)
                .HasMaxLength(20);
        }
    }
}
