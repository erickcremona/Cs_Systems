using Cs_Gerencial.Aplicacao.Interfaces;
using Cs_Gerencial.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_Gerencial.Aplicacao.ServicosApp
{
    public class AppServicoBase<TEntity>: IDisposable, IAppServicoBase<TEntity> where TEntity : class
    {
        private readonly IServicoBase<TEntity> _servicoBase;

        public AppServicoBase(IServicoBase<TEntity> servicoBase)
        {
            _servicoBase = servicoBase;
        }


        public void Add(TEntity obj)
        {
            _servicoBase.Add(obj);
        }

        public TEntity GetById(int id)
        {
            return _servicoBase.GetById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _servicoBase.GetAll();
        }

        public void Update(TEntity obj)
        {
            _servicoBase.Update(obj);
        }

        public void Remove(TEntity obj)
        {
            _servicoBase.Remove(obj);
        }

        public void Dispose()
        {
            _servicoBase.Dispose();
        }
    }
}
