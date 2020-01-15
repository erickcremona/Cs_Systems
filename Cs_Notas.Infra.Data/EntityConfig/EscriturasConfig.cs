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
    public class EscriturasConfig : EntityTypeConfiguration<Escrituras>
    {
        public EscriturasConfig()
        {

            Property(p => p.EscriturasId)
                 .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.TipoAto)
                .HasColumnType("char")
                .HasMaxLength(2)
                .IsOptional();

            Property(p => p.DataAtoRegistro)
                .HasColumnType("Date")
                .IsOptional();

            Property(p => p.CpfEscrevente)
                .HasMaxLength(15)
                .IsOptional();

            Property(p => p.DataAtoCertidao)
               .HasColumnType("Date")
               .IsOptional();

            Property(p => p.SeloEscritura)
                .HasMaxLength(9)
                .IsOptional();

            Property(p => p.Aleatorio)
                .HasMaxLength(3)
                .IsOptional();

            Property(p => p.LivroEscritura)
                .HasMaxLength(20)
                .IsOptional();

            Property(p => p.Recibo)
                .HasMaxLength(20)
                .IsOptional();

            Property(p => p.Natureza)
                .HasMaxLength(3)
                .IsOptional();

            Property(p => p.TipoCobranca)
                .HasMaxLength(2)
                .IsOptional();

            Property(p => p.IndProcuracao)
                .HasMaxLength(1)
                .IsOptional();

            Property(p => p.IndAlvara)
               .HasMaxLength(1)
               .IsOptional();

            Property(p => p.DataDistribuicao)
              .HasColumnType("Date")
              .IsOptional();

            Property(p => p.DistribuicaoEnviada)
              .HasMaxLength(1)
              .IsOptional();

            Property(p => p.Objeto)
              .HasMaxLength(255)
              .IsOptional();

            Property(p => p.Observacao)
              .HasMaxLength(255)
              .IsOptional();

            Property(p => p.OficioRecebido)
              .HasMaxLength(20)
              .IsOptional();

            Property(p => p.OficioGerado)
              .HasMaxLength(20)
              .IsOptional();

            Property(p => p.Censec)
              .HasMaxLength(1)
              .IsOptional();

            Property(p => p.TipoCensec)
              .HasMaxLength(1)
              .IsOptional();

            Property(p => p.LivroReferencia)
              .HasMaxLength(20)
              .IsOptional();

            Property(p => p.FolhaReferencia)
              .HasMaxLength(10)
              .IsOptional();

            Property(p => p.UfReferencia)
              .HasMaxLength(2)
              .IsOptional();

            Property(p => p.CartorioReferencia)
              .HasMaxLength(50)
              .IsOptional();

            Property(p => p.UfOrigem)
              .HasMaxLength(2)
              .IsOptional();

            Property(p => p.Cancelado)
              .HasMaxLength(1)
              .IsOptional();

            Property(p => p.Enviado)
             .HasMaxLength(1)
             .IsOptional();

            Property(p => p.DataModificacao)
             .HasColumnType("Date")
             .IsOptional();

            Property(p => p.HoraModificacao)
             .HasColumnType("DateTime")
             .IsOptional();

            Property(p => p.Letra)
             .HasMaxLength(5)
             .IsOptional();

            Property(p => p.FolhasInicio)
              .IsOptional();

            Property(p => p.FolhasFim)
              .IsOptional();

            Property(p => p.NumeroAto)
              .IsOptional();

            Property(p => p.CodigoAto)
              .IsOptional();

            Property(p => p.ValorEscritua)
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

            Property(p => p.Mutua)
           .IsOptional();

            Property(p => p.Acoterj)
           .IsOptional();

            Property(p => p.Distribuicao)
           .IsOptional();

            Property(p => p.Total)
          .IsOptional();

            Property(p => p.Paginas)
          .IsOptional();

            Property(p => p.Unidades)
         .IsOptional();

            Property(p => p.Diligencias)
         .IsOptional();

            Property(p => p.TipoAtoCesdi)
               .IsOptional();

            Property(p => p.NaturezaCensec)
               .IsOptional();

            Property(p => p.Desconhecido)
              .IsOptional();

            Property(p => p.CidadeReferencia)
              .IsOptional();

            Property(p => p.CodigoServentia)
              .IsOptional();

            Property(p => p.CodigoAto)
              .IsOptional();

            Property(p => p.Serventia)
              .IsOptional();

            Property(p => p.Path)
              .IsOptional();

            Property(p => p.Login)
              .IsOptional();

            Property(p => p.QtdFilhosMenores)
              .IsOptional();

            Property(p => p.ResponsavelFilhosMenores)
               .IsOptional();
           
        }
    }
}
