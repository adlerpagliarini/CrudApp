using Crud.App.Application.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Crud.App.Application.ViewModels
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel(){
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        private IEnumerable<string> _nomeCompleto;
        [MaxLength(150, ErrorMessage = "O tamanho máximo do nome completo é {1}")]
        [ValidacaoDeNomeCompleto(ErrorMessage = "O nome completo deve possuir pelo menos duas palavras")]
        [Display(Name = "Nome Completo")]
        public string Nome
        {
            get { return string.Join(" ", _nomeCompleto).Trim(); }
            set { _nomeCompleto = (value == null) ? "".Split(' ') : value.Split(' ').Where(i => !string.IsNullOrEmpty(i)); }
        }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "O E-mail é requerido")]
        [MaxLength(50, ErrorMessage = "O tamanho máximo do e-mailcompleto é {1}")]
        [EmailAddress(ErrorMessage = "E-mail no formato inválido")]
        public string Email { get; set; }

        [Display(Name = "Celular ou Telefone")]
        [Required(ErrorMessage = "O Telefone é requerido")]
        [MinLength(14, ErrorMessage = "O tamanho mínimo do telefone é 10")]
        [MaxLength(15, ErrorMessage = "O tamanho máximo do telefone é 11")]
        [ValidacaoNumeroTelefone]
        public string Telefone { get; set; }

        public string GetPrimeiroNome()
        {
            return _nomeCompleto.FirstOrDefault();
        }

        public string GetSegundoNome()
        {
            return _nomeCompleto.Count() >= 2 ? _nomeCompleto.ElementAt(1) : "";
        }

        public string GetUltimosNomes()
        {
            return string.Join(" ", _nomeCompleto.Select((str, index) => (index >= 2) ? str : "").ToList());
        }

        public string Getddd()
        {
            Telefone = Telefone.ApenasNumeros();
            return Telefone.Substring(0, Telefone.Length >= 2 ? 2 : Telefone.Length);
        }

        public string GetTelefone()
        {
            Telefone = Telefone.ApenasNumeros();
            var numeroRestantes = Telefone.Length - 2;
            return Telefone.Substring(Telefone.Length - numeroRestantes);
        }
    }
}

public class ValidacaoDeNomeCompleto : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var textValue = value.ToString();
        if (textValue.Split(' ').Length >= 2) return ValidationResult.Success;
        var errorMessage = FormatErrorMessage((validationContext.DisplayName));
        return new ValidationResult(errorMessage);
    }
}
public class ValidacaoNumeroTelefone : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var textValue = value.ToString().ApenasNumeros();
        if (textValue.Length >= 10 && textValue.Length <= 11) return ValidationResult.Success;
        var errorMessage = FormatErrorMessage((validationContext.DisplayName));
        return new ValidationResult(errorMessage);
    }
}
