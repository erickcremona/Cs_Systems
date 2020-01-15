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
    public class CadProcuracaoConfig : EntityTypeConfiguration<CadProcuracao>
    {
        public CadProcuracaoConfig()
        {

            HasKey(p => p.ProcuracaoId);


            Property(p => p.ProcuracaoId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Tipo)
                .HasColumnType("char")
                .HasMaxLength(1)
                .IsOptional();

            Property(p => p.Local)
                .HasColumnType("char")
                .HasMaxLength(1)
                .IsOptional();

            Property(p => p.Poderes)
                .HasColumnType("text")
                .HasMaxLength(5000)
                .IsOptional();


            Property(p => p.Resumo)
                .HasColumnType("text")
                .HasMaxLength(5000)
                .IsOptional();

            Property(p => p.Selo)
                .HasMaxLength(9)
                .IsOptional();

            Property(p => p.Livro)
               .HasMaxLength(20)
               .IsOptional();

            Property(p => p.FolhaInicio)
               .IsOptional();

            Property(p => p.FolhaFim)
               .IsOptional();

            Property(p => p.NumeroAto)
               .IsOptional();

            Property(p => p.DataLavratura)
                .HasColumnType("date")
              .IsOptional();

            Property(p => p.Observacao)
                .HasColumnType("text")
                .HasMaxLength(1000)
                .IsOptional();

            Property(p => p.SeloTipo)
               .HasMaxLength(9)
               .IsOptional();


            Property(p => p.NumeroAtoTipo)
             .IsOptional();

            Property(p => p.DataLavraturaTipo)
                .HasColumnType("date")
              .IsOptional();

            Property(p => p.LivroTipo)
               .HasMaxLength(20)
               .IsOptional();


            Property(p => p.FolhaInicioTipo)
               .IsOptional();

            Property(p => p.FolhaFimTipo)
               .IsOptional();


            Property(p => p.Emolumentos)
               .IsOptional();

            Property(p => p.Fetj)
              .IsOptional();

            Property(p => p.Funarpen)
              .IsOptional();

            Property(p => p.Fundperj)
              .IsOptional();

            Property(p => p.Funprj)
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

            Property(p => p.Pmcmv)
              .IsOptional();

            Property(p => p.CpfEscrevente)
              .HasMaxLength(15)
              .IsOptional();

            Property(p => p.TipoAto)
                .HasColumnType("char")
                .HasMaxLength(2)
                .IsOptional();

            Property(p => p.TipoLivro)
                .HasColumnType("char")
                .HasMaxLength(1)
                .IsOptional();

            Property(p => p.TipoLivroTipo)
                .HasColumnType("char")
                .HasMaxLength(1)
                .IsOptional();

            Property(p => p.DataVigencia)
                .HasColumnType("date")
              .IsOptional();

            Property(p => p.SeloEscritura)
              .HasMaxLength(9)
              .IsOptional();

            Property(p => p.CodigoLivro)
              .HasMaxLength(20)
              .IsOptional();

            Property(p => p.LavradoRj)
                .HasColumnType("char")
                .HasMaxLength(1)
                .IsOptional();

            Property(p => p.TipoCobranca)
                .HasColumnType("char")
                .HasMaxLength(2)
                .IsOptional();

            Property(p => p.DataModificado)
               .HasColumnType("date")
             .IsOptional();

            Property(p => p.HoraModificado)
              .HasMaxLength(10)
              .IsOptional();

            Property(p => p.Codigo)
              .IsOptional();

            Property(p => p.Bens)
                .HasColumnType("char")
                .HasMaxLength(1)
                .IsOptional();

            Property(p => p.Cancelado)
                .HasColumnType("char")
                .HasMaxLength(1)
                .IsOptional();

            Property(p => p.Natureza)
                .HasColumnType("char")
                .HasMaxLength(3)
                .IsOptional();

            Property(p => p.Recibo)
              .HasMaxLength(20)
              .IsOptional();

            Property(p => p.Ausente)
               .HasColumnType("char")
               .HasMaxLength(1)
               .IsOptional();

            Property(p => p.Enviado)
               .HasColumnType("char")
               .HasMaxLength(1)
               .IsOptional();

            Property(p => p.Texto)
                .HasColumnType("text")
                .HasMaxLength(5000)
                .IsOptional();


            Property(p => p.DataDistribuicao)
              .HasColumnType("date")
            .IsOptional();

            Property(p => p.DescricaoCustas)
                .HasColumnType("text")
                .HasMaxLength(5000)
                .IsOptional();


            Property(p => p.NumeroDistribuicao)
             .IsOptional();


            Property(p => p.DistribuicaoEnviada)
              .HasColumnType("char")
              .HasMaxLength(1)
              .IsOptional();

            Property(p => p.UfOrigem)
              .HasColumnType("char")
              .HasMaxLength(2)
              .IsOptional();

            Property(p => p.CodigoMunicipioOrigem)
             .HasMaxLength(50)
             .IsOptional();

            Property(p => p.ConsultaTipo)
            .HasMaxLength(20)
            .IsOptional();

            Property(p => p.Outorgantes)
             .IsOptional();

            Property(p => p.Diligencias)
             .IsOptional();

            Property(p => p.CodigoServentiaTipo)
             .IsOptional();

            Property(p => p.AleatorioTipo)
             .HasMaxLength(3)
             .IsOptional();

            Property(p => p.AleatorioEscritura)
            .HasMaxLength(3)
            .IsOptional();

            Property(p => p.Aleatorio)
            .HasMaxLength(3)
            .IsOptional();

            Property(p => p.Letra)
            .HasMaxLength(5)
            .IsOptional();
        }
    }
}
