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
    public class ImovelConfig : EntityTypeConfiguration<Imovel>
    {
        public ImovelConfig()
        {
            Property(p => p.ImovelId)
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.IdEscritura)
                .IsOptional();

            Property(p => p.Ordem)
                .IsOptional();
            Property(p => p.TipoRecolhimento)
                .HasColumnType("char")
                .HasMaxLength(1);

            Property(p => p.TipoImovel)
                .HasColumnType("char")
                .HasMaxLength(1);

            Property(p => p.InscricaoImobiliaria)
                .HasMaxLength(20);

            Property(P => P.Local)
                .HasMaxLength(20);

            Property(p => p.Incra)
                .HasMaxLength(20);

            Property(p => p.Area)
                .HasMaxLength(20);

            Property(p => p.Denominacao)
                .HasMaxLength(20);

            Property(p => p.SRF)
               .HasMaxLength(20);

            Property(p => p.Endereco)
               .HasMaxLength(80);

            Property(p => p.Bairro)
               .HasMaxLength(90);

            Property(p => p.Municipio)
               .HasMaxLength(60);

            Property(p => p.Uf)
                .HasColumnType("char")
               .HasMaxLength(2);

            Property(p => p.Guia)
               .HasMaxLength(20);

            Property(p => p.Adquirente)
               .HasMaxLength(15);

            Property(p => p.Cedente)
            .HasMaxLength(20);

            Property(p => p.MaiorPorcao)
               .HasMaxLength(20);

            Property(p => p.Valor)
               .IsOptional();

            Property(p => p.ParteTranferida)
               .HasMaxLength(20);

            Property(p => p.TipoTransacao)
                .HasColumnType("char")
               .HasMaxLength(2);
               

            Property(p => p.DescricaoTransacao)
                .HasMaxLength(60);

            Property(p => p.Retificacao)
                .HasColumnType("char")
               .HasMaxLength(1);

            Property(p => p.DataAlienacao)
                .HasColumnType("Date");

            Property(p => p.FormaAlienacao)
                .HasColumnType("char")
               .HasMaxLength(1);

            Property(p => p.ValorNaoConsta)
                 .HasColumnType("char")
               .HasMaxLength(1);

            Property(p => p.ValorAlienacao)
                .IsOptional();

            Property(p => p.BaseItbiItcd)
                .IsOptional();

            Property(p => p.TipoImovelDoi)
                .HasColumnType("char")
               .HasMaxLength(2);

            Property(p => p.Construcao)
                .HasColumnType("char")
               .HasMaxLength(1);
            
            Property(p => p.AreaNaoConsta)
                .HasColumnType("char")
               .HasMaxLength(1);

            Property(p => p.Numero)
                .IsOptional();

            Property(p => p.Cep)
               .HasMaxLength(8);

            Property(p => p.ValorItbi)
                .HasColumnType("char")
               .HasMaxLength(1);

            Property(p => p.Matricula)
              .HasMaxLength(20);

            Property(p => p.SubTipo)
               .HasColumnType("char")
              .HasMaxLength(1);

            Property(p => p.LocalTerreno)
              .HasMaxLength(250);

            Property(p => p.ValorGuia)
               .IsOptional();

            Property(p => p.Temp)
              .HasMaxLength(250);

            Property(p => p.Detalhes)
              .HasMaxLength(250);

            Property(p => p.Situacao)
               .HasColumnType("char")
              .HasMaxLength(1);

            Property(p => p.CodigoMunicipio)
                .IsOptional();

            Property(p => p.Unidade)
               .IsOptional();

            Property(p => p.Serventia)
               .IsOptional();

            Property(p => p.TipoImposto)
             .HasMaxLength(4);

            Property(p => p.Principal)
              .HasColumnType("char")
             .HasMaxLength(1);

            Property(p => p.TipoBem)
              .HasColumnType("char")
             .HasMaxLength(1);

            Property(p => p.Objeto)
             .HasMaxLength(250);
        }
    }
}
