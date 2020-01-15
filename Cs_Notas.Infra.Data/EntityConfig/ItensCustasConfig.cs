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
    public class ItensCustasConfig: EntityTypeConfiguration<ItensCustas>
    {
        public ItensCustasConfig()
        {
            HasKey(p => p.ItensCustasId);

            Property(p => p.ItensCustasId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.IdEscritura)
                .IsOptional();

            Property(p => p.IdProcuracao)
               .IsOptional();

            Property(p => p.IdTestamento)
               .IsOptional();

            Property(p => p.Tabela)
                .HasMaxLength(20);

            Property(p => p.Item)
               .HasMaxLength(20);

            Property(p => p.SubItem)
               .HasMaxLength(20);

            Property(p => p.Quantidade)
               .HasMaxLength(10);

            Property(p => p.Complemento)
               .HasMaxLength(50);

            Property(p => p.Excessao)
               .HasMaxLength(50);

            Property(p => p.Valor)
               .HasPrecision(9,3);

            Property(p => p.Total)
              .HasPrecision(9, 3);

            Property(p => p.Descricao)
               .HasMaxLength(100);

        }
    }
}
