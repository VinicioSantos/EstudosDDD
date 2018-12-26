using ProjetoModeloDDD.Aplicacao.Interface;
using ProjetoModeloDDD.Domain.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Aplicacao
{
    public class ClienteAppService : AppServiceBase<Cliente>, IClienteAppService
    {
        private readonly IClienteService _clientService;

        public ClienteAppService(IClienteService clientService)
            : base(clientService)
        {
            _clientService = clientService;
        }

        public IEnumerable<Cliente> ObterClientesEspeciais()
        {
            return _clientService.ObterClientesEspeciais(_clientService.GetAll());
        }
    }
}
