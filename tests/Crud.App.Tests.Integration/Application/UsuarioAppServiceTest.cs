using AutoMapper;
using Crud.App.Application.AutoMapper;
using Crud.App.Application.Interfaces;
using Crud.App.Application.Services;
using Crud.App.Application.ViewModels;
using Crud.App.Domain.Core.Notifications;
using Crud.App.Domain.Usuarios.Service;
using Crud.App.Infra.Data.Context;
using Crud.App.Infra.Data.Repository;
using Crud.App.Infra.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Crud.App.Tests.Integration.Application
{
    [TestClass]
    public class UsuarioAppServiceTest
    {
        private IUsuarioAppService _usuarioAppService;
        private IMapper _mapper;
        private IUsuarioService _usuarioService;
        private UsuarioViewModel _usuarioViewModel;

        private CrudAppContext _dbContext;
        private IDbContextTransaction _transaction;

        [TestInitialize]
        public void SetUp()
        {
            _dbContext = new CrudAppContext();
            _transaction = _dbContext.Database.BeginTransaction();

            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new DomainToViewModelMappingProfile());
                cfg.AddProfile(new ViewModelToDomainMappingProfile());
            });

            var usuarioRepository = new UsuarioRepository(_dbContext);
            var unitOfWork = new UnitOfWork(_dbContext);
            var domainNotification = new DomainNotification();

            _mapper = config.CreateMapper();
            _usuarioService = new UsuarioService(usuarioRepository, unitOfWork, domainNotification);
            _usuarioAppService = new UsuarioAppService(_mapper, _usuarioService);
            _usuarioViewModel = new UsuarioViewModel { Nome = "Adler Pagliarini do Nascimento", Email = "adlerpagliarini@gmail.com", Telefone = "15981312383" };
        }

        [TestCleanup]
        public void Setdown()
        {
            _transaction.Rollback();
        }

        [TestMethod]
        public void RealizarCadastroDeUsuarioComSucesso()
        {
            _usuarioAppService.Registrar(_usuarioViewModel);

            var usuario = _usuarioAppService.ObterPorId(_usuarioViewModel.Id);

            Assert.IsNotNull(usuario);
        }

        [TestMethod]
        public void RealizarAtualizacaoDeUsuarioComSucesso()
        {
            _usuarioAppService.Registrar(_usuarioViewModel);

            _usuarioViewModel.Nome = "Pagliarini Nascimento";
            _usuarioViewModel.Email = "nascimento@gmail.com";
            _usuarioViewModel.Telefone = "15999999999";
            _usuarioAppService.Atualizar(_usuarioViewModel);

            var usuario = _usuarioAppService.ObterPorId(_usuarioViewModel.Id);

            Assert.AreEqual("Pagliarini Nascimento", usuario.Nome);
            Assert.AreEqual("nascimento@gmail.com", usuario.Email);
            Assert.AreEqual("15999999999", usuario.Telefone);
        }

        [TestMethod]
        public void RealizarExclusaoDeUsuarioComSucesso()
        {
            _usuarioAppService.Registrar(_usuarioViewModel);
            _usuarioAppService.Exluir(_usuarioViewModel.Id);

            var usuario = _usuarioAppService.ObterPorId(_usuarioViewModel.Id);

            Assert.IsNull(usuario);
        }
    }
}
