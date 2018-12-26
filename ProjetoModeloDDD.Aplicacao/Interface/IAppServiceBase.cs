using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Aplicacao.Interface
{
    public interface IAppServiceBase<TEntity> where TEntity : class
    {

        void add(TEntity obj);

        TEntity GetById(int id);

        IEnumerable<TEntity> GetAll();

        void Update(TEntity obj);

        void Remove(TEntity obj);

        void Dispose();


    }
}
