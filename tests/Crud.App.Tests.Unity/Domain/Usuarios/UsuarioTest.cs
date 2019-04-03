using Crud.App.Domain.Usuarios;
using Crud.App.Domain.Usuarios.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Crud.App.Tests.Unity.Domain.Usuarios
{
    [TestClass]
    public class UsuarioTest
    {
        [TestMethod]
        public void VerificarValidacaoDeNomeCompleto_PrimeiroNome_DeveRetornarDoisEventosDeErro()
        {
            var nomeCompleto = new NomeCompleto("", "", "");
            var telefone = new Telefone("", "");
            var usuario = new Usuario(nomeCompleto, "", telefone);

            usuario.IsValid();

            var erros = usuario.ValidationResult.Errors.Where(e => 
                e.PropertyName == $"{nameof(NomeCompleto)}.{nameof(NomeCompleto.PrimeiroNome)}"
            );

            var requerido = erros.Where(erro => erro.ErrorMessage == "O primeiro nome deve ser fornecido");
            var tamanho = erros.Where(erro => erro.ErrorMessage == "O primeiro nome deve ter entre 2 e 50 caracteres");

            Assert.IsTrue(requerido.Count() == 1);
            Assert.IsTrue(tamanho.Count() == 1);
        }

        [TestMethod]
        public void VerificarValidacaoDeNomeCompleto_PrimeiroNome_NaoDeveRetornarEventoDeErro()
        {
            var nomeCompleto = new NomeCompleto("PrimeiroNome", "", "");
            var telefone = new Telefone("", "");
            var usuario = new Usuario(nomeCompleto, "", telefone);

            usuario.IsValid();

            var erros = usuario.ValidationResult.Errors.Where(e =>
                e.PropertyName == $"{nameof(NomeCompleto)}.{nameof(NomeCompleto.PrimeiroNome)}"
            );

            Assert.IsFalse(erros.Any());
        }

        [TestMethod]
        public void VerificarValidacaoDeNomeCompleto_SegundoNome_DeveRetornarDoisEventosDeErro()
        {
            var nomeCompleto = new NomeCompleto("", "", "");
            var telefone = new Telefone("", "");
            var usuario = new Usuario(nomeCompleto, "", telefone);

            usuario.IsValid();

            var erros = usuario.ValidationResult.Errors.Where(e =>
                e.PropertyName == $"{nameof(NomeCompleto)}.{nameof(NomeCompleto.SegundoNome)}"
            );

            var requerido = erros.Where(erro => erro.ErrorMessage == "O segundo nome deve ser fornecido");
            var tamanho = erros.Where(erro => erro.ErrorMessage == "O segundo nome deve ter entre 2 e 50 caracteres");

            Assert.IsTrue(requerido.Count() == 1);
            Assert.IsTrue(tamanho.Count() == 1);
        }

        [TestMethod]
        public void VerificarValidacaoDeNomeCompleto_SegundoNome_NaoDeveRetornarEventoDeErro()
        {
            var nomeCompleto = new NomeCompleto("", "SegundoNome", "");
            var telefone = new Telefone("", "");
            var usuario = new Usuario(nomeCompleto, "", telefone);

            usuario.IsValid();

            var erros = usuario.ValidationResult.Errors.Where(e =>
                e.PropertyName == $"{nameof(NomeCompleto)}.{nameof(NomeCompleto.SegundoNome)}"
            );

            Assert.IsFalse(erros.Any());
        }

        [TestMethod]
        public void VerificarValidacaoDeNomeCompleto_UltimoNome_NaoDeveRetornarEventoDeErro()
        {
            var nomeCompleto = new NomeCompleto("", "", "");
            var telefone = new Telefone("", "");
            var usuario = new Usuario(nomeCompleto, "", telefone);

            usuario.IsValid();

            var erros = usuario.ValidationResult.Errors.Where(e =>
                e.PropertyName == $"{nameof(NomeCompleto)}.{nameof(NomeCompleto.UltimoNome)}"
            );

            Assert.IsFalse(erros.Any());
        }


        [TestMethod]
        public void VerificarValidacaoDeEmail_DeveRetornarDoisEventosDeErro()
        {
            var nomeCompleto = new NomeCompleto("", "", "");
            var telefone = new Telefone("", "");
            var usuario = new Usuario(nomeCompleto, "", telefone);

            usuario.IsValid();

            var erros = usuario.ValidationResult.Errors.Where(e =>
                e.PropertyName == nameof(Usuario.Email)
            );

            var requerido = erros.Where(erro => erro.ErrorMessage == "O e-mail deve ser fornecido");
            var validadeDoCampo = erros.Where(erro => erro.ErrorMessage == "Informe um email válido");

            Assert.IsTrue(requerido.Count() == 1);
            Assert.IsTrue(validadeDoCampo.Count() == 1);
        }

        [TestMethod]
        public void VerificarValidacaoDeEmail_NaoDeveRetornarEventoDeErro()
        {
            var nomeCompleto = new NomeCompleto("", "", "");
            var telefone = new Telefone("", "");
            var usuario = new Usuario(nomeCompleto, "teste@teste.com", telefone);

            usuario.IsValid();

            var erros = usuario.ValidationResult.Errors.Where(e =>
                e.PropertyName == nameof(Usuario.Email)
            );

            Assert.IsFalse(erros.Any());
        }

        [TestMethod]
        public void VerificarValidacaoDeTelefone_DDD_DeveRetornarDoisEventosDeErro()
        {
            var nomeCompleto = new NomeCompleto("", "", "");
            var telefone = new Telefone("", "");
            var usuario = new Usuario(nomeCompleto, "", telefone);

            usuario.IsValid();

            var erros = usuario.ValidationResult.Errors.Where(e =>
                e.PropertyName == $"{nameof(Telefone)}.{nameof(Telefone.DDD)}"
            );

            var requerido = erros.Where(erro => erro.ErrorMessage == "O código de área do país deve ser fornecido");
            var tamanho = erros.Where(erro => erro.ErrorMessage == "O código de área do país deve possuir 2 digitos");

            Assert.IsTrue(requerido.Count() == 1);
            Assert.IsTrue(tamanho.Count() == 1);
        }

        [TestMethod]
        public void VerificarValidacaoDeTelefone_DDD_NaoDeveRetornarEventoDeErro()
        {
            var nomeCompleto = new NomeCompleto("", "", "");
            var telefone = new Telefone("15", "");
            var usuario = new Usuario(nomeCompleto, "", telefone);

            usuario.IsValid();

            var erros = usuario.ValidationResult.Errors.Where(e =>
                e.PropertyName == $"{nameof(Telefone)}.{nameof(Telefone.DDD)}"
            );

            Assert.IsFalse(erros.Any());
        }

        [TestMethod]
        public void VerificarValidacaoDeTelefone_Numero_DeveRetornarDoisEventosDeErro()
        {
            var nomeCompleto = new NomeCompleto("", "", "");
            var telefone = new Telefone("", "");
            var usuario = new Usuario(nomeCompleto, "", telefone);

            usuario.IsValid();

            var erros = usuario.ValidationResult.Errors.Where(e =>
                e.PropertyName == $"{nameof(Telefone)}.{nameof(Telefone.Numero)}"
            );

            var requerido = erros.Where(erro => erro.ErrorMessage == "O número do telefone deve ser fornecido");
            var tamanho = erros.Where(erro => erro.ErrorMessage == "O telefone deve possuir entre 8 e 9 digitos");

            Assert.IsTrue(requerido.Count() == 1);
            Assert.IsTrue(tamanho.Count() == 1);
        }

        [TestMethod]
        public void VerificarValidacaoDeTelefone_Numero_DeveRetornarUmEventoDeErro()
        {
            var nomeCompleto = new NomeCompleto("", "", "");
            var telefone = new Telefone("", "1234abcd");
            var usuario = new Usuario(nomeCompleto, "", telefone);

            usuario.IsValid();

            var erros = usuario.ValidationResult.Errors.Where(e =>
                e.PropertyName == $"{nameof(Telefone)}.{nameof(Telefone.Numero)}"
            );

            var formato = erros.Where(erro => erro.ErrorMessage == "O telefone deve possuir entre 8 e 9 digitos");

            Assert.IsTrue(formato.Count() == 1);
        }

        [TestMethod]
        public void VerificarValidacaoDeTelefone_Numero_8_Digitos_NaoDeveRetornarEventoDeErro()
        {
            var nomeCompleto = new NomeCompleto("", "", "");
            var telefone = new Telefone("", "12345678");
            var usuario = new Usuario(nomeCompleto, "", telefone);

            usuario.IsValid();

            var erros = usuario.ValidationResult.Errors.Where(e =>
                e.PropertyName == $"{nameof(Telefone)}.{nameof(Telefone.Numero)}"
            );

            Assert.IsFalse(erros.Any());
        }

        [TestMethod]
        public void VerificarValidacaoDeTelefone_Numero_9_Digitos_NaoDeveRetornarEventoDeErro()
        {
            var nomeCompleto = new NomeCompleto("", "", "");
            var telefone = new Telefone("", "123456789");
            var usuario = new Usuario(nomeCompleto, "", telefone);

            usuario.IsValid();

            var erros = usuario.ValidationResult.Errors.Where(e =>
                e.PropertyName == $"{nameof(Telefone)}.{nameof(Telefone.Numero)}"
            );

            Assert.IsFalse(erros.Any());
        }
    }
}
