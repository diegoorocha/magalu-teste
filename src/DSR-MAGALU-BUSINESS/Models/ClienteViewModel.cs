using System.ComponentModel.DataAnnotations;
using X.PagedList;
using static DSR_MAGALU_DATA.Enums.EnumHelpers;

namespace DSR_MAGALU_BUSINESS.Models
{
    public class ClienteViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string NomeClienteRazaoSocial { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public DateTime? DataCadastro { get; set; }
        public TipoPessoa TipoPessoa { get; set; }
        public string Documento { get; set; } = string.Empty;
        public string? InscricaoEstadual { get; set; } = string.Empty;
        public Genero Genero { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Senha { get; set; } = string.Empty;
        public string ConfirmaSenha { get; set; } = string.Empty;
        public bool Isento { get; set; }
        public bool Bloqueado { get; set; } = false;
        public bool Selecionado { get; set; }

        public IPagedList<ClienteViewModel?> Lista { get; set; }
    }
}