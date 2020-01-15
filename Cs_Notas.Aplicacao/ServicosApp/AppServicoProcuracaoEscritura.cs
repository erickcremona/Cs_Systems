using Cs_Notas.Aplicacao.Interfaces;
using Cs_Notas.Dominio.Entities;
using Cs_Notas.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Aplicacao.ServicosApp
{
    public class AppServicoProcuracaoEscritura: AppServicoBase<ProcuracaoEscritura>, IAppServicoProcuracaoEscritura
    {
        private readonly IServicoProcuracaoEscritura _servicoProcuracaoEscritura;
        public AppServicoProcuracaoEscritura(IServicoProcuracaoEscritura servicoProcuracaoEscritura)
            : base(servicoProcuracaoEscritura)
        {
            _servicoProcuracaoEscritura = servicoProcuracaoEscritura;
        }

        public List<ProcuracaoEscritura> ObterProcuracoesPorIdAto(int idAto)
        {
            return _servicoProcuracaoEscritura.ObterProcuracoesPorIdAto(idAto);
        }


        public ProcuracaoEscritura ObterUmObjetoProcuracao(DateTime data, string serventia, string livro, string folhas, string ato, string outorgantes, string outorgados, string selo, string aleatorio, bool rbsim, bool rbnao, out string mensagem)
        {
            ProcuracaoEscritura procuracao = new ProcuracaoEscritura();

            procuracao.Data = data;

             mensagem = "objeto ok";

            if (serventia.Length > 150)
                procuracao.Serventia = serventia.Substring(0, 149).Trim();
            else
                procuracao.Serventia = serventia.Trim();

            if (livro.Length > 20)
                procuracao.Livro = livro.Substring(0, 19).Trim();
            else
                procuracao.Livro = livro.Trim();

            if (folhas.Length > 10)
                procuracao.Folhas = folhas.Substring(0, 9).Trim();
            else
                procuracao.Folhas = folhas.Trim();

            if (ato.Length > 10)
                procuracao.Ato = ato.Substring(0, 9).Trim();
            else
                procuracao.Ato = ato.Trim();

            if (selo.Length > 9)
                procuracao.Selo = selo.Substring(0, 9).Trim();
            else
                procuracao.Selo = selo.Trim();

            if (aleatorio.Length > 3)
                procuracao.Aleatorio = aleatorio.Substring(0, 2).Trim();
            else
                procuracao.Aleatorio = aleatorio.Trim();

            if (outorgantes.Length > 600)
                procuracao.Outorgantes = outorgantes.Substring(0, 599).Trim();
            else
                procuracao.Outorgantes = outorgantes.Trim();

            if (outorgados.Length > 600)
                procuracao.Outorgados = outorgados.Substring(0, 599).Trim();
            else
                procuracao.Outorgados = outorgados.Trim();

            if (rbsim == true)
                procuracao.Lavrado = "S";
            else
                procuracao.Lavrado = "N";


            if (procuracao.Data == null || procuracao.Serventia == "" || procuracao.Livro == "" || procuracao.Folhas == "" || procuracao.Ato == "" || procuracao.Outorgantes == "" || procuracao.Outorgados == "")
            {
                mensagem = "É necessário preencher o(s) seguinte(s) campo(s): \n\n";

                if (procuracao.Data == new DateTime())
                    mensagem = mensagem + "- Data \n";

                if (procuracao.Serventia == "")
                    mensagem = mensagem + "- Serventia \n";

                if (procuracao.Livro == "")
                    mensagem = mensagem + "- Livro \n";

                if (procuracao.Folhas == "")
                    mensagem = mensagem + "- Folhas \n";

                if (procuracao.Ato == "")
                    mensagem = mensagem + "- Ato \n";

                if (procuracao.Outorgantes == "")
                    mensagem = mensagem + "- Outorgantes \n";

                if (procuracao.Outorgados == "")
                    mensagem = mensagem + "- Outorgados \n";
            }
            else
                mensagem = "ok";


            return procuracao;
        }
    }
}
