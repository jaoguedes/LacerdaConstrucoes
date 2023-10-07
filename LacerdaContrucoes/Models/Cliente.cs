namespace LacerdaContrucoes.Models
{
    public class Cliente
    {
        public Guid ClienteId { get; set; }
        public string ClienteNome { get; set; }
        public int ClienteTelefone { get; set; }
        public int ClienteCpf { get; set; }
        public string ClienteEmail { get; set; }
        public DateTime ClienteDataDeNascimento { get; set; }


    }
}
