using Cs_Gerencial.Aplicacao.Interfaces;
using Cs_Gerencial.Aplicacao.ServicosApp;
using Cs_Gerencial.Dominio.Interfaces;
using Cs_Gerencial.Dominio.Interfaces.Repositorios;
using Cs_Gerencial.Dominio.Interfaces.Servicos;
using Cs_Gerencial.Dominio.Servicos;
using Cs_Gerencial.Infra.Data.Repositorios;
using Cs_Notas.Aplicacao.Interfaces;
using Cs_Notas.Aplicacao.ServicosApp;
using Cs_Notas.Dominio.Interfaces.Repositorios;
using Cs_Notas.Dominio.Interfaces.Servicos;
using Cs_Notas.Dominio.Servicos;
using Cs_Notas.Infra.Data.Repositorios;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas
{
   public class BootStrap
    {
        public static Container Container;

        public static void Start()
        {
            Container = new Container();



            // Sistema Notas


            Container.Register(typeof(Cs_Notas.Aplicacao.Interfaces.IAppServicoBase<>), typeof(Cs_Notas.Aplicacao.ServicosApp.AppServicoBase<>), Lifestyle.Singleton);
            Container.Register(typeof(Cs_Notas.Dominio.Interfaces.Servicos.IServicoBase<>), typeof(Cs_Notas.Dominio.Servicos.ServicoBase<>), Lifestyle.Singleton);
            Container.Register(typeof(Cs_Notas.Dominio.Interfaces.Repositorios.IRepositorioBase<>), typeof(Cs_Notas.Infra.Data.Repositorios.RepositorioBase<>), Lifestyle.Singleton);
            
            Container.Register<Cs_Notas.Aplicacao.Interfaces.IAppServicoUsuario, Cs_Notas.Aplicacao.ServicosApp.AppServicoUsuario>(Lifestyle.Singleton);
            Container.Register<Cs_Notas.Dominio.Interfaces.Servicos.IServicoUsuario, Cs_Notas.Dominio.Servicos.ServicoUsuario>(Lifestyle.Singleton);
            Container.Register<Cs_Notas.Dominio.Interfaces.Repositorios.IRepositorioUsuario, Cs_Notas.Infra.Data.Repositorios.RepositorioUsuario>(Lifestyle.Singleton);

            Container.Register<Cs_Notas.Aplicacao.Interfaces.IAppServicoLogSistema, Cs_Notas.Aplicacao.ServicosApp.AppServicoLogSistema>(Lifestyle.Singleton);
            Container.Register<Cs_Notas.Dominio.Interfaces.Servicos.IServicoLogSistema, Cs_Notas.Dominio.Servicos.ServicoLogSistema>(Lifestyle.Singleton);
            Container.Register<Cs_Notas.Dominio.Interfaces.Repositorios.IRepositorioLogSistema, Cs_Notas.Infra.Data.Repositorios.RepositorioLogSistema>(Lifestyle.Singleton);

            Container.Register<IAppServicoConfiguracoes, AppServicoConfiguracoes>(Lifestyle.Singleton);
            Container.Register<IServicoConfiguracoes, ServicoConfiguracoes>(Lifestyle.Singleton);
            Container.Register<IRepositorioConfiguracoes, RepositorioConfiguracoes>(Lifestyle.Singleton);

            Container.Register<IAppServicoEscrituras, AppServicoEscrituras>(Lifestyle.Singleton);
            Container.Register<IServicoEscrituras, ServicoEscrituras>(Lifestyle.Singleton);
            Container.Register<IRepositorioEscrituras, RepositorioEscrituras>(Lifestyle.Singleton);

            Container.Register<IAppServicoNaturezas, AppServicoNaturezas>(Lifestyle.Singleton);
            Container.Register<IServicoNaturezas, ServicoNaturezas>(Lifestyle.Singleton);
            Container.Register<IRepositorioNaturezas, RepositorioNaturezas>(Lifestyle.Singleton);

            Container.Register<IAppServicoCensec, AppServicoCensec>(Lifestyle.Singleton);
            Container.Register<IServicoCensec, ServicoCensec>(Lifestyle.Singleton);
            Container.Register<IRepositorioCensec, RepositorioCensec>(Lifestyle.Singleton);

            Container.Register<IAppServicoNomes, AppServicoNomes>(Lifestyle.Singleton);
            Container.Register<IServicoNomes, ServicoNomes>(Lifestyle.Singleton);
            Container.Register<IRepositorioNomes, RepositorioNomes>(Lifestyle.Singleton);

            Container.Register<IAppServicoRegimes, AppServicoRegimes>(Lifestyle.Singleton);
            Container.Register<IServicoRegimes, ServicoRegimes>(Lifestyle.Singleton);
            Container.Register<IRepositorioRegimes, RepositorioRegimes>(Lifestyle.Singleton);

            Container.Register<IAppServicoImovel, AppServicoImovel>(Lifestyle.Singleton);
            Container.Register<IServicoImovel, ServicoImovel>(Lifestyle.Singleton);
            Container.Register<IRepositorioImovel, RepositorioImovel>(Lifestyle.Singleton);

            Container.Register<IAppServicoAtoConjuntos, AppServicoAtoConjuntos>(Lifestyle.Singleton);
            Container.Register<IServicoAtoConjuntos, ServicoAtoConjuntos>(Lifestyle.Singleton);
            Container.Register<IRepositorioAtoConjuntos, RepositorioAtoConjuntos>(Lifestyle.Singleton);

            Container.Register<IAppServicoBensAtosConjuntos, AppServicoBensAtosConjuntos>(Lifestyle.Singleton);
            Container.Register<IServicoBensAtosConjuntos, ServicoBensAtosConjuntos>(Lifestyle.Singleton);
            Container.Register<IRepositorioBensAtosConjuntos, RepositorioBensAtosConjuntos>(Lifestyle.Singleton);

            Container.Register<IAppServicoParteConjuntos, AppServicoParteConjuntos>(Lifestyle.Singleton);
            Container.Register<IServicoParteConjuntos, ServicoParteConjuntos>(Lifestyle.Singleton);
            Container.Register<IRepositorioParteConjuntos, RepositorioParteConjuntos>(Lifestyle.Singleton);

            Container.Register<IAppServicoTipoImovel, AppServicoTipoImovel>(Lifestyle.Singleton);
            Container.Register<IServicoTipoImovel, ServicoTipoImovel>(Lifestyle.Singleton);
            Container.Register<IRepositorioTipoImovel, RepositorioTipoImovel>(Lifestyle.Singleton);

            Container.Register<IAppServicoTransacaoDoi, AppServicoTransacaoDoi>(Lifestyle.Singleton);
            Container.Register<IServicoTransacaoDoi, ServicoTransacaoDoi>(Lifestyle.Singleton);
            Container.Register<IRepositorioTransacaoDoi, RepositorioTransacaoDoi>(Lifestyle.Singleton);

            Container.Register<IAppServicoProcuracaoEscritura, AppServicoProcuracaoEscritura>(Lifestyle.Singleton);
            Container.Register<IServicoProcuracaoEscritura, ServicoProcuracaoEscritura>(Lifestyle.Singleton);
            Container.Register<IRepositorioProcuracaoEscritura, RepositorioProcuracaoEscritura>(Lifestyle.Singleton);

            Container.Register<IAppServicoItensCustas, AppServicoItensCustas>(Lifestyle.Singleton);
            Container.Register<IServicoItensCustas, ServicoItensCustas>(Lifestyle.Singleton);
            Container.Register<IRepositorioItensCustas, RepositorioItensCustas>(Lifestyle.Singleton);

            Container.Register<IAppServicoComplementos, AppServicoComplementos>(Lifestyle.Singleton);
            Container.Register<IServicoComplementos, ServicoComplementos>(Lifestyle.Singleton);
            Container.Register<IRepositorioComplementos, RepositorioComplementos>(Lifestyle.Singleton);

            Container.Register<IAppServicoCadProcuracao, AppServicoCadProcuracao>(Lifestyle.Singleton);
            Container.Register<IServicoCadProcuracao, ServicoCadProcuracao>(Lifestyle.Singleton);
            Container.Register<IRepositorioCadProcuracao, RepositorioCadProcuracao>(Lifestyle.Singleton);

            Container.Register<IAppServicoTestamento, AppServicoTestamento>(Lifestyle.Singleton);
            Container.Register<IServicoTestamento, ServicoTestamento>(Lifestyle.Singleton);
            Container.Register<IRepositorioTestamento, RepositorioTestamento>(Lifestyle.Singleton);

            Container.Register<IAppServicoRevogados, AppServicoRevogados>(Lifestyle.Singleton);
            Container.Register<IServicoRevogados, ServicoRevogados>(Lifestyle.Singleton);
            Container.Register<IRepositorioRevogados, RepositorioRevogados>(Lifestyle.Singleton);


            // Sistema Gerencial

            Container.Register<IAppServicoBancos, AppServicoBancos>(Lifestyle.Singleton);
            Container.Register<IServicoBancos, ServicoBancos>(Lifestyle.Singleton);
            Container.Register<IRepositorioBancos, RepositorioBancos>(Lifestyle.Singleton);


            Container.Register(typeof(Cs_Gerencial.Aplicacao.Interfaces.IAppServicoBase<>), typeof(Cs_Gerencial.Aplicacao.ServicosApp.AppServicoBase<>), Lifestyle.Singleton);
            Container.Register(typeof(Cs_Gerencial.Dominio.Interfaces.Servicos.IServicoBase<>), typeof(Cs_Gerencial.Dominio.Servicos.ServicoBase<>), Lifestyle.Singleton);
            Container.Register(typeof(Cs_Gerencial.Dominio.Interfaces.IRepositorioBase<>), typeof(Cs_Gerencial.Infra.Data.Repositorios.RepositorioBase<>), Lifestyle.Singleton);


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


            Container.Register<Cs_Gerencial.Aplicacao.Interfaces.IAppServicoLogSistema, Cs_Gerencial.Aplicacao.ServicosApp.AppServicoLogSistema>(Lifestyle.Singleton);
            Container.Register<Cs_Gerencial.Dominio.Interfaces.Servicos.IServicoLogSistema, Cs_Gerencial.Dominio.Servicos.ServicoLogSistema>(Lifestyle.Singleton);
            Container.Register<Cs_Gerencial.Dominio.Interfaces.Repositorios.IRepositorioLogSistema, Cs_Gerencial.Infra.Data.Repositorios.RepositorioLogSistema>(Lifestyle.Singleton);


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
                        
            Container.Register<IAppServicoAtribuicoes, AppServicoAtribuicoes>(Lifestyle.Singleton);
            Container.Register<IServicoAtribuicoes, ServicoAtribuicoes>(Lifestyle.Singleton);
            Container.Register<IRepositorioAtribuicoes, RepositorioAtribuicoes>(Lifestyle.Singleton);

            Container.Register<IAppServicoParametros, AppServicoParametros>(Lifestyle.Singleton);
            Container.Register<IServicoParametros, ServicoParametros>(Lifestyle.Singleton);
            Container.Register<IRepositorioParametros, RepositorioParametros>(Lifestyle.Singleton);

            Container.Register<IAppServicoAdicional, AppServicoAdicional>(Lifestyle.Singleton);
            Container.Register<IServicoAdicional, ServicoAdicional>(Lifestyle.Singleton);
            Container.Register<IRepositorioAdicional, RepositorioAdicional>(Lifestyle.Singleton);

            Container.Register<IAppServicoPessoas, AppServicoPessoas>(Lifestyle.Singleton);
            Container.Register<IServicoPessoas, ServicoPessoas>(Lifestyle.Singleton);
            Container.Register<IRepositorioPessoas, RepositorioPessoas>(Lifestyle.Singleton);

            Container.Register<IAppServicoParticipantes, AppServicoParticipantes>(Lifestyle.Singleton);
            Container.Register<IServicoParticipantes, ServicoParticipantes>(Lifestyle.Singleton);
            Container.Register<IRepositorioParticipantes, RepositorioParticipantes>(Lifestyle.Singleton);

            Container.Register<IAppServicoTabelaCustas, AppServicoTabelaCustas>(Lifestyle.Singleton);
            Container.Register<IServicoTabelaCustas, ServicoTabelaCustas>(Lifestyle.Singleton);
            Container.Register<IRepositorioTabelaCustas, RepositorioTabelaCustas>(Lifestyle.Singleton);

            Container.Verify();

        }
    }
}
