using AvaliacaoDotNet.Domain.Models;

namespace AvaliacaoDotNet.Domain.Interfaces
{
    public interface IPessoaRepository
    {
        IEnumerable<Pessoa> GetAll();
        Pessoa GetByCpf(string cpf);
        void Add(Pessoa pessoa);
        void Update(Pessoa pessoa);
        void Delete(string cpf);
    }
}
