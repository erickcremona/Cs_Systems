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
    public class CertidaoProcuracaoConfig: EntityTypeConfiguration<CertidaoProcuracao>
    {
        public CertidaoProcuracaoConfig()
        {
            HasKey(p => p.CertidaoProcuracaoId);

            Property(p => p.CertidaoProcuracaoId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Data)
                .HasColumnType("Date");

            Property(p => p.Selo)
                .HasMaxLength(9);

            Property(p => p.Cpf1)
                .HasMaxLength(11);

            Property(p => p.Cpf2)
                .HasMaxLength(11);

            Property(p => p.Cpf3)
                .HasMaxLength(11);

            Property(p => p.TipoCobranca)
                .HasMaxLength(2);

            Property(p => p.DataModificado)
            .HasColumnType("Date")
            .IsOptional();

            Property(p => p.HoraModificado)
             .HasColumnType("DateTime")
             .IsOptional();
            
            Property(p => p.Emolumentos)
              .IsOptional();

            Property(p => p.Fetj)
              .IsOptional();

            Property(p => p.Fundperj)
              .IsOptional();

            Property(p => p.Funprj)
              .IsOptional();

            Property(p => p.Funarpen)
             .IsOptional();

            Property(p => p.Pmcmv)
            .IsOptional();

            Property(p => p.Iss)
            .IsOptional();

            Property(p => p.Aleatorio)
                .HasMaxLength(3);

            Property(p => p.UF_Origem)
                .HasMaxLength(2);

            Property(p => p.Recibo)
               .HasMaxLength(20);

        }
    }
}
