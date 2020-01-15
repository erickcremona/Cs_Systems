using Cs_Gerencial.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Gerencial.Aplicacao.Interfaces
{
    public interface IAppServicoIndisponibilidades: IAppServicoBase<Indisponibilidades>
    {
        IEnumerable<Indisponibilidades> LerArquivoXml(string caminho);

        IEnumerable<Indisponibilidades> ObterArquivosImportados(string arquivo);

        IEnumerable<Indisponibilidades> ObterIndisponibilidadesPorNome(string nome);

        IEnumerable<Indisponibilidades> ObterIndisponibilidadesCpfCnpj(string cpfCnpj);

        IEnumerable<Indisponibilidades> ObterIndisponibilidadesProtocolo(string protocolo);

        IEnumerable<Indisponibilidades> ObterIndisponibilidadesNumeroProcesso(string numeroProcesso);

        bool ValidarCpf(string validarCpf);

        bool ValidarCnpj(string validarCnpj);

        bool ValidarEmail(string validaEmail);
    
    }
}
