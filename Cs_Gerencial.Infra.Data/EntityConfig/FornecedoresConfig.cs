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
    public class FornecedoresConfig : EntityTypeConfiguration<Fornecedores>
    {
        public FornecedoresConfig()
        {
            HasKey(p => p.FornecedorId);

            Property(p => p.FornecedorId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.RazaoSocial)
                .HasColumnType("varchar")
                .HasMaxLength(120);

            Property(p => p.NomeFantasia)
                .HasColumnType("varchar")
                .HasMaxLength(100);

            Property(p => p.Cnpj)
                .HasColumnType("varchar")
                .HasMaxLength(14);
                
        }
    }
}
