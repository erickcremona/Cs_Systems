using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cs_IssPrefeitura.Dominio.Entities;
using Cs_IssPrefeitura.Infra.Data.EntityConfig;

namespace Cs_IssPrefeitura.Infra.Data.Contexto
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class Context : DbContext
    {

        public Context()
            : base("Cs_IssPrefeitura")
        {
            DbConfiguration.SetConfiguration(new MySqlEFConfiguration());
        }

        public DbSet<AtoIss> AtoIss { get; set; }

        public DbSet<ApuracaoIss> ApuracaoIss { get; set; }

        public DbSet<Config> Configuracoes { get; set; }

        public DbSet<Usuario> Usuario { get; set; }


       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {



            modelBuilder.Configurations.Add(new AtoIssConfig());
            modelBuilder.Configurations.Add(new ApuracaoIssConfig());
            modelBuilder.Configurations.Add(new ConfiguracoesConfig());
            modelBuilder.Configurations.Add(new UsuarioConfig());

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


          

        }



    }
}
