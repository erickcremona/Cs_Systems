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
    public class ConfiguracoesConfig : EntityTypeConfiguration<Configuracoes>
    {
        public ConfiguracoesConfig()
        {
            HasKey(p => p.ConfiguracoesId);

            Property(p => p.ConfiguracoesId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Mutua)
                .HasColumnType("decimal")
                .IsOptional();

            Property(p => p.Acoterj)
                .HasColumnType("decimal")
                .IsOptional();

            Property(p => p.Distribuicao)
                .HasColumnType("decimal")
                .IsOptional();

            Property(p => p.Indisponibilidade)
                .HasColumnType("decimal")
                .IsOptional();

            Property(p => p.PathXML)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsOptional();

            Property(p => p.PathModelo)
               .HasColumnType("varchar")
               .HasMaxLength(100)
               .IsOptional();

            Property(p => p.PathEscritura)
               .HasColumnType("varchar")
               .HasMaxLength(100)
               .IsOptional();

            Property(p => p.PathProcuracao)
               .HasColumnType("varchar")
               .HasMaxLength(100)
               .IsOptional();

            Property(p => p.PathTestamento)
               .HasColumnType("varchar")
               .HasMaxLength(100)
               .IsOptional();

            Property(p => p.PathDistribuicao)
               .HasColumnType("varchar")
               .HasMaxLength(100)
               .IsOptional();

            Property(p => p.PathImagem)
               .HasColumnType("varchar")
               .HasMaxLength(100)
               .IsOptional();

            Property(p => p.PathLogoTipo)
               .HasColumnType("varchar")
               .HasMaxLength(100)
               .IsOptional();

            Property(p => p.PathCensec)
               .HasColumnType("varchar")
               .HasMaxLength(100)
               .IsOptional();

            Property(p => p.PathRecibo)
               .HasColumnType("varchar")
               .HasMaxLength(100)
               .IsOptional();

            Property(p => p.PathRgi)
               .HasColumnType("varchar")
               .HasMaxLength(100)
               .IsOptional();

            Property(p => p.Recibo)
               .HasColumnType("char")
               .HasMaxLength(1)
               .IsOptional();

            Property(p => p.MostrarCustas)
               .HasColumnType("char")
               .HasMaxLength(1)
               .IsOptional();

            Property(p => p.Cabecalho)
               .HasColumnType("char")
               .HasMaxLength(1)
               .IsOptional();

            Property(p => p.ImagemConfirmacao)
               .HasColumnType("char")
               .HasMaxLength(1)
               .IsOptional();

            Property(p => p.CabecalhoConfirmacao)
               .HasColumnType("char")
               .HasMaxLength(1)
               .IsOptional();

            Property(p => p.OcultarObjetoConfirmacao)
               .HasColumnType("char")
               .HasMaxLength(1)
               .IsOptional();

            Property(p => p.ObjetoRsumo)
               .HasColumnType("char")
               .HasMaxLength(1)
               .IsOptional();

            Property(p => p.ControlarDist)
               .HasColumnType("char")
               .HasMaxLength(1)
               .IsOptional();

            Property(p => p.PerguntaImpressao)
               .HasColumnType("char")
               .HasMaxLength(1)
               .IsOptional();

            Property(p => p.CodigoMovimento)               
               .IsOptional();

            Property(p => p.Tabela)
               .IsOptional();

            Property(p => p.Cidades)
               .HasColumnType("char")
               .HasMaxLength(1)
               .IsOptional();

            Property(p => p.ExportaRecibo)
               .HasColumnType("char")
               .HasMaxLength(1)
               .IsOptional();

            Property(p => p.Impressora)
               .HasColumnType("char")
               .HasMaxLength(1)
               .IsOptional();

            Property(p => p.ImprimirRecibo)
               .HasColumnType("char")
               .HasMaxLength(1)
               .IsOptional();

            Property(p => p.DistribuicaoPara)
               .HasColumnType("varchar")
               .HasMaxLength(200)
               .IsOptional();

            Property(p => p.ConjugeDist)
               .HasColumnType("char")
               .HasMaxLength(1)
               .IsOptional();

            Property(p => p.QualifResumoDist)
               .HasColumnType("char")
               .HasMaxLength(1)
               .IsOptional();

            Property(p => p.SerieAtual)
               .IsOptional();

            Property(p => p.SenhaMaster)
               .HasColumnType("varchar")
               .HasMaxLength(30)
               .IsOptional();

            Property(p => p.TabeliaoDistribuicao)
               .HasColumnType("char")
               .HasMaxLength(1)
               .IsOptional();

            Property(p => p.DigitarSelo)
               .HasColumnType("char")
               .HasMaxLength(1)
               .IsOptional();

            Property(p => p.VersaoMinuta)
               .IsOptional();

            Property(p => p.EtiquetaCabecalho)
               .HasColumnType("char")
               .HasMaxLength(1)
               .IsOptional();

            Property(p => p.EtiquetaAntes)
               .IsOptional();

            Property(p => p.EtiquetaApos)
               .IsOptional();

            Property(p => p.EtiquetaEsquerda)
               .IsOptional();

            Property(p => p.EtiquetaAltura)
               .HasColumnType("varchar")
               .HasMaxLength(10)
               .IsOptional();

            Property(p => p.EtiquetaLargura)
               .HasColumnType("varchar")
               .HasMaxLength(10)
               .IsOptional();

            Property(p => p.EtiquetaNegrito)
               .HasColumnType("char")
               .HasMaxLength(1)
               .IsOptional();

            Property(p => p.BlkaToDist)
               .HasColumnType("char")
               .HasMaxLength(1)
               .IsOptional();

            Property(p => p.TipoDiligencia)
               .HasColumnType("char")
               .HasMaxLength(1)
               .IsOptional();

            Property(p => p.Diligencia_Pmcmv)
               .HasColumnType("char")
               .HasMaxLength(1)
               .IsOptional();

            Property(p => p.SeloCertLeft)
               .IsOptional();

            Property(p => p.SeloCertTop)
               .IsOptional();

            Property(p => p.Rgi)
               .HasColumnType("char")
               .HasMaxLength(1)
               .IsOptional();
        }
    }
}
