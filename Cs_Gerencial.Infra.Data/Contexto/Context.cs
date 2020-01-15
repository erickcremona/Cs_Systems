using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using Cs_Gerencial.Dominio.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;
using Cs_Gerencial.Infra.Data.EntityConfig;
using MySql.Data.Entity;

namespace Cs_Gerencial.Infra.Data.Contexto
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class Context : DbContext
    {
       
        public Context()
            : base("Cs_Gerencial")
            
        {
            DbConfiguration.SetConfiguration(new MySqlEFConfiguration());
        }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Serventia> Serventia { get; set; }

        public DbSet<CompraSelo> CompraSelo { get; set; }

        public DbSet<Bancos> Bancos { get; set; }

        public DbSet<Conjuntos> Conjuntos { get; set; }

        public DbSet<Contas> Contas { get; set; }

        public DbSet<Fornecedores> Fornecedores { get; set; }

        public DbSet<Indisponibilidades> Indisponibilidades { get; set; }

        public DbSet<LogSistema> LogSistema { get; set; }

        public DbSet<Municipios> Municipios { get; set; }

        public DbSet<MunicipiosCensec> MunicipiosCensec { get; set; }

        public DbSet<Nacionalidades> Nacionalidades { get; set; }

        public DbSet<NacionalidadesOnu> NacionalidadesOnu { get; set; }

        public DbSet<Planos> Planos { get; set; }

        public DbSet<Series> Series { get; set; }

        public DbSet<ServentiasOutras> ServentiasOutras { get; set; }

        public DbSet<Selos> Selos { get; set; }

        public DbSet<Atribuicoes> Atribuicoes { get; set; }

        public DbSet<Parametros> Parametros { get; set; }

        public DbSet<Adicional> Adicional { get; set; }

        public DbSet<Pessoas> Pessoas { get; set; }

        public DbSet<Participantes> Participantes { get; set; }

        public DbSet<TabelaCustas> TabelaCustas { get; set; }

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
            modelBuilder.Configurations.Add(new ServentiaConfig());
            modelBuilder.Configurations.Add(new CompraSeloConfig());
            modelBuilder.Configurations.Add(new BancosConfig());
            modelBuilder.Configurations.Add(new ConjuntosConfig());
            modelBuilder.Configurations.Add(new ContasConfig());
            modelBuilder.Configurations.Add(new FornecedoresConfig());
            modelBuilder.Configurations.Add(new IndisponibilidadesConfig());
            modelBuilder.Configurations.Add(new LogSistemaConfig());
            modelBuilder.Configurations.Add(new MunicipiosConfig());
            modelBuilder.Configurations.Add(new MunicipiosCensecConfig());
            modelBuilder.Configurations.Add(new NacionalidadesConfig());
            modelBuilder.Configurations.Add(new NacionalidadesOnuConfig());
            modelBuilder.Configurations.Add(new PlanosConfig());
            modelBuilder.Configurations.Add(new SeriesConfig());
            modelBuilder.Configurations.Add(new ServentiasOutrasConfig());
            modelBuilder.Configurations.Add(new SelosConfig());
            modelBuilder.Configurations.Add(new AtribuicoesConfig());
            modelBuilder.Configurations.Add(new ParametrosConfig());
            modelBuilder.Configurations.Add(new AdicionalConfig());
            modelBuilder.Configurations.Add(new PessoasConfig());
            modelBuilder.Configurations.Add(new ParticipantesConfig());
            modelBuilder.Configurations.Add(new TabelaCustasConfig());

        }

      

    }
}