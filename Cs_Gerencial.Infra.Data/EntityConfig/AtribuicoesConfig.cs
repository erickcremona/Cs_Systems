using Cs_Gerencial.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Gerencial.Infra.Data.EntityConfig
{
    public class AtribuicoesConfig: EntityTypeConfiguration<Atribuicoes>
    {
        public AtribuicoesConfig()
        {
            HasKey(p => p.AtribuicaoId);

            Property(p => p.Descricao)
                .HasMaxLength(40);
        }
    }
}
