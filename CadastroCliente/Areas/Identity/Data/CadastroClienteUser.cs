using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace CadastroCliente.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the CadastroClienteUser class
    public class CadastroClienteUser : IdentityUser
    {
        // Personal Data
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }

        // Main Area Fields
        [Required]
        [StringLength(150)]
        [Column(TypeName = "nvarchar(150)")]
        public string NomeClienteRazaoSocial { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(150)]
        [Column(TypeName = "nvarchar(150)")]
        public string Email { get; set; }

        [Required]
        [Phone]
        [StringLength(11)]
        [Column(TypeName = "nvarchar(11)")]
        public string Telefone { get; set; }

        public DateTime DataCadastro = DateTime.Now;

           
        // Information Area Fields
        [Required]
        public TipoPessoa TipoPessoa { get; set; }

        [Required(ErrorMessage = "The CPFCNPJ field is required.")]
        [StringLength(14, ErrorMessage = "The CPFCNPJ field must have at most {1} characters.")]
        [Column(TypeName = "nvarchar(14)")]
        public string CPFCNPJ { get; set; }

        [StringLength(12)]
        [Column(TypeName = "nvarchar(12)")]
        public string? InscricaoEstadual { get; set; }

        public Isento Isento { get; set; }

        // Fields for Pessoa Física
        public Genero? Genero { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DataNascimento { get; set; }

        // Situação do Cliente
        public bool Bloqueado { get; set; }
    }

    // Custom enum for TipoPessoa
    public enum TipoPessoa
    {
        Fisica,
        Juridica
    }

    // Custom enum for Genero
    public enum Genero
    {
        Feminino,
        Masculino,
        Outro
    }
    public enum Isento
    {
      True,
      False
    }  
    public enum Bloqueado
    {
      Sim,
      Nao
    }
}
