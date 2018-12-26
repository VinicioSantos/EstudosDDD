using System.Collections;
using System.Collections.Generic;

namespace ProjetoModeloDDD.Domain.Interfaces.Servicos
{
    public interface IServiceBase<TEntity> where TEntity : class
    {

        void add(TEntity obj);

        TEntity GetById(int id);

        IEnumerable<TEntity> GetAll();

        void Update(TEntity obj);

        void Remove(TEntity obj);

        void Dispose();


    }
}
