using Crud.App.Domain.Core.Commands;
using Crud.App.Domain.Core.Notifications;
using Crud.App.Domain.Interfaces;
using Crud.App.Domain.Usuarios;
using Crud.App.Domain.Usuarios.Service;
using Crud.App.Domain.Usuarios.ValueObjects;
using Crud.App.Infra.Data.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Crud.App.Tests.Unity.Domain.Usuarios.Service
{
    [TestClass]
    public class UsuarioServiceTest
    {
        private IUsuarioService _usuarioService;
        private IDomainNotification _domainNotification;
        private Mock<IUnitOfWork> _unitOfWork;
        private Mock<IUsuarioRepository> _usuarioRepository;

        [TestInitialize]
        public void SetUp()
        {

            _unitOfWork = new Mock<IUnitOfWork>();
            _usuarioRepository = new Mock<IUsuarioRepository>();
            _domainNotification = new DomainNotification();

            _usuarioService = new UsuarioService(_usuarioRepository.Object, _unitOfWork.Object, _domainNotification);

        }

        [TestMethod]
        public void NaoDeveRealizarCadastroDeUsuarioInvalido()
        {
            var nomeCompleto = new NomeCompleto("", "", "");
            var telefone = new Telefone("", "");
            var usuario = new Usuario(nomeCompleto, "", telefone);

            _usuarioService.RegistrarUsuario(usuario);

            Assert.IsFalse(_usuarioService.OperacaoValida());
        }

        [TestMethod]
        public void NaoDeveRealizarCadastroDeUsuarioComEmailJaCadastradoAnteriormente()
        {
            var nomeCompleto = new NomeCompleto("PrimeiroNome", "SegundoNome", "");
            var telefone = new Telefone("15", "987654321");
            var usuario = new Usuario(nomeCompleto, "email@duplicado.com", telefone);
            _usuarioRepository.Setup(m => m.ObterTodos(It.IsAny<Expression<Func<Usuario,bool>>>())).Returns(new List<Usuario>() { new Usuario(nomeCompleto, "email@duplicado.com", telefone) });

            _usuarioService.RegistrarUsuario(usuario);

            Assert.IsFalse(_usuarioService.OperacaoValida());
        }

        [TestMethod]
        public void RealizarCadastroDeUsuarioComSucesso()
        {
            var nomeCompleto = new NomeCompleto("PrimeiroNome", "SegundoNome", "");
            var telefone = new Telefone("15", "987654321");
            var usuario = new Usuario(nomeCompleto, "email@teste.com", telefone);
            _unitOfWork.Setup(m => m.Commit()).Returns(CommandResponse.OK);

            _usuarioService.RegistrarUsuario(usuario);

            Assert.IsTrue(_usuarioService.OperacaoValida());
        }

        [TestMethod]
        public void NaoDeveRealizarAtualizacaoDeUsuarioInvalido()
        {
            var nomeCompleto = new NomeCompleto("", "", "");
            var telefone = new Telefone("", "");
            var usuario = new Usuario(nomeCompleto, "", telefone);

            _usuarioService.AtualizarUsuario(usuario);

            Assert.IsFalse(_usuarioService.OperacaoValida());
        }

        [TestMethod]
        public void NaoDeveRealizarAtualizacaoDeUsuarioComEmailJaCadastradoAnteriormente()
        {
            var nomeCompleto = new NomeCompleto("PrimeiroNome", "SegundoNome", "");
            var telefone = new Telefone("15", "987654321");
            var usuario = new Usuario(nomeCompleto, "email@duplicado.com", telefone);
            _usuarioRepository.Setup(m => m.ObterTodos(It.IsAny<Expression<Func<Usuario, bool>>>())).Returns(new List<Usuario>() { new Usuario(nomeCompleto, "email@duplicado.com", telefone) });

            _usuarioService.AtualizarUsuario(usuario);

            Assert.IsFalse(_usuarioService.OperacaoValida());
        }

        [TestMethod]
        public void RealizarAtualizacaoDeUsuarioComSucesso()
        {
            var nomeCompleto = new NomeCompleto("PrimeiroNome", "SegundoNome", "");
            var telefone = new Telefone("15", "987654321");
            var usuario = new Usuario(nomeCompleto, "email@teste.com", telefone);
            _unitOfWork.Setup(m => m.Commit()).Returns(CommandResponse.OK);

            _usuarioService.AtualizarUsuario(usuario);

            Assert.IsTrue(_usuarioService.OperacaoValida());
        }
    }
}
