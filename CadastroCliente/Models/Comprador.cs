namespace CadastroCliente.Models
{
    public class Comprador
    {
        public int Id { get; set; } 
        public string? Nome { get; set; } 
        public string? Email { get; set; }
        public string? Cpf { get; set; } 
        public string? Telefone { get; set; }
        public DateTime DataCadastro = DateTime.Now;
        public bool ClienteBloqueado { get; set; }
    }
}
