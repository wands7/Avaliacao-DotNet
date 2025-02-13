using AvaliacaoDotNet.Domain.Entities;
using AvaliacaoDotNet.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AvaliacaoDotNet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private static readonly List<Pessoa> _pessoas = new();
        private static readonly List<Telefone> _telefones = new();

        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<Pessoa>> Get()
        {
            return Ok(_pessoas);
        }

        [Authorize]
        [HttpGet("{cpf}")]
        public ActionResult<Pessoa> GetByCpf(string cpf)
        {
            var pessoa = _pessoas.FirstOrDefault(p => p.CPF.Replace(".", "").Replace("-", "") == cpf);
            if (pessoa == null)
                return NotFound("Pessoa não encontrada.");

            return Ok(pessoa);
        }

        [Authorize]
        [HttpPost]
        public ActionResult<Pessoa> Create([FromBody] Pessoa pessoa)
        {

            if (_pessoas.Any(p => p.CPF.Replace(".", "").Replace("-", "") == pessoa.CPF))
                return BadRequest("Já existe uma pessoa com esse CPF.");

            pessoa.Id = _pessoas.Count + 1;
            _pessoas.Add(pessoa);

            return CreatedAtAction(nameof(GetByCpf), new { cpf = pessoa.CPF }, pessoa);
        }

        [Authorize]
        [HttpPut("{cpf}")]
        public ActionResult Update(string cpf, [FromBody] Pessoa pessoaAtualizada)
        {
            var pessoa = _pessoas.FirstOrDefault(p => p.CPF.Replace(".", "").Replace("-", "") == cpf);
            if (pessoa == null)
                return NotFound("Pessoa não encontrada.");

            pessoa.Nome = pessoaAtualizada.Nome;
            pessoa.DataNascimento = pessoaAtualizada.DataNascimento;
            pessoa.EstaAtivo = pessoaAtualizada.EstaAtivo;

            pessoa.Telefones = pessoaAtualizada.Telefones ?? new List<Telefone>();

            return Ok("Pessoa atualizada com sucesso!");
        }

        [Authorize]
        [HttpDelete("{cpf}")]
        public ActionResult Delete(string cpf)
        {
            var pessoa = _pessoas.FirstOrDefault(p => p.CPF.Replace(".", "").Replace("-", "")== cpf);
            if (pessoa == null)
                return NotFound("Pessoa não encontrada.");

            _pessoas.Remove(pessoa);
            return Ok("Pessoa deletada com sucesso!");
        }        
        
    }

}
