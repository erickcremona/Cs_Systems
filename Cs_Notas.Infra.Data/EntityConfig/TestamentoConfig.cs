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
    public class TestamentoConfig: EntityTypeConfiguration<CadTestamento>
    {
        public TestamentoConfig()
        {
            HasKey(p => p.TestamentoId);

            Property(p => p.TestamentoId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.TipoAto)
                .HasColumnType("char")
                .HasMaxLength(2)
                .IsOptional();

            Property(p => p.Revogatorio)
               .HasColumnType("char")
               .HasMaxLength(1)
               .IsOptional();

            Property(p => p.Selo)
                .HasMaxLength(9)
                .IsOptional();

            Property(p => p.Recibo)
               .HasMaxLength(20)
               .IsOptional();

            Property(p => p.DataAto)
               .HasColumnType("Date")
               .IsOptional();

            Property(p => p.CpfEscrevente)
              .HasMaxLength(15)
              .IsOptional();

            Property(p => p.TipoCobranca)
               .HasColumnType("char")
               .HasMaxLength(2)
               .IsOptional();
            


            Property(p => p.Aleatorio)
                .HasMaxLength(3)
                .IsOptional();

            Property(p => p.Livro)
                .HasMaxLength(20)
                .IsOptional();
            
            Property(p => p.Natureza)
                .HasMaxLength(3)
                .IsOptional();



            Property(p => p.DataDistribuicao)
              .HasColumnType("Date")
              .IsOptional();

            Property(p => p.DistribuicaoEnviada)
              .HasMaxLength(1)
              .IsOptional();
            
          

            Property(p => p.Uf)
              .HasMaxLength(2)
              .IsOptional();
                     

            Property(p => p.Cancelado)
              .HasMaxLength(1)
              .IsOptional();

            Property(p => p.Enviado)
             .HasMaxLength(1)
             .IsOptional();

            Property(p => p.DataModificado)
             .HasColumnType("Date")
             .IsOptional();

            Property(p => p.HoraModificado)
             .HasMaxLength(10)
             .IsOptional();

            Property(p => p.Letra)
             .HasMaxLength(5)
             .IsOptional();

            Property(p => p.FolhaInicio)
              .IsOptional();

            Property(p => p.FolhaFim)
              .IsOptional();

            Property(p => p.NumeroAto)
              .IsOptional();

            Property(p => p.Codigo)
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
          

            Property(p => p.CodigoServentia)
              .IsOptional();


            Property(p => p.Serventia)
              .IsOptional();

            Property(p => p.Path)
              .IsOptional();

            Property(p => p.Login)
              .IsOptional();

            

            Property(p => p.Cpf)
                .HasMaxLength(15)
                .IsOptional();

            Property(p => p.Rg)
                .HasMaxLength(15)
                .IsOptional();

            Property(p => p.DataEmissaoRg)
                .HasColumnType("Date")
                .IsOptional();

            Property(p => p.OrgaoRg)
                .HasMaxLength(60)
                .IsOptional();

            Property(p => p.Nacionalidade)
                .HasMaxLength(60)
                .IsOptional();

            Property(p => p.EstadoCivil)
                .HasMaxLength(1)
                .IsOptional();

            Property(p => p.RegimeCasamento)
                .HasMaxLength(40)
                .IsOptional();

            Property(p => p.Justificativa)
                .HasMaxLength(255)
                .IsOptional();

            Property(p => p.DataNascimento)
                .HasColumnType("Date")
                .IsOptional();

            Property(p => p.Local)
              .HasColumnType("char")
              .HasMaxLength(1)
              .IsOptional();


            Property(p => p.Nome)
               .HasMaxLength(100)
               .IsOptional();

            Property(p => p.Nacionalidade)
               .HasMaxLength(30)
               .IsOptional();


            Property(p => p.CodigoPais)
             .IsOptional();

           
            Property(p => p.Enviado)
             .HasColumnType("char")
             .HasMaxLength(1)
             .IsOptional();

            Property(p => p.TipoTestamento)
             .HasColumnType("char")
             .HasMaxLength(1)
             .IsOptional();

            Property(p => p.Naturalidade)
              .HasMaxLength(40)
              .IsOptional();

            Property(p => p.NumeroDistribuicao)
             .IsOptional();

            Property(p => p.CodigoPaisOnu)
             .IsOptional();


            Property(p => p.Sexo)
             .HasColumnType("char")
             .HasMaxLength(1)
             .IsOptional();

            Property(p => p.TipoJustificativa)
             .IsOptional();

            Property(p => p.Letra)
              .HasMaxLength(5)
              .IsOptional();

        }
    }
}
