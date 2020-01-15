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
    public class UsuarioConfig: EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfig()
        {
            HasKey(p => p.UsuarioId);

            Property(p => p.UsuarioId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Nome)
                .HasMaxLength(70)
                .IsRequired();

            Property(p => p.Senha)
               .HasMaxLength(70)
               .IsRequired();
        }
    }
}
