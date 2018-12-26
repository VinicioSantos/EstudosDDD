using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Domain.Interfaces.Servicos
{
    public interface IClienteService : IServiceBase<Cliente>
    {

        IEnumerable<Cliente> ObterClientesEspeciais(IEnumerable<Cliente> cliente);



    }
}
