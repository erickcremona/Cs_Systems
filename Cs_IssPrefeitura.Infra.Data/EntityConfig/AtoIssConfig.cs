using Cs_IssPrefeitura.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_IssPrefeitura.Infra.Data.EntityConfig
{
    public class AtoIssConfig : EntityTypeConfiguration<AtoIss>
    {
        public AtoIssConfig()
        {
            HasKey(p => p.AtoIssId);

            Property(p => p.AtoIssId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Data)
                .HasColumnType("Date")
                .IsRequired();

            Property(p => p.Atribuicao)
                .HasMaxLength(80)
                .IsRequired();

            Property(p => p.TipoAto)
               .HasMaxLength(80)
               .IsRequired();

            Property(p => p.Selo)
               .HasMaxLength(9)
               .IsRequired();

            Property(p => p.Aleatorio)
               .HasMaxLength(3);

            Property(p => p.TipoCobranca)
               .HasMaxLength(2);

            Property(p => p.Emolumentos)
               .IsRequired();
                       

            Property(p => p.Iss)
             .IsRequired();

            Property(p => p.Total)
            .IsRequired();

            

        }
    }
}
