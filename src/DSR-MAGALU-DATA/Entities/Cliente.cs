namespace DSR_MAGALU_DATA.Entities
{
    public class Cliente : Entity
    {
        public string NomeClienteRazaoSocial { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public DateTime? DataCadastro { get; set; }
        public int TipoPessoa { get; set; }
        public string Documento { get; set; } = string.Empty;
        public string? InscricaoEstadual { get; set; }
        public bool Isento { get; set; }
        public int Genero { get; set; }
        public DateTime? DataNascimento { get; set; }
        public bool Bloqueado { get; set; }
        public string Senha { get; set; } = string.Empty;
    }
}
