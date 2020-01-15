using Cs_Gerencial.Aplicacao.Interfaces;
using Cs_Gerencial.Dominio.Entities;
using Cs_Gerencial.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Gerencial.Aplicacao.ServicosApp
{
    public class AppServicoIndisponibilidades: AppServicoBase<Indisponibilidades>, IAppServicoIndisponibilidades
    {
        private readonly IServicoIndisponibilidades _servicoIndisponibilidades;

        public AppServicoIndisponibilidades(IServicoIndisponibilidades servicoIndisponibilidades)
            : base(servicoIndisponibilidades)
        {
            _servicoIndisponibilidades = servicoIndisponibilidades;
        }

        public IEnumerable<Indisponibilidades> LerArquivoXml(string caminho)
        {
            return _servicoIndisponibilidades.LerArquivoXml(caminho);
        }


        public IEnumerable<Indisponibilidades> ObterArquivosImportados(string arquivo)
        {
            return _servicoIndisponibilidades.ObterArquivosImportados(arquivo);
        }


        public IEnumerable<Indisponibilidades> ObterIndisponibilidadesPorNome(string nome)
        {
            return _servicoIndisponibilidades.ObterIndisponibilidadesPorNome(nome);
        }

        public IEnumerable<Indisponibilidades> ObterIndisponibilidadesCpfCnpj(string cpfCnpj)
        {
            return _servicoIndisponibilidades.ObterIndisponibilidadesCpfCnpj(cpfCnpj);
        }

        public IEnumerable<Indisponibilidades> ObterIndisponibilidadesProtocolo(string protocolo)
        {
            return _servicoIndisponibilidades.ObterIndisponibilidadesProtocolo(protocolo);
        }

        public IEnumerable<Indisponibilidades> ObterIndisponibilidadesNumeroProcesso(string numeroProcesso)
        {
            return _servicoIndisponibilidades.ObterIndisponibilidadesNumeroProcesso(numeroProcesso);
        }


        public bool ValidarCpf(string validarCpf)
        {
            return _servicoIndisponibilidades.ValidarCpf(validarCpf);
        }


        public bool ValidarCnpj(string validarCnpj)
        {
            return _servicoIndisponibilidades.ValidarCnpj(validarCnpj);
        }


        public bool ValidarEmail(string validaEmail)
        {
            return _servicoIndisponibilidades.ValidarEmail(validaEmail);
        }
    }
}
