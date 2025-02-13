using AvaliacaoDotNet.Domain.Interfaces;
using AvaliacaoDotNet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoDotNet.Application.Services
{
    public class PessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaService(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public IEnumerable<Pessoa> GetAll() => _pessoaRepository.GetAll();

        public Pessoa GetByCpf(string cpf) => _pessoaRepository.GetByCpf(cpf);

        public void Add(Pessoa pessoa) => _pessoaRepository.Add(pessoa);

        public void Update(Pessoa pessoa) => _pessoaRepository.Update(pessoa);

        public void Delete(string cpf) => _pessoaRepository.Delete(cpf);
    }
}
