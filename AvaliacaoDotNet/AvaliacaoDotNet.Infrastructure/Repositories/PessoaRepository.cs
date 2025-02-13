using AvaliacaoDotNet.Domain.Interfaces;
using AvaliacaoDotNet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoDotNet.Infrastructure.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private static readonly List<Pessoa> _pessoas = new();

        public IEnumerable<Pessoa> GetAll() => _pessoas;

        public Pessoa GetByCpf(string cpf) => _pessoas.FirstOrDefault(p => p.CPF == cpf);

        public void Add(Pessoa pessoa) => _pessoas.Add(pessoa);

        public void Update(Pessoa pessoa)
        {
            var existente = GetByCpf(pessoa.CPF);
            if (existente != null)
            {
                existente.Nome = pessoa.Nome;
                existente.DataNascimento = pessoa.DataNascimento;
                existente.EstaAtivo = pessoa.EstaAtivo;
            }
        }

        public void Delete(string cpf)
        {
            var pessoa = GetByCpf(cpf);
            if (pessoa != null)
                _pessoas.Remove(pessoa);
        }
    }
}
