﻿using Cs_IssPrefeitura.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_IssPrefeitura.Aplicacao.Interfaces
{
    public interface IAppServicoApuracaoIss: IAppServicoBase<ApuracaoIss>
    {
        List<ApuracaoIss> ObterListaApuracaoPorMesAno(int mes, int ano);

        List<ApuracaoIss> ObterListaApuracaoPorMes(int mes);

        List<ApuracaoIss> ObterListaApuracaoPorAno(int ano);

        int ObterUltimoNumero();

        int ObterUltimaSerie(int ano);
    }
}