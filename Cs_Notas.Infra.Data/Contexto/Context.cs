using Cs_Notas.Dominio.Entities;
using Cs_Notas.Infra.Data.EntityConfig;
using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Infra.Data.Contexto
{
    public class Context : DbContext
    {
        public Context()
            : base("Cs_Notas")
        {
            DbConfiguration.SetConfiguration(new MySqlEFConfiguration());
        }


        public DbSet<Usuario> Usuario { get; set; }
        
        public DbSet<LogSistema> LogSistema { get; set; }

        public DbSet<Configuracoes> Configuracoes { get; set; }

        public DbSet<Escrituras> Escrituras { get; set; }

        public DbSet<BensAtosConjuntos> BensAtosConjuntos { get; set; }

        public DbSet<Cartorios> Cartorios { get; set; }

        public DbSet<Censec> Censec { get; set; }

        public DbSet<CertidaoProcuracao> CertidaoProcuracao { get; set; }

        public DbSet<CidadesIbge> CidadesIbge { get; set; }

        public DbSet<Complementos> Complementos { get; set; }

        public DbSet<AtoConjuntos> AtoConjuntos { get; set; }

        public DbSet<Naturezas> Naturezas { get; set; }

        public DbSet<Nomes> Nomes { get; set; }

        public DbSet<Regimes> Regimes { get; set; }

        public DbSet<Imovel> Imovel { get; set; }

        public DbSet<ParteConjuntos> ParteConjuntos { get; set; }

        public DbSet<TipoImovel> TipoImovel { get; set; }

        public DbSet<TransacaoDoi> TransacaoDoi { get; set; }

        public DbSet<ProcuracaoEscritura> ProcuracaoEscritura { get; set; }

        public DbSet<ItensCustas> ItensCustas { get; set; }

        public DbSet<CadProcuracao> CadProcuracao { get; set; }

        public DbSet<CadTestamento> Testamento { get; set; }

        public DbSet<Revogados> Revogados { get; set; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));


            modelBuilder.Configurations.Add(new UsuarioConfig());
            modelBuilder.Configurations.Add(new LogSistemaConfig());
            modelBuilder.Configurations.Add(new ConfiguracoesConfig());
            modelBuilder.Configurations.Add(new EscriturasConfig());
            modelBuilder.Configurations.Add(new BensAtosConjuntosConfig());
            modelBuilder.Configurations.Add(new CartoriosConfig());
            modelBuilder.Configurations.Add(new CensecConfig());
            modelBuilder.Configurations.Add(new CertidaoProcuracaoConfig());
            modelBuilder.Configurations.Add(new CidadesIbgeConfig());
            modelBuilder.Configurations.Add(new ComplementosConfig());
            modelBuilder.Configurations.Add(new AtoConjuntosConfig());
            modelBuilder.Configurations.Add(new NaturezasConfig());
            modelBuilder.Configurations.Add(new NomesConfig());
            modelBuilder.Configurations.Add(new RegimesConfig());
            modelBuilder.Configurations.Add(new ImovelConfig());
            modelBuilder.Configurations.Add(new ParteConjuntosConfig());
            modelBuilder.Configurations.Add(new TipoImovelConfig());
            modelBuilder.Configurations.Add(new TransacaoDoiConfig());
            modelBuilder.Configurations.Add(new ProcuracaoEscrituraConfig());
            modelBuilder.Configurations.Add(new ItensCustasConfig());
            modelBuilder.Configurations.Add(new CadProcuracaoConfig());
            modelBuilder.Configurations.Add(new TestamentoConfig());
            modelBuilder.Configurations.Add(new RevogadosConfig());
        }
    }
}
