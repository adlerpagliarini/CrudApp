using Crud.App.Domain.Services;
using System;
using System.Collections.Generic;

namespace Crud.App.Domain.Usuarios.Service
{
    public interface IUsuarioService : IServiceBase
    {
        void RegistrarUsuario(Usuario usuario);
        void AtualizarUsuario(Usuario usuario);
        void ExcluirUsuario(Guid id);
        Usuario SelecionarUsuarioPorId(Guid id);
        IEnumerable<Usuario> SelecionarTodosUsuarios();
    }
}
