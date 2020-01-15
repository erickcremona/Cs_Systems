using Cs_Gerencial.Dominio.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace Cs_Gerencial.Infra.Data.EntityConfig
{
    public class UsuarioConfig : EntityTypeConfiguration<Usuario>
    {
        
        public UsuarioConfig()
        {

            HasKey(c => c.UsuarioId);

            this.Property(c => c.UsuarioId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(c => c.NomeUsuario)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Senha)
                .IsRequired()
                .HasMaxLength(30);
        }

    }
}
