using Crud.App.Domain.CommandHandlers;
using Crud.App.Domain.Core.Notifications;
using Crud.App.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Crud.App.Infra.Data.Repository;

namespace Crud.App.Domain.Usuarios.Service
{
    public class UsuarioService : ServiceBase, IUsuarioService
    {

        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork, IDomainNotification notifications)
            : base(unitOfWork, notifications)
        {
            _usuarioRepository = usuarioRepository;
        }

        public void RegistrarUsuario(Usuario usuario)
        {
            if (!ValidacoesOk(usuario)) return;
            _usuarioRepository.Adicionar(usuario);
            Commit();
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            if (!ValidacoesOk(usuario)) return;
            _usuarioRepository.Atualizar(usuario);
            Commit();
        }

        public void ExcluirUsuario(Guid id)
        {
            _usuarioRepository.Remover(id);
            Commit();
        }

        public Usuario SelecionarUsuarioPorId(Guid id)
        {
            return _usuarioRepository.ObterPorId(id);
        }

        public IEnumerable<Usuario> SelecionarTodosUsuarios()
        {
            return _usuarioRepository.ObterTodos();
        }

        private bool UsuarioValido(Usuario usuario)
        {
            if (usuario.IsValid()) return true;

            NotificarValidacoesErro(usuario.ValidationResult);
            return false;
        }

        private bool UsuarioExistente(Usuario usuario)
        {
            var encontrados = _usuarioRepository.ObterTodos((user => user.Email == usuario.Email && user.Id != usuario.Id));
            if (encontrados.Any()) return true;
            return false;
        }

        private bool ValidacoesOk(Usuario usuario)
        {
            if (!UsuarioValido(usuario)) return false;
            if (UsuarioExistente(usuario))
            {
                NotificarValidacoesErro("Email", "Já existe usuário com este email");
                return false;
            }
            return true;
        }
    }
}
