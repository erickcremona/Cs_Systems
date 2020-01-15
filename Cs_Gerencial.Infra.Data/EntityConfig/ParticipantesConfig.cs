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
    public class ParticipantesConfig: EntityTypeConfiguration<Participantes>
    {
        public ParticipantesConfig()
        {
            HasKey(p => p.ParticipantesId)
                .Property(p => p.ParticipantesId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Descricao)
                .HasMaxLength(40)
                 .IsRequired();

            Property(p => p.Oculto)
                .HasMaxLength(1)
                .IsRequired();

            Property(p => p.Doi)
                .HasMaxLength(2)
                .IsRequired();

            Property(p => p.Distribuicao)
                .HasMaxLength(1)
                .IsRequired();

            Property(p => p.OcultarXmlTd)
                .HasMaxLength(1);
        }
    }
}
