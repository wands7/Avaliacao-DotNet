using System;
using System.ComponentModel.DataAnnotations;

public class Pessoa
{
    [Required]
    [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
    public string Nome { get; set; }

    [Required]
    public string CPF { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime DataNascimento { get; set; }

    public bool EstaAtivo { get; set; }

    public string CPFSemPontuacao
    {
        get
        {
            return CPF?.Replace(".", "").Replace("-", "");
        }
    }
}