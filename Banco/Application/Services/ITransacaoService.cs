using Banco.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Banco.Application.Services
{
    public interface ITransacaoService
    {
        void Transferencia(Transacao transacao);
        IEnumerable<Transacao> GetAll();
        Transacao GetById(int id);
    }
}
