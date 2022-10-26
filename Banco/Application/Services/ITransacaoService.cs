using Banco.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Banco.Application.Services
{
    public interface ITransacaoService
    {
        void Transacao(Transacao transacao);
        void Transferencia(Transacao transacao);
        void DepositoSaque(Transacao transacao);
        IEnumerable<Transacao> GetAll();
        Transacao GetById(int id);
        IEnumerable<Transacao> ExtractByConta(int contaId);
    }
}
