using Banco.Models;

namespace Banco.Application.Services
{
    public interface ITransacaoService
    {
        void Transferencia(Transacao transacao);
    }
}
