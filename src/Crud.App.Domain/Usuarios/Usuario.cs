using Crud.App.Domain.Core.Models;
using Crud.App.Domain.Usuarios.ValueObjects;
using FluentValidation;

namespace Crud.App.Domain.Usuarios
{
    public class Usuario : Entity<Usuario>
    {
        public Usuario(NomeCompleto nomeCompleto, string email, Telefone telefone)
        {
            NomeCompleto = nomeCompleto;
            Email = email;
            Telefone = telefone;
        }

        private Usuario(){}

        public NomeCompleto NomeCompleto { get; private set; }

        public Telefone Telefone { get; private set; }

        public string Email { get; private set; }

        public override bool IsValid()
        {
            Validar();
            return ValidationResult.IsValid;
        }
        #region Validation
        private void Validar()
        {
            ValidarNome();
            ValidarEmail();
            ValidarTelefone();
            ValidationResult = Validate(this);
        }

        private void ValidarNome()
        {
            RuleFor(c => c.NomeCompleto.PrimeiroNome)
                .NotEmpty().WithMessage("O primeiro nome deve ser fornecido")
                .Length(2, 50).WithMessage("O primeiro nome deve ter entre 2 e 50 caracteres");

            RuleFor(c => c.NomeCompleto.SegundoNome)
                .NotEmpty().WithMessage("O segundo nome deve ser fornecido")
                .Length(2, 50).WithMessage("O segundo nome deve ter entre 2 e 50 caracteres");
        }

        private void ValidarEmail()
        {
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("O e-mail deve ser fornecido")
                .EmailAddress().WithMessage("Informe um email válido");
        }

        private void ValidarTelefone()
        {
            RuleFor(c => c.Telefone.DDD)
                .NotEmpty().WithMessage("O código de área do país deve ser fornecido")
                .Matches(@"[0-9]{2}$").WithMessage("O código de área do país deve possuir 2 digitos");

            RuleFor(c => c.Telefone.Numero)
                .NotEmpty().WithMessage("O número do telefone deve ser fornecido")
                .Matches(@"([9]{1})?([0-9]{8})$").WithMessage("O telefone deve possuir entre 8 e 9 digitos");
        }
        #endregion Validation
    }
}
