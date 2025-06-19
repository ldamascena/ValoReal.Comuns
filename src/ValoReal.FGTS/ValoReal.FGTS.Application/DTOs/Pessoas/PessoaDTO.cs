using System;
using System.Security;

namespace ValoReal.FGTS.Application.DTOs.Pessoas;

public class PessoaDTO
{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Rg { get; set; }
    public string NomeMae { get; set; }
    public string Email { get; set; }
    public string Celular { get; set; }
    public string Cep { get; set; }
    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public string Complemento { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Uf { get; set; }
    public string Banco { get; set; } 
}
