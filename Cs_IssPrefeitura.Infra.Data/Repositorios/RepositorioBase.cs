using Cs_IssPrefeitura.Dominio.Interfaces.Repositorios;
using Cs_IssPrefeitura.Infra.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cs_IssPrefeitura.Infra.Data.Repositorios
{
    public class RepositorioBase<TEntity> : IDisposable, IRepositorioBase<TEntity> where TEntity : class
    {

        protected Context Db = new Context();

        /// <summary>
        /// Adiciona um objeto de determida entidade do tipo TEntity
        /// </summary>
        /// <param name="obj"> Recebe o objeto para ser adicionado</param>
        public void Add(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
            Db.SaveChanges();
        }

        /// <summary>
        /// Consulta uma determinada entidade passando o id
        /// </summary>
        /// <param name="id"> Recebe como parâmetro o id </param>
        /// <returns>Retorna um objeto do tipo TEntity</returns>
        public TEntity GetById(int id)
        {
            Db = new Context();
            return Db.Set<TEntity>().Find(id);
        }

        /// <summary>
        /// Consulta uma determinda entidade e trás todos os registros
        /// </summary>
        /// <returns>Retorna uma lista do tipo TEntity</returns>
        public IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        /// <summary>
        /// Modifica um registro já existente
        /// </summary>
        /// <param name="obj"></param>
        public void Update(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();
        }

        /// <summary>
        /// Remove um registro da entidade
        /// </summary>
        /// <param name="obj">Recebe como parâmetro um objeto do tipo TEntity</param>
        public void Remove(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
