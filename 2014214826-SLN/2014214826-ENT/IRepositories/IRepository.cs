using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _2014214826_ENT.IRepositories
{
    public interface IRepository<TEntity> where TEntity:class
    {
        //CREATES
        //agrega un registro al repositorio (SQL Server) a la tabla TEntity
        void Add(TEntity entity);
        //agrega un grupo de registros al repositorio (SQL Server) a la tabla TEntity
        void AddRange(IEnumerable<TEntity> entities);

        //READS
        //Obtiene el registro con Primary Key = Id de la tabla TEntity
        TEntity Get(int Id);
        //Obtiene todos los registros de la tabla TEntity
        IEnumerable<TEntity> GetAll();
        //Obtiene todos los registros de la tabla TEntity que cumplan con la condicion predicate
        IEnumerator<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        //UPDATES
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entity);
        //DELETES
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entity);
    }
}
