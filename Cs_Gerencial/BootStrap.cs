using Cs_Gerencial.Aplicacao.Interfaces;
using Cs_Gerencial.Aplicacao.ServicosApp;
using Cs_Gerencial.Dominio.Interfaces;
using Cs_Gerencial.Dominio.Interfaces.Repositorios;
using Cs_Gerencial.Dominio.Interfaces.Servicos;
using Cs_Gerencial.Dominio.Servicos;
using Cs_Gerencial.Infra.Data.Repositorios;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Gerencial
{
    public static class BootStrap
    {
        public static Container Container;

        public static void Start()
        {
            Container = new Container();

            Container.Register<IAppServicoBancos, AppServicoBancos>(Lifestyle.Singleton);
            Container.Register<IServicoBancos, ServicoBancos>(Lifestyle.Singleton);
            Container.Register<IRepositorioBancos, RepositorioBancos>(Lifestyle.Singleton);


            Container.Register(typeof(IAppServicoBase<>), typeof(AppServicoBase<>), Lifestyle.Singleton);
            Container.Register(typeof(IServicoBase<>), typeof(ServicoBase<>), Lifestyle.Singleton);
            Container.Register(typeof(IRepositorioBase<>), typeof(RepositorioBase<>), Lifestyle.Singleton);


            Container.Register<IAppServicoCompraSelo, AppServicoCompraSelo>(Lifestyle.Singleton);
            Container.Register<IServicoCompraSelo, ServicoCompraSelo>(Lifestyle.Singleton);
            Container.Register<IRepositorioCompraSelo, RepositorioCompraSelo>(Lifestyle.Singleton);


            Container.Register<IAppServicoConjuntos, AppServicoConjuntos>(Lifestyle.Singleton);
            Container.Register<IServicoConjuntos, ServicoConjuntos>(Lifestyle.Singleton);
            Container.Register<IRepositorioConjuntos, RepositorioConjuntos>(Lifestyle.Singleton);


            Container.Register<IAppServicoContas, AppServicoContas>(Lifestyle.Singleton);
            Container.Register<IServicoContas, ServicoContas>(Lifestyle.Singleton);
            Container.Register<IRepositorioContas, RepositorioContas>(Lifestyle.Singleton);


            Container.Register<IAppServicoFornecedores, AppServicoFornecedores>(Lifestyle.Singleton);
            Container.Register<IServicoFornecedores, ServicoFornecedores>(Lifestyle.Singleton);
            Container.Register<IRepositorioFornecedores, RepositorioFornecedores>(Lifestyle.Singleton);


            Container.Register<IAppServicoIndisponibilidades, AppServicoIndisponibilidades>(Lifestyle.Singleton);
            Container.Register<IServicoIndisponibilidades, ServicoIndisponibilidades>(Lifestyle.Singleton);
            Container.Register<IRepositorioIndisponibilidades, RepositorioIndisponibilidades>(Lifestyle.Singleton);


            Container.Register<IAppServicoLogSistema, AppServicoLogSistema>(Lifestyle.Singleton);
            Container.Register<IServicoLogSistema, ServicoLogSistema>(Lifestyle.Singleton);
            Container.Register<IRepositorioLogSistema, RepositorioLogSistema>(Lifestyle.Singleton);


            Container.Register<IAppServicoMunicipios, AppServicoMunicipios>(Lifestyle.Singleton);
            Container.Register<IServicoMunicipios, ServicoMunicipios>(Lifestyle.Singleton);
            Container.Register<IRepositorioMunicipios, RepositorioMunicipios>(Lifestyle.Singleton);


            Container.Register<IAppServicoMunicipiosCensec, AppServicoMunicipiosCensec>(Lifestyle.Singleton);
            Container.Register<IServicoMunicipiosCensec, ServicoMunicipiosCensec>(Lifestyle.Singleton);
            Container.Register<IRepositorioMunicipiosCensec, RepositorioMunicipiosCensec>(Lifestyle.Singleton);


            Container.Register<IAppServicoNacionalidades, AppServicoNacionalidades>(Lifestyle.Singleton);
            Container.Register<IServicoNacionalidades, ServicoNacionalidades>(Lifestyle.Singleton);
            Container.Register<IRepositorioNacionalidades, RepositorioNacionalidades>(Lifestyle.Singleton);


            Container.Register<IAppServicoNacionalidadesOnu, AppServicoNacionalidadesOnu>(Lifestyle.Singleton);
            Container.Register<IServicoNacionalidadesOnu, ServicoNacionalidadesOnu>(Lifestyle.Singleton);
            Container.Register<IRepositorioNacionalidadesOnu, RepositorioNacionalidadesOnu>(Lifestyle.Singleton);


            Container.Register<IAppServicoPlanos, AppServicoPlanos>(Lifestyle.Singleton);
            Container.Register<IServicoPlanos, ServicoPlanos>(Lifestyle.Singleton);
            Container.Register<IRepositorioPlanos, RepositorioPlanos>(Lifestyle.Singleton);


            Container.Register<IAppServicoSelos, AppServicoSelos>(Lifestyle.Singleton);
            Container.Register<IServicoSelos, ServicoSelos>(Lifestyle.Singleton);
            Container.Register<IRepositorioSelos, RepositorioSelos>(Lifestyle.Singleton);


            Container.Register<IAppServicoSeries, AppServicoSeries>(Lifestyle.Singleton);
            Container.Register<IServicoSeries, ServicoSeries>(Lifestyle.Singleton);
            Container.Register<IRepositorioSeries, RepositorioSeries>(Lifestyle.Singleton);


            Container.Register<IAppServicoServentia, AppServicoServentia>(Lifestyle.Singleton);
            Container.Register<IServicoServentia, ServicoServentia>(Lifestyle.Singleton);
            Container.Register<IRepositorioServentia, RepositorioServentia>(Lifestyle.Singleton);


            Container.Register<IAppServicoServentiasOutras, AppServicoServentiasOutras>(Lifestyle.Singleton);
            Container.Register<IServicoServentiasOutras, ServicoServentiasOutras>(Lifestyle.Singleton);
            Container.Register<IRepositorioServentiasOutras, RepositorioServentiasOutras>(Lifestyle.Singleton);


            Container.Register<IAppServicoUsuario, AppServicoUsuario>(Lifestyle.Singleton);
            Container.Register<IServicoUsuario, ServicoUsuario>(Lifestyle.Singleton);
            Container.Register<IRepositorioUsuario, RepositorioUsuario>(Lifestyle.Singleton);

            Container.Register<IAppServicoAtribuicoes, AppServicoAtribuicoes>(Lifestyle.Singleton);
            Container.Register<IServicoAtribuicoes, ServicoAtribuicoes>(Lifestyle.Singleton);
            Container.Register<IRepositorioAtribuicoes, RepositorioAtribuicoes>(Lifestyle.Singleton);

            Container.Register<IAppServicoParametros, AppServicoParametros>(Lifestyle.Singleton);
            Container.Register<IServicoParametros, ServicoParametros>(Lifestyle.Singleton);
            Container.Register<IRepositorioParametros, RepositorioParametros>(Lifestyle.Singleton);

            Container.Register<IAppServicoTabelaCustas, AppServicoTabelaCustas>(Lifestyle.Singleton);
            Container.Register<IServicoTabelaCustas, ServicoTabelaCustas>(Lifestyle.Singleton);
            Container.Register<IRepositorioTabelaCustas, RepositorioTabelaCustas>(Lifestyle.Singleton);

            Container.Verify();

        }
    }
}
