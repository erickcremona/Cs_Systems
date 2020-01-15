using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Notas.Dominio.ValuesObject
{
    public class EstadoCivil
    {
        public int Codigo { get; set; }

        public string Descricao { get; set; }

        public List<EstadoCivil> ObterListaEstadoCivil(bool sexo)
        {
            var ec = new EstadoCivil();

            var estadoCivil = new List<EstadoCivil>();


            if (sexo == true)
            {
                ec.Codigo = 1;
                ec.Descricao = "SOLTEIRO";
                estadoCivil.Add(ec);

                ec = new EstadoCivil();
                ec.Codigo = 2;
                ec.Descricao = "CASADO";
                estadoCivil.Add(ec);

                ec = new EstadoCivil();
                ec.Codigo = 3;
                ec.Descricao = "VIÚVO";
                estadoCivil.Add(ec);

                ec = new EstadoCivil();
                ec.Codigo = 4;
                ec.Descricao = "SEPARADO JUDICIALMENTE";
                estadoCivil.Add(ec);

                ec = new EstadoCivil();
                ec.Codigo = 5;
                ec.Descricao = "DIVORCIADO";
                estadoCivil.Add(ec);

                ec = new EstadoCivil();
                ec.Codigo = 6;
                ec.Descricao = "SEPARADO CONSENSUALMENTE";
                estadoCivil.Add(ec);

                ec = new EstadoCivil();
                ec.Codigo = 7;
                ec.Descricao = "DESQUITADO";
                estadoCivil.Add(ec);

                ec = new EstadoCivil();
                ec.Codigo = 8;
                ec.Descricao = "IGNORADO";
                estadoCivil.Add(ec);
            }
            if (sexo == false)
            {

                ec.Codigo = 1;
                ec.Descricao = "SOLTEIRA";
                estadoCivil.Add(ec);

                ec = new EstadoCivil();
                ec.Codigo = 2;
                ec.Descricao = "CASADA";
                estadoCivil.Add(ec);

                ec = new EstadoCivil();
                ec.Codigo = 3;
                ec.Descricao = "VIÚVA";
                estadoCivil.Add(ec);

                ec = new EstadoCivil();
                ec.Codigo = 4;
                ec.Descricao = "SEPARADA JUDICIALMENTE";
                estadoCivil.Add(ec);

                ec = new EstadoCivil();
                ec.Codigo = 5;
                ec.Descricao = "DIVORCIADA";
                estadoCivil.Add(ec);

                ec = new EstadoCivil();
                ec.Codigo = 6;
                ec.Descricao = "SEPARADA CONSENSUALMENTE";
                estadoCivil.Add(ec);

                ec = new EstadoCivil();
                ec.Codigo = 7;
                ec.Descricao = "DESQUITADA";
                estadoCivil.Add(ec);

                ec = new EstadoCivil();
                ec.Codigo = 8;
                ec.Descricao = "IGNORADO";
                estadoCivil.Add(ec);
            }

            return estadoCivil;
        }

    }

    
}
