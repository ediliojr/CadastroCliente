using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CadastroCliente.Models
{
    public class Comprador
    {
        public int Id { get; set; }
        [Required]
        public string? Nome { get; set; }
        [Required]
        [Remote(action: "IsEmailUnique", controller: "Compradores", ErrorMessage = "Email already exists.")]

        public string? Email { get; set; }
        [Required]
        [Remote(action: "IsCpfUnique", controller: "Compradores", ErrorMessage = "Cpf already exists.")]
        public string? Cpf { get; set; }
        [Required]
        public string? Telefone { get; set; }
        [Required]
        public DateTime DataCadastro { get; set; }
        [Required]
        public bool ClienteBloqueado { get; set; }
    }
}
