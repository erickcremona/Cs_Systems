using Cs_IssPrefeitura.Aplicacao.Interfaces;
using Cs_IssPrefeitura.Aplicacao.ServicosApp;
using Cs_IssPrefeitura.Dominio.Interfaces.Repositorios;
using Cs_IssPrefeitura.Dominio.Interfaces.Servicos;
using Cs_IssPrefeitura.Dominio.Servicos;
using Cs_IssPrefeitura.Infra.Data.Repositorios;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_IssPrefeitura
{
    public static class BootStrap
    {
        public static Container Container;

        public static void Start()
        {
            Container = new Container();

            


            Container.Register(typeof(IAppServicoBase<>), typeof(AppServicoBase<>), Lifestyle.Singleton);
            Container.Register(typeof(IServicoBase<>), typeof(ServicoBase<>), Lifestyle.Singleton);
            Container.Register(typeof(IRepositorioBase<>), typeof(RepositorioBase<>), Lifestyle.Singleton);

            Container.Register<IAppServicoConfiguracoes, AppServicoConfiguracoes>(Lifestyle.Singleton);
            Container.Register<IServicoConfiguracoes, ServicoConfiguracoes>(Lifestyle.Singleton);
            Container.Register<IRepositorioConfiguracoes, RepositorioConfiguracoes>(Lifestyle.Singleton);

            Container.Register<IAppServicoAtoIss, AppServicoAtoIss>(Lifestyle.Singleton);
            Container.Register<IServicoAtoIss, ServicoAtoIss>(Lifestyle.Singleton);
            Container.Register<IRepositorioAtoIss, RepositorioAtoIss>(Lifestyle.Singleton);

            Container.Register<IAppServicoApuracaoIss, AppServicoApuracaoIss>(Lifestyle.Singleton);
            Container.Register<IServicoApuracaoIss, ServicoApuracaoIss>(Lifestyle.Singleton);
            Container.Register<IRepositorioApuracaoIss, RepositorioApuracaoIss>(Lifestyle.Singleton);

            Container.Register<IAppServicoUsuario, AppServicoUsuario>(Lifestyle.Singleton);
            Container.Register<IServicoUsuario, ServicoUsuario>(Lifestyle.Singleton);
            Container.Register<IRepositorioUsuario, RepositorioUsuario>(Lifestyle.Singleton);

            Container.Verify();

        }
    }
}
