using AvaliacaoDotNet.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoDotNet.Domain.Entities
{
    public class Telefone
    {
        public int Id { get; set; }

        [Required]
        public string Tipo { get; set; }

        [Required]
        public string Numero { get; set; }
    }
}
