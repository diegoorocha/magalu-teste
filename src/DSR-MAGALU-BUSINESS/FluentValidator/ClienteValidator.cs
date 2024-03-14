using DSR_MAGALU_BUSINESS.Helpers;
using DSR_MAGALU_BUSINESS.Models;
using FluentValidation;

namespace DSR_MAGALU_BUSINESS.FluentValidator
{
    public sealed class ClienteValidator : AbstractValidator<ClienteViewModel>
    {
        public ClienteValidator()
        {
            RuleSet("AdicionarCliente", () =>
            {
                RuleFor(x => x.NomeClienteRazaoSocial)
                    .NotEmpty()
                    .WithMessage("Necessário informar o 'Nome / Razão Social' !")
                    .Length(3, 150)
                    .WithMessage("O campo 'Nome / Razão Social' deve ter entre 3 e 150 caracteres !");

                RuleFor(x => x.Email)
                    .NotEmpty()
                    .WithMessage("Necessário informar o 'e-mail' !")
                    .Length(3, 150)
                    .WithMessage("O campo 'e-mail' deve ter entre 3 e 150 caracteres !")
                    .EmailAddress()
                    .WithMessage("O 'e-mail' informado é invalido !");

                RuleFor(x => x.Telefone)
                    .NotEmpty()
                    .WithMessage("Necessário informar o 'telefone' !")
                    .Length(11)
                    .WithMessage("O campo 'telefone' deve ter 11 caracteres !");

                RuleFor(x => x.TipoPessoa)
                    .NotEmpty()
                    .IsInEnum()
                    .WithMessage("Necessário informar o 'Tipo Pessoa (Fisica ou Juridica)' !");

                RuleFor(x => x.Documento)
                    .NotEmpty()
                    .WithMessage("Necessário informar o tipo de documento 'CPF ou CNPJ' !")
                    .Must(DocumentoCpfCnpjValido)
                    .WithMessage("O documento informado 'CPF ou CNPJ' não é valido !");

                RuleFor(x => x.InscricaoEstadual)
                    .NotEmpty()
                    .Length(12)
                    .WithMessage("O campo 'inscrição estadual' deve ter 12 caracteres !");

                RuleFor(x => x.Genero)
                    .NotEmpty()
                    .IsInEnum()
                    .WithMessage("Necessário informar o 'genero' !");

                RuleFor(x => x.DataNascimento)
                    .NotEmpty()
                    .WithMessage("Necessário informar a 'data de nascimento' !");

                RuleFor(x => x.DataNascimento)
                    .NotEmpty()
                    .WithMessage("Necessário informar a 'data de nascimento' !");

                RuleFor(x => x.Senha)
                    .NotEmpty()
                    .WithMessage("Necessário informar a 'senha' !")
                    .Length(8,15)
                    .WithMessage("A senha deve ter no minimo 8, e máximo 12 caracteres !");

                RuleFor(x => x)
                    .Must(x => CompararSenhasIguais(x.Senha, x.ConfirmaSenha))
                    .WithMessage("As senhas não são iguais, tente novamente !");
            });

            RuleSet("EditarCliente", () =>
            {
                RuleFor(x => x.NomeClienteRazaoSocial)
                    .NotEmpty()
                    .WithMessage("Não é possível apagar as informações da Razão Social / Nome Cliente !")
                    .Length(3, 150)
                    .WithMessage("O campo 'Nome / Razão Social' deve ter entre 3 e 150 caracteres !");

                RuleFor(x => x.Email)
                    .NotEmpty()
                    .WithMessage("Não é possível apagar as informações do e-mail !")
                    .Length(3, 150)
                    .WithMessage("O campo 'e-mail' deve ter entre 3 e 150 caracteres !")
                    .EmailAddress()
                    .WithMessage("O 'e-mail' informado é invalido !");

                RuleFor(x => x.Telefone)
                    .NotEmpty()
                    .WithMessage("Não é possível apagar as informações do telefone !")
                    .Length(11)
                    .WithMessage("O campo 'telefone' deve ter 11 caracteres !");

                RuleFor(x => x.TipoPessoa)
                    .NotEmpty()
                    .WithMessage("Não é possível apagar as informações do 'Tipo Pessoa (Fisica ou Juridica)' !");

                RuleFor(x => x.Documento)
                    .NotEmpty()
                    .WithMessage("Não é possível apagar as informações do documento 'CPF ou CNPJ' !")
                    .Must(DocumentoCpfCnpjValido)
                    .WithMessage("O documento informado 'CPF ou CNPJ' não é valido !");

                RuleFor(x => x.InscricaoEstadual)
                    .NotEmpty()
                    .Length(12)
                    .WithMessage("O campo 'inscrição estadual' deve ter 12 caracteres !");

                RuleFor(x => x.Genero)
                    .NotEmpty()
                    .WithMessage("Necessário informar o 'genero' !");

                RuleFor(x => x.DataNascimento)
                    .NotEmpty()
                    .WithMessage("Não é possível apagar as informações da 'data de nascimento' !");

                RuleFor(x => x.DataNascimento)
                    .NotEmpty()
                    .WithMessage("Não é possível apagar as informações da 'data de nascimento' !");

                RuleFor(x => x.Senha)
                    .NotEmpty()
                    .WithMessage("Necessário informar a 'senha' !")
                    .Length(8, 15)
                    .WithMessage("A senha deve ter no minimo 8, e máximo 12 caracteres !");

                RuleFor(x => x)
                    .Must(x => CompararSenhasIguais(x.Senha, x.ConfirmaSenha))
                    .WithMessage("As senhas não são iguais, tente novamente !");
            });
        }
        private static bool DocumentoCpfCnpjValido(string cpfCnpj)
        {
            return DocumentoHelpers.ValidarDocumentoCpfCnpj(cpfCnpj);
        }

        private static bool CompararSenhasIguais(string senha, string confirmacaoSenha)
        {
            return senha.Equals(confirmacaoSenha);
        }
    }
}
