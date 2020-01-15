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
    public class AdicionalConfig: EntityTypeConfiguration<Adicional>
    {
        public AdicionalConfig()
        {
            HasKey(p => p.AdicionalId);

            Property(p => p.AdicionalId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Ativo)
                .HasMaxLength(1);

            Property(p => p.Ordem)
                .IsOptional();

            Property(p => p.Atribuicao)
                .IsOptional();

            Property(p => p.Codigo)
                .IsOptional();

            Property(p => p.Tipo)
                .HasMaxLength(2)
                .IsOptional();

            Property(p => p.Descricao)
                .HasMaxLength(250)
                .IsOptional();

            Property(p => p.Emolumentos)
                .IsOptional();

            Property(p => p.Fetj)
                .IsOptional();

            Property(p => p.Fundperj)
                .IsOptional();

            Property(p => p.Funperj)
                .IsOptional();

            Property(p => p.Funarpen)
                .IsOptional();

            Property(p => p.Pmcmv)
                .IsOptional();

            Property(p => p.Mutua)
                .IsOptional();

            Property(p => p.Iss)
                .IsOptional();
            
            Property(p => p.Acoterj)
                .IsOptional();

            Property(p => p.Distribuicao)
                .IsOptional();

            Property(p => p.Total)
                .IsOptional();

            Property(p => p.Minimo)
                .IsOptional();

            Property(p => p.Maximo)
                .IsOptional();

            Property(p => p.Dias)
                .IsOptional();

            Property(p => p.Convenio)
                .HasMaxLength(1)
                .IsOptional();

           
        }
    }
}
