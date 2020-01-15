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
    public class UsuarioConfig : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfig()
        {

            HasKey(c => c.UsuarioId);

            this.Property(c => c.UsuarioId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Senha)
                .IsRequired()
                .HasMaxLength(30);

            Property(c => c.Cpf)
                .HasMaxLength(14)
                .HasColumnType("varchar");

            Property(c => c.Matricula)
               .HasMaxLength(15)
               .HasColumnType("varchar");

            Property(c => c.Master)
                .HasColumnType("char")
                .HasMaxLength(1);

            Property(c => c.AlterarAto)
                .HasColumnType("char")
                .HasMaxLength(1);

            Property(c => c.AlterarSelo)
                .HasColumnType("char")
                .HasMaxLength(1);

            Property(c => c.ExcluirAto)
                .HasColumnType("char")
                .HasMaxLength(1);

            Property(c => c.SelarAto)
                .HasColumnType("char")
                .HasMaxLength(1);

            Property(c => c.LiberarSelo)
                .HasColumnType("char")
                .HasMaxLength(1);

            Property(c => c.ReservarSelo)
                .HasColumnType("char")
                .HasMaxLength(1);

            Property(c => c.AlterarEmolumentos)
                .HasColumnType("char")
                .HasMaxLength(1);
        }

    }
}
