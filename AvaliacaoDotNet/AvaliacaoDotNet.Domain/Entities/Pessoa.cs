using AvaliacaoDotNet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoDotNet.Domain.Models
{
    public class Pessoa
    {
        public int Id { get; set; } 

        [Required]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required]
        public string CPF { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        public bool EstaAtivo { get; set; }

        public List<Telefone> Telefones { get; set; } = new();

    }
}
