using Cs_Gerencial.Dominio.Entities;
using Cs_Gerencial.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossCutting;


namespace Cs_Gerencial.Infra.Data.Repositorios
{
    public class RepositorioIndisponibilidades: RepositorioBase<Indisponibilidades>, IRepositorioIndisponibilidades
    {

        public IEnumerable<Indisponibilidades> ObterArquivosImportados(string arquivo)
        {
            return Db.Set<Indisponibilidades>().Where(p => p.Origem == arquivo);
        }

        public IEnumerable<Indisponibilidades> ObterIndisponibilidadesPorNome(string nome)
        {
            return Db.Set<Indisponibilidades>().Where(p => p.NomeIndividuo.Contains(nome)).ToList();
        }

        public IEnumerable<Indisponibilidades> ObterIndisponibilidadesCpfCnpj(string cpfCnpj)
        {
            return Db.Set<Indisponibilidades>().Where(p => p.CpfCnpj.Contains(cpfCnpj)).ToList();
        }

        public IEnumerable<Indisponibilidades> ObterIndisponibilidadesProtocolo(string protocolo)
        {
            return Db.Set<Indisponibilidades>().Where(p => p.Protocolo.Contains(protocolo)).ToList();
        }

        public IEnumerable<Indisponibilidades> ObterIndisponibilidadesNumeroProcesso(string numeroProcesso)
        {
            return Db.Set<Indisponibilidades>().Where(p => p.NumeroProcesso.Contains(numeroProcesso)).ToList();
        }


        public bool ValidarCpf(string validarCpf)
        {
            return ValidaCpfCnpj.ValidaCPF(validarCpf);
        }


        public bool ValidarCnpj(string validarCnpj)
        {
            return ValidaCpfCnpj.ValidaCNPJ(validarCnpj);
        }


        public bool ValidarEmail(string validarEmail)
        {
            return ValidaCpfCnpj.ValidaEmail(validarEmail);
        }
    }
}
