﻿using Cs_Notas.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioComplementos: IRepositorioBase<Complementos>
    {
        List<Complementos> ObterComplementosPorIdAto(int idAto);
    }
}