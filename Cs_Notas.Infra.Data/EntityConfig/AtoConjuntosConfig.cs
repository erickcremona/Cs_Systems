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
    public class AtoConjuntosConfig: EntityTypeConfiguration<AtoConjuntos>
    {
        public AtoConjuntosConfig()
        {
            HasKey(p => p.ConjuntoId);

            Property(p => p.ConjuntoId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.LavradoRj)
                .HasMaxLength(1);

            Property(p => p.UfOrigem)
                .HasMaxLength(2);

            Property(p => p.Serventia)
                .HasMaxLength(150);

            Property(p => p.Selo)
                .HasMaxLength(9);

            Property(p => p.Aleatorio)
                .HasMaxLength(3);

            Property(p => p.IndSelo)
                .HasMaxLength(1);

            Property(p => p.TipoLivro)
                .HasMaxLength(1);

            Property(p => p.Livro)
                .HasMaxLength(18);

            Property(p => p.Folhas)
                .HasMaxLength(10);

            Property(p => p.Ato)
                .HasMaxLength(10);

            Property(p => p.Participantes)
                .HasMaxLength(255);

            Property(p => p.Procuracao)
                .HasMaxLength(1);

            Property(p => p.OrigemLivro)
                .HasMaxLength(25);

            Property(p => p.OrigemFolhaInicio)
                .HasMaxLength(25);

            Property(p => p.OrigemFolhaFim)
                .HasMaxLength(25);

            Property(p => p.OrigemNumeroAto)
                .HasMaxLength(25);

            Property(p => p.OrigemLavrado)
                .HasMaxLength(2);

            Property(p => p.TipoLivro)
                .HasMaxLength(1);

            Property(p => p.OrigemOutorgado)
                .HasMaxLength(1);

            Property(p => p.OrigemServentia)
                .HasMaxLength(250);

            Property(p => p.OrigemUf)
                .HasMaxLength(250);

            Property(p => p.OrigemNotificacao)
                .HasMaxLength(25);

            Property(p => p.IdEscritura)
                .IsOptional();

            Property(p => p.Ordem)
                .IsOptional();

            Property(p => p.TabelaCustas)
                .IsOptional();

            Property(p => p.Natureza)
                .IsOptional();

            Property(p => p.CodigoServentia)
                .IsOptional();

            Property(p => p.Data)
                .HasColumnType("Date")
                .IsOptional();

            Property(p => p.Valor)
                .IsOptional();

            Property(p => p.OrigemDataAto)
                .HasColumnType("Date")
                .IsOptional();            
        }
    }
}
