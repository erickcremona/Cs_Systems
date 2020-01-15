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
    public class SelosConfig: EntityTypeConfiguration<Selos>
    {
        public SelosConfig()
        {
            HasKey(p => p.SeloId);

            Property(p => p.SeloId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

           
            Property(p => p.Letra)
                .IsRequired()
                .HasMaxLength(4);

            Property(p => p.Numero)
                .IsRequired();

            Property(p => p.Aleatorio)
                .HasMaxLength(3)
                .IsOptional();

            Property(p => p.Cct)
                .IsRequired()
                .HasMaxLength(1)
                .HasColumnType("char");
            
            HasRequired(p => p.CompraSelo)
                .WithMany()
                .HasForeignKey(p => p.IdCompra);

            HasRequired(p => p.Series)
                .WithMany()
                .HasForeignKey(p => p.IdSerie);

            Property(p => p.Status)
                .IsRequired()
                .HasMaxLength(20);

            Property(p => p.Sistema)
                .IsOptional()
                .HasMaxLength(20);

            Property(p => p.IdReservado)
                .IsOptional();

            Property(p => p.Reservado)
                .HasColumnType("char")
                .HasMaxLength(1)
                .IsOptional();

            Property(p => p.DataReservado)
                .HasColumnType("Date")
                .IsOptional();

            Property(p => p.IdUsuarioReservado)
                .IsOptional();

            Property(p => p.UsuarioReservado)
                .IsOptional()
                .HasMaxLength(70);


            Property(p => p.FormReservado)
                .IsOptional()
                .HasMaxLength(30);

            Property(p => p.FormUtilizado)
                .IsOptional()
                .HasMaxLength(30);

            Property(p => p.IdAto)
                .IsOptional();

            Property(p => p.idReferencia)
                .IsOptional();

            Property(p => p.Atribuicao)
                .IsOptional();

            Property(p => p.DataPratica)
                .IsOptional()
                .HasColumnType("Date");

            Property(p => p.Matricula)
               .IsOptional()
               .HasMaxLength(25);

            Property(p => p.Livro)
                .IsOptional()
                .HasMaxLength(25);

            Property(p => p.FolhaInicial)
                .IsOptional();

            Property(p => p.FolhaFinal)
                .IsOptional();

            Property(p => p.NumeroAto)
                .IsOptional();

            Property(p => p.Protocolo)
                .IsOptional();
            
            Property(p => p.Recibo)
                .IsOptional();

            Property(p => p.Codigo)
                .IsOptional();

            Property(p => p.Convenio)
                .IsOptional()
                .HasColumnType("char")
                .HasMaxLength(1);

            Property(p => p.Natureza)
                .IsOptional();

            Property(p => p.Escrevente)
                .IsOptional();

            Property(p => p.Conjunto)
                .HasColumnType("char")
                .HasMaxLength(1)
                .IsOptional();

            Property(p => p.TipoCobranca)
                .HasColumnType("char")
                .HasMaxLength(2)
                .IsOptional();

            Property(p => p.Emolumentos)   
                .HasPrecision(9,3)
                .HasColumnAnnotation("Emolumentos", 0.000)
                .IsOptional();

            Property(p => p.Fetj)
                .HasPrecision(9, 3)
                .HasColumnAnnotation("Fetj", 0.000)
                .IsOptional();

            Property(p => p.Fundperj)
                .HasPrecision(9, 3)
                .HasColumnAnnotation("Fundperj", 0.000)
                .IsOptional();

            Property(p => p.Funperj)
                .HasPrecision(9, 3)
                .HasColumnAnnotation("Funperj", 0.000)
                .IsOptional();

            Property(p => p.Funarpen)
                .HasPrecision(9, 3)
                .HasColumnAnnotation("Funarpen", 0.000)
                .IsOptional();

            Property(p => p.Pmcmv)
                .HasPrecision(9, 3)
                .HasColumnAnnotation("Pmcmv", 0.000)
                .IsOptional();

            Property(p => p.Iss)
                .HasPrecision(9, 3)
                .HasColumnAnnotation("Iss", 0.000)
                .IsOptional();

            Property(p => p.Mutua)
                .HasPrecision(9, 3)
                .HasColumnAnnotation("Mutua", 0.000)
                .IsOptional();

            Property(p => p.Acoterj)
                .HasPrecision(9, 3)
                .HasColumnAnnotation("Acoterj", 0.000)
                .IsOptional();

            Property(p => p.Distribuicao)
                .HasPrecision(9, 3)
                .HasColumnAnnotation("Distribuicao", 0.000)
                .IsOptional();

            Property(p => p.Indisponibilidade)
              .HasPrecision(9, 3)
              .HasColumnAnnotation("Indisponibilidade", 0.000)
              .IsOptional();

            Property(p => p.Prenotacao)
              .HasPrecision(9, 3)
              .HasColumnAnnotation("Prenotacao", 0.000)
              .IsOptional();

            Property(p => p.Ar)
              .HasPrecision(9, 3)
              .HasColumnAnnotation("Ar", 0.000)
              .IsOptional();

            Property(p => p.Ar)
              .HasPrecision(9, 3)
              .HasColumnAnnotation("Ar", 0.000)
              .IsOptional();

            Property(p => p.TarifaBancaria)
              .HasPrecision(9, 3)
              .HasColumnAnnotation("TarifaBancaria", 0.000)
              .IsOptional();

            Property(p => p.Total)
              .HasPrecision(9, 3)
              .HasColumnAnnotation("Total", 0.000)
              .IsOptional();

           
        }
    }
}
